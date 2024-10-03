using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.UnitOfWorks;
using MinimalBankAPI_OnionArch.Persistance.Context;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract.Base;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Concrete;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Concrete.Base;
using MinimalBankAPI_OnionArch.Persistance.UnitOfWorks;

namespace MinimalBankAPI_OnionArch.Persistance
{
    public static class Registration
    {
        public static void RegisterPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //Repository DPI'ı
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IRoleOperationClaimRepository, RoleOperationClaimRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerRoleRepository, CustomerRoleRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();


            // UnitOFWorks DPI'ı
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));


        }
    }
}
