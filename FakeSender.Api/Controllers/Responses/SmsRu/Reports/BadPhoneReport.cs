using System;
using Newtonsoft.Json;

namespace FakeSender.Api.Controllers.Responses.SmsRu.Reports
{
    public class BadPhoneReport : PhoneReport
    {
        [JsonProperty("status_text")]
        public String StatusText;

        public BadPhoneReport(string status, int code, string text)
            : base(status, code)
        {
            StatusText = text;
        }
    }
}