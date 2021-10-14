using System;

namespace PaymentGateWay.Core.Models
{
    public class TransactionFilterModel
    {
        public long? TransactionTypeId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }


    }
}