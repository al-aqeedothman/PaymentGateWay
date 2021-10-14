using System;

namespace PaymentGateWay.Core.Models
{
    public class BaseModel
    {
        public long Id { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}