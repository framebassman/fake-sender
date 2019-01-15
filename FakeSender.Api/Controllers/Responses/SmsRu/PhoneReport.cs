using System;
using Newtonsoft.Json;

namespace FakeSender.Api.Controllers.Responses.SmsRu
{
    public class PhoneReport
    {
        [JsonProperty("status")]
        public String Status;

        [JsonProperty("status_code")]
        public Int32 StatusCode;

        [JsonProperty("status_text")]
        public String StatusText;

        public PhoneReport(String status, Int32 code, String text)
        {
            Status = status;
            StatusCode = code;
            StatusText = text;
        }
    }
}