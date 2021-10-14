using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentGateWay.Core.Entities
{
    public class CompanyAccount  : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string ContactName { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactPhone { get; set; }

        [Required]
        public double Balance { get; set; }
        [Required]
        public long BusinessId { set; get; }

        [Required]
        [ForeignKey("BusinessTypeId")]
        public long BusinessTypeId { get; set; }

        public BusinessType BusinessType { get; set; }

        [Required]
        [ForeignKey("BusinessCertificationId")]
        public  long BusinessCertificationId { set; get; }


        public Attachment BusinessCertification { set; get; }
    }
}