using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PaymentGateWay.Core;
using PaymentGateWay.Core.Entities;
using PaymentGateWay.Core.Models;
using PaymentGateWay.Core.Repositories;
using PaymentGateWay.Core.Services;
using PaymentGateWay.Data;
using PaymentGateWay.Data.Repositories;
using PaymentGateWay.Services.Services;

namespace PaymentGateWay.Api.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAttachmentRepository, AttachmentRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IBusinessTypeRepository, BusinessTypeRepository>();
            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();

            return services;
        }

        public static IServiceCollection ConfigureService(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<ILookupService, LookupService>();
         
            return services;
        }

        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User,CompanyUserModel>().ReverseMap();
                cfg.CreateMap<User, AuthenticationModel>().ReverseMap();
                cfg.CreateMap<User, CompanyUserVm>().ReverseMap();
                cfg.CreateMap<User, IndiviualUserVm>().ReverseMap();
                cfg.CreateMap<User, IndiviualUserModel>().ReverseMap();
                cfg.CreateMap<UserStatus, UserStatusModel>().ReverseMap();
                cfg.CreateMap<UserType, UserTypeModel>().ReverseMap();
                cfg.CreateMap<Attachment, AttachmentModel>().ReverseMap();
                cfg.CreateMap<CompanyAccount, CompanyAccountModel>().ReverseMap();
                cfg.CreateMap<CompanyAccount, CompanyAccountVm>().ReverseMap();
                cfg.CreateMap<IndiviualAccount, IndiviualAccountModel>().ReverseMap();
                cfg.CreateMap<IndiviualAccount, IndiviualAccountVm>().ReverseMap();
                cfg.CreateMap<BaseModel, BaseEntity>().ReverseMap();
                cfg.CreateMap<BusinessType, BusinessTypeModel>().ReverseMap();
                cfg.CreateMap<TransactionType, TransactionTypeModel>().ReverseMap();
                cfg.CreateMap<Transaction, TransactionModel>().ReverseMap();
                


            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }


        public static IServiceCollection AddConnection(this IServiceCollection services,
     IConfiguration configuration)
        {
    

            string connection = configuration.GetConnectionString("SQLConnection");                                      
            services.AddDbContext<PaymentDbContext>(options =>
            options.UseSqlServer(connection, b => b.MigrationsAssembly("PaymentGateWay.Data")));

            

            return services;
        }




        public static IServiceCollection AddMiddleware(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .Build());
            }
        );

        public static IServiceCollection AddLogging(this IServiceCollection services)
        {
            services.AddLogging(builder => builder
                .AddConsole()
                .AddFilter(level => level >= Microsoft.Extensions.Logging.LogLevel.Information)
            );

            return services;
        }

       

        
    
}
}
