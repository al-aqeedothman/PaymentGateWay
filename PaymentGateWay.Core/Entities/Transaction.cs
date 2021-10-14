using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PaymentGateWay.Core.Entities
{
  public  class Transaction
    {
        public long Id { get; set; }

        [ForeignKey("CreatedById")]
        public long? CreatedById { get; set; }

        public DateTime? CreatedDate { get; set; }

        [ForeignKey("UpdatedById")]
        public long? UpdatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [Required]
        [ForeignKey("TransactionTypeId")]
        public long TransactionTypeId { get; set; }

        public double Amount { get; set; }

        public  TransactionType TransactionType { get; set; }

        public User User { get; set; }

    }
}
