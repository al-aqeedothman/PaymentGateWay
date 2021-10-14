using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGateWay.Core.Entities;

namespace PaymentGateWay.Data.Configurations
{
    public class UserStatusConfiguration
    {
        public UserStatusConfiguration(EntityTypeBuilder<UserStatus> entity)
        {
            entity.HasData(
                new UserStatus {Id = 1, Value = "Active"},
                new UserStatus {Id = 2, Value = "inactive" },
                new UserStatus {Id = 3, Value = "pending" }
                );
        }
    }
}