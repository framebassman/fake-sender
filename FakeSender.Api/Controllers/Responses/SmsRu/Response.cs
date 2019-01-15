using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FakeSender.Api.Controllers.Responses.SmsRu
{
    public abstract class Response
    {
        [JsonProperty("status")]
        public String Status;

        [JsonProperty("status_code")]
        public Int32 StatusCode;

        [JsonProperty("balance")]
        public Double Balance;

        [JsonProperty("sms")]
        public Dictionary<Phone, PhoneReport> Sms;

        protected static readonly Random Random = new Random();
    }
}