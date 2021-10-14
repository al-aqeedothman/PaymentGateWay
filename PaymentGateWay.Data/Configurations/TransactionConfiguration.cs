using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGateWay.Core.Entities;

namespace PaymentGateWay.Data.Configurations
{
    public class TransactionConfiguration
    {
        public TransactionConfiguration(EntityTypeBuilder<Transaction> entity)
        {
            entity
                .HasOne(m => m.TransactionType)
                .WithMany()
                .HasForeignKey(m => m.TransactionTypeId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            entity
                .HasOne(m => m.User)
                .WithMany(m=>m.Transactions)
                .HasForeignKey(m => m.CreatedById).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);


        }
    }
}