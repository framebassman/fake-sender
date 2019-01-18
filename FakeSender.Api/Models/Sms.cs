using System.ComponentModel.DataAnnotations.Schema;

namespace FakeSender.Api.Models
{
    public class Sms : Entity
    {
        public string To { get; set; }
        public string Message { get; set; }
        
        [NotMapped]
        public override string EntityId => To;
    }
}