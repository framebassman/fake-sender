using System.Collections.Generic;

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
                    new PhoneReport("OK", 200, "Sms was sent")
                }
            };
        }
    }
}