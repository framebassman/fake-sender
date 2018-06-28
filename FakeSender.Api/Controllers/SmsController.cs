using System.Collections.Generic;
using System.Linq;
using FakeSender.Api.Data;
using FakeSender.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FakeSender.Api.Controllers
{
    [Route("api/[controller]")]
    public class SmsController : StorageController<Sms>
    {
        private readonly ApplicationContext _db;
        private readonly ILogger _logger;
        
        public SmsController(ApplicationContext context, ILogger<SmsController> logger) 
            : base(context, context.SmsBox, logger)
        {
            _db = context;
            _logger = logger;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<Sms> smsList)
        {
            if (smsList != null && smsList.Count() != 0)
            {
                foreach (var sms in smsList)
                {
                    _logger.LogInformation($"Received message to {sms.To}");   
                }
                
                _db.SmsBox.AddRangeAsync(smsList);
                _db.SaveChangesAsync();
                return Ok(smsList);
            }

            return BadRequest();
        }
    }
}