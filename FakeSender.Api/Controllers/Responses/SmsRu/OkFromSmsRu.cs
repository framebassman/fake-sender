using System.Collections.Generic;
using FakeSender.Api.Controllers.Responses.SmsRu.Reports;

namespace FakeSender.Api.Controllers.Responses.SmsRu
{
    public class OkFromSmsRu : Response
    {
        public OkFromSmsRu(Phone phone, PhoneReport report)
        {
            this.Status = "OK";
            this.StatusCode = 200;
            this.Balance = Random.Next() / 100.0;
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