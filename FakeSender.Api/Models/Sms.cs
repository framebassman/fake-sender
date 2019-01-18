using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace FakeSender.Api.Models
{
    public class Sms : Entity
    {
        public string To { get; set; }
        public string Message { get; set; }
        [JsonIgnore]
        public DateTime ReceivedAt { get; set; }
        
        [NotMapped]
        public override string EntityId => To;
    }
}