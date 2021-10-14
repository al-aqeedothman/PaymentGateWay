using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateWay.Core.Entities;


namespace PaymentGateWay.Data.Configurations
{
    public class UserTypeConfiguration
    {
        public UserTypeConfiguration(EntityTypeBuilder<UserType> entity)
        {
            entity.HasData(
                new UserType {Id = 1, Value = "SystemAdmin"},
                new UserType {Id = 2, Value = "individual" },
                new UserType {Id = 3, Value = "company" }
            );



        }
    }
}