using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGateWay.Core.Entities;

namespace PaymentGateWay.Data.Configurations
{
    public class TransactionTypeConfiguration
    {
        public TransactionTypeConfiguration(EntityTypeBuilder<TransactionType> entity)
        {

            entity.HasData(
                new TransactionType { Id = 1, Value = "withdrawal" },
                new TransactionType { Id = 2, Value = "Refund" },
                new TransactionType { Id = 3, Value = "Pay" }
            );
        }
    }
}