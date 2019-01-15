using System;
using FakeSender.Api.Controllers.Responses;
using FakeSender.Api.Controllers.Responses.SmsRu;
using FakeSender.Api.Controllers.Responses.SmsRu.Validators;
using FakeSender.Api.Data;
using FakeSender.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlMatches;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FakeSender.Api.Controllers
{
    [Route("api/[controller]")]
    public class SmsRuController : StorageController<Sms>
    {
        private readonly ApplicationContext _db;
        private readonly ILogger _logger;
        
        public SmsRuController(ApplicationContext context, ILogger<SmsRuController> logger) 
            : base(context, context.SmsBox, logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet("send")]
        public IActionResult Send(
            [FromQuery(Name = "api_id")] Guid apiId,
            [FromQuery] String from,
            [FromQuery] Int32 json,
            [FromQuery(Name = "msg")] String encodedMsg,
            [FromQuery] String to
        )
        {
            var msg = Uri.UnescapeDataString(encodedMsg); 
            var phone = new Phone(to);
            _logger.LogInformation($"Received message to {phone}");
            var validator = new MobilePhoneValidator(phone);
            return new OkObjectResult(
                new Ok(
                    phone,
                    validator.Answer()
                )
            );
        }
    }
}