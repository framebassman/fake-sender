using System;
using System.Collections.Generic;
using FakeSender.Api.Controllers.Responses;
using FakeSender.Api.Controllers.Responses.SmsRu;
using FakeSender.Api.Controllers.Responses.SmsRu.Validators;
using FakeSender.Api.Data;
using FakeSender.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FakeSender.Api.Controllers
{
    [Route("api/[controller]")]
    public class SmsRuController : StorageController<Sms>
    {
        private readonly ApplicationContext _db;
        private readonly ILogger _logger;
        private readonly List<Validator> _validators;
        
        public SmsRuController(ApplicationContext context, ILogger<SmsRuController> logger) 
            : base(context, context.SmsBox, logger)
        {
            this._db = context;
            this._logger = logger;
            this._validators = new List<Validator>
            {
                new BalanceValidator()
            };
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
            this._logger.LogInformation($"Received message to {phone}");
            this._validators.Add(new MobilePhoneValidator(phone));
            var cascade = new Cascade(this._validators);
            return new OkObjectResult(
                new OkFromSmsRu(
                    phone,
                    cascade.Answer()
                )
            );
        }
    }
}