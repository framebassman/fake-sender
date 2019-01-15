using System;
using Newtonsoft.Json;

namespace FakeSender.Api.Controllers.Responses.SmsRu.Reports
{
    public class BadPhoneReport : PhoneReport
    {
        [JsonProperty("status_text")]
        public String StatusText;

        public BadPhoneReport(int code, string text, string status = "ERROR")
            : base(status, code)
        {
            Status = "ERROR";
            StatusText = text;
        }
    }
}