using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace FakeSender.Api.Models
{
    public class Limit
    {
        [JsonIgnore]
        public Int32 Id { get; set; }

        [JsonProperty("by_message")]
        public Int64 ByMessage { get; set; }

        [JsonProperty("by_minute")]
        public Int32 ByMinute { get; set; }

        [JsonProperty("by_day")] 
        public Int64 ByDay { get; set; }

        [ForeignKey("AccountForeignKey")]
        public Account Account { get; set; }
    }
}