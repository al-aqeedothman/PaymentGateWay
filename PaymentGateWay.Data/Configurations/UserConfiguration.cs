
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateWay.Core.Entities;

namespace PaymentGateWay.Data.Configurations
{
   public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<User> entity)
        {
            entity.HasIndex(e => new {e.IndiviualAccountId, e.CompanyAccountId}).IsUnique();
            entity
                .HasOne(m => m.UserType)
                .WithMany()
                .HasForeignKey(m => m.UserTypeId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);


            entity
                .HasOne(m => m.UserStatus)
                .WithMany()
                .HasForeignKey(m => m.UserStatusId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            entity
                .HasOne(m => m.IndiviualAccount)
                .WithOne()
                .HasForeignKey<User>(m => m.IndiviualAccountId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            entity
                .HasOne(m => m.CompanyAccount)
                .WithOne()
                .HasForeignKey<User>(m => m.CompanyAccountId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);


            entity.HasData(
                new User
                {
                    Id=1,
                    LoginName = "superAdmin" ,
                    Password = "/e9LCZCv0OnYEC/ggb3KFQ==:::g6a5JtXuBrRM9Elw7LCT9y+yzsdbZRbb0eg3ztnwWSI=", //21310605
                    UserStatusId = 1 ,
                    UserTypeId =  1
                }
                );

        }
    }
}
