using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentGateWay.Core.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}