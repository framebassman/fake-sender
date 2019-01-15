using System.Collections.Generic;
using FakeSender.Api.Controllers.Responses.SmsRu.Reports;

namespace FakeSender.Api.Controllers.Responses.SmsRu
{
    public class Ok : Response
    {
        public Ok(Phone phone)
        {
            Status = "OK";
            StatusCode = 200;
            Balance = Random.Next() / 100.0;
            Sms = new Dictionary<Phone, PhoneReport>
            {
                {
                    phone,
                    new OkPhoneReport()
                }
            };
        }
    }
}