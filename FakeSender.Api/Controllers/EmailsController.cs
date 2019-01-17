using System;
using System.Collections.Generic;
using System.Linq;
using FakeSender.Api.Data;
using FakeSender.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FakeSender.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmailsController : StorageController<Email>
    {
        private readonly ApplicationContext _db;
        private readonly ILogger _logger;
        
        public EmailsController(ApplicationContext context, ILogger<EmailsController> logger) 
            : base(context, context.EmailBox, logger)
        {
            _db = context;
            _logger = logger;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<Email> emailList)
        {
            if (emailList != null && emailList.Count() != 0)
            {
                foreach (var email in emailList)
                {
                    _logger.LogInformation($"Received message to {email.To}");
                    email.ReceivedAt = DateTime.UtcNow;
                }
                
                _db.EmailBox.AddRangeAsync(emailList);
                _db.SaveChanges();
                return Ok(emailList);
            }

            return BadRequest();
        }
    }
}