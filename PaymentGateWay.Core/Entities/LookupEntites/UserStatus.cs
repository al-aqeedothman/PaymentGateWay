using System.ComponentModel.DataAnnotations;

namespace PaymentGateWay.Core.Entities
{
    public class UserStatus
    {
        [Key]
        public long Id { set; get; }

        [Required]
        [MaxLength(100)]
        public string Value { get; set; }
    }
}