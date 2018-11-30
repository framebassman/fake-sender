using System;
using FakeSender.Api.Data;
using FakeSender.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FakeSender.Api.Controllers
{
    [Route("api/[controller]")]
    public class ApnsController : StorageController<ApnsQuery>
    {
        private readonly ApplicationContext _db;
        private readonly ILogger _logger;
        
        public ApnsController(ApplicationContext context, ILogger<ApnsController> logger) 
            : base(context, context.ApnsQueryBox, logger)
        {
            _logger = logger;
            _db = context;
        }

        [HttpPost]
        public IActionResult PostQuery([FromBody] ApnsQuery query)
        {
            if (query != null)
            {
                _logger.LogInformation($"{DateTime.Now}: Received message to {query.PushToken}");
                
                _db.ApnsQueryBox.Add(query);
                _db.SaveChanges();
                return Ok(query);
            }

            return BadRequest();
        }
    }
}