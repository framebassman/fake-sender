using System;
using Newtonsoft.Json;

namespace FakeSender.Api.Controllers.Responses.SmsRu.Reports
{
    public class OkPhoneReport : PhoneReport
    {
        [JsonProperty]
        public string SmsId;
        
        public OkPhoneReport(string status = "OK", int code = 200)
            : base(status, code)
        {
            this.Status = "OK";
            this.StatusCode = 100;
            this.SmsId = "1111_2222";
        }
    }
}