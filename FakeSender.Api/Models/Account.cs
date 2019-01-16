using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakeSender.Api.Models
{
    public class Account : Entity
    {
        [Required]
        public String Type { get; set; }
        [Required]
        public String Service { get; set; }
        [Required]
        public Double Balance { get; set; }
        [Required]
        public String Login { get; set; }
        [NotMapped]
        public override string EntityId => this.Login;
    }
}