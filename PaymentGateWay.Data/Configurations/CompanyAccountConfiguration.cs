using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGateWay.Core.Entities;

namespace PaymentGateWay.Data.Configurations
{
    public class CompanyAccountConfiguration
    {

        public CompanyAccountConfiguration(EntityTypeBuilder<CompanyAccount> entity)
        {
            entity
                .HasOne(m => m.BusinessCertification)
                .WithMany()
                .HasForeignKey(m => m.BusinessCertificationId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            entity
                .HasOne(m => m.BusinessType)
                .WithMany()
                .HasForeignKey(m => m.BusinessTypeId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
        
    }
}