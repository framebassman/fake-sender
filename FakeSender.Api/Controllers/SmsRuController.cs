using FakeSender.Api.Data;
using FakeSender.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FakeSender.Api.Controllers
{
    [Route("api/[controller]")]
    public class SmsRuController : StorageController<Sms>
    {
        private readonly ApplicationContext _db;
        private readonly ILogger _logger;
        
        public SmsRuController(ApplicationContext context, DbSet<Sms> box, ILogger<StorageController<Sms>> logger)
            : base(context, box, logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet("send")]
        public IActionResult Send()
        {
            return null;
        }
    }
}