using System.Linq;
using FakeSender.Api.Data;
using FakeSender.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FakeSender.Api.Controllers
{
    public abstract class StorageController<T> : Controller, IStorageController<T> where T : Entity
    {
        private DbSet<T> _box;
        private ApplicationContext _db;
        private ILogger<StorageController<T>> _logger;
        
        public StorageController(ApplicationContext context, DbSet<T> box, ILogger<StorageController<T>> logger)
        {
            _db = context;
            _logger = logger;
            _box = box;
        }
        
        [HttpGet]
        public virtual IActionResult GetAll()
        {
            return Json(_box.ToList());
        }

        [HttpGet("{To}")]
        public virtual IActionResult Get(string To)
        {
            return Json(_box.Where(e => e.EntityId == To).ToList());
        }

        [HttpDelete]
        public virtual IActionResult DeleteAll()
        {
            _logger.LogInformation("Deleted all messages");
            _box.RemoveRange(_box);
            _db.SaveChanges();
            return Json("Deleted all messages in apns query box");
        }

        [HttpDelete("{To}")]
        public virtual IActionResult Delete(string To)
        {
            _logger.LogInformation($"Deleted all messages in for {To}");
            _box.RemoveRange(_box.Where(e => e.EntityId == To));
            _db.SaveChanges();
            return Json($"Deleted all messages in apns query box for {To}");
        }
    }
}