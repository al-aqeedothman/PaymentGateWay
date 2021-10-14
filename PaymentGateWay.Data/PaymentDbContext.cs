using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PaymentGateWay.Core.Entities;
using PaymentGateWay.Data.Configurations;

namespace PaymentGateWay.Data
{
  public sealed class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
           // this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<User> User { set; get; }
        public DbSet<UserType> UserType { set; get; }
        public DbSet<UserStatus> UserStatus { set; get; }
        public DbSet<IndiviualAccount> IndiviualAccount { set; get; }
        public DbSet<CompanyAccount> CompanyAccount { set; get; }
        public DbSet<Attachment> Attachment { set; get; }
        public DbSet<Transaction> Transaction { set; get; }
        public DbSet<TransactionType> TransactionType { set; get; }
        public DbSet<BusinessType> BusinessType { set; get; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<User>());
            new UserTypeConfiguration(modelBuilder.Entity<UserType>());
            new UserStatusConfiguration(modelBuilder.Entity<UserStatus>());
            new IndiviualAccountConfiguration(modelBuilder.Entity<IndiviualAccount>());
            new CompanyAccountConfiguration(modelBuilder.Entity<CompanyAccount>());
            new AttachmentConfiguration(modelBuilder.Entity<Attachment>());
            new TransactionConfiguration(modelBuilder.Entity<Transaction>());
            new TransactionTypeConfiguration(modelBuilder.Entity<TransactionType>());
            new BusinessTypeConfiguration(modelBuilder.Entity<BusinessType>());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);

        }
    }
}
