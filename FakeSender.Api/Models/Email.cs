using System.ComponentModel.DataAnnotations.Schema;

namespace FakeSender.Api.Models
{
    public class Email : Entity
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Html { get; set; }
        public string Attachments { get; set; }
        
        [NotMapped]
        public override string EntityId => To;
    }
}