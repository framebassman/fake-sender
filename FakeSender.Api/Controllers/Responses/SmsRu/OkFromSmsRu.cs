using System.Collections.Generic;
using FakeSender.Api.Controllers.Responses.SmsRu.Reports;
using FakeSender.Api.Models;

namespace FakeSender.Api.Controllers.Responses.SmsRu
{
    public class OkFromSmsRu : Response
    {
        public OkFromSmsRu(Phone phone, PhoneReport report, Account account)
        {
            this.Status = "OK";
            this.StatusCode = 200;
            this.Balance = account.Balance;
            this.Sms = new Dictionary<Phone, PhoneReport>
            {
                {
                    phone,
                    report
                }
            };
        }
    }
}