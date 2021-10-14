using System.ComponentModel.DataAnnotations;

namespace PaymentGateWay.Core.Entities
{
    public class IndiviualAccount : BaseEntity
    {
        
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactName { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactPhone { get; set; }

        [Required]
        public double Balance { get; set; }

    }
}