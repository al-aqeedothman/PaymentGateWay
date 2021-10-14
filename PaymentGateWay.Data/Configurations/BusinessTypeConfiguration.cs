using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGateWay.Core.Entities;

namespace PaymentGateWay.Data.Configurations
{
    public class BusinessTypeConfiguration
    {
        public BusinessTypeConfiguration(EntityTypeBuilder<BusinessType> entity)
        {
            entity.HasData(
                new BusinessType { Id = 1, Value = "Partnership" },
                new BusinessType { Id = 2, Value = "Corporation" },
                new BusinessType { Id = 3, Value = "Nonprofit Organization" }
            );
        }
    }
}