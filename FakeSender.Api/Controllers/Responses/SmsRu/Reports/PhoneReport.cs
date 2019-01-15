using System;
using Newtonsoft.Json;

namespace FakeSender.Api.Controllers.Responses.SmsRu.Reports
{
    public abstract class PhoneReport
    {
        [JsonProperty("status")]
        public String Status;

        [JsonProperty("status_code")]
        public Int32 StatusCode;

        public PhoneReport(String status, Int32 code)
        {
            Status = status;
            StatusCode = code;
        }
    }
}