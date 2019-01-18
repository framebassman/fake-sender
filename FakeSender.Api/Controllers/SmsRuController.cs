using System;
using System.Collections.Generic;
using System.Linq;
using FakeSender.Api.Controllers.Responses;
using FakeSender.Api.Controllers.Responses.SmsRu;
using FakeSender.Api.Controllers.Responses.SmsRu.Reports;
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
        
        public SmsRuController(ApplicationContext context, ILogger<SmsRuController> logger) 
            : base(context, context.SmsBox, logger)
        {
            this._db = context;
            this._logger = logger;
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
            var account = this.Find(from);
            var cascade = new Cascade(
                this.CreateValidators(
                    account,
                    phone
                )
            );
            this.TryToSaveMessage(
                new Sms{Message = msg, To = phone.ToString()},
                cascade.Answer()
            );
            return new OkObjectResult(
                new OkFromSmsRu(
                    phone,
                    cascade.Answer(),
                    account
                )
            );
        }

        private IEnumerable<Validator> CreateValidators(Account account, Phone phone)
        {
            return new List<Validator>
            {
                new BalanceValidator(account),
                new MobilePhoneValidator(phone)
            };
        }

        private Account Find(string from)
        {
            var candidate = this._db.Accounts.FirstOrDefault(a => a.Login == from);
            if (candidate == null)
            {
                this._logger.LogWarning($"There is no account for {from} login. Let's create it.");
                return this._db.Accounts.Add(
                    new Account
                    {
                        Type = "sms",
                        Service = "smsru",
                        Login = from,
                        Balance = 0.5
                    }
                ).Entity;
            }
            else
            {
                return candidate;
            }
        }
        
        private void TryToSaveMessage(Sms sms, PhoneReport answer)
        {
            if (answer is OkPhoneReport)
            {
                this._db.SmsBox.Add(sms);
                this._db.SaveChanges();
                this._logger.LogInformation($"Message was saved: {sms.ToJson()}");
            }
            else
            {
                this._logger.LogInformation($"Message was not saved: {((BadPhoneReport) answer).StatusText}");
            }
        }
    }
}