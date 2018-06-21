using System.ComponentModel.DataAnnotations.Schema;

namespace FakeSender.Api.Models
{
    public class ApnsQuery : Entity
    {
        public string PushToken { get; set; }
        public string ApplePassTypeId { get; set; }

        [NotMapped]
        public override string EntityId => PushToken;
    }
}