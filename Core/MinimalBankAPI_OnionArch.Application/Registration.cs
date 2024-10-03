using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalBankAPI_OnionArch.Application.Common.CCC.Caches.RedisCache;
using MinimalBankAPI_OnionArch.Application.Common.CCC.Exceptions;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.RedisCache;
using MinimalBankAPI_OnionArch.Application.Common.Pipelines;
using MinimalBankAPI_OnionArch.Application.Common.RuleBases;
using System.Reflection;

namespace MinimalBankAPI_OnionArch.Application
{
    public static class Registration
    {
        public static void RegisterApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            //Profiles DPI
            services.AddAutoMapper(assembly);
            // Features kısmındaki assembly DPI'ı
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            // Tüm RULE'ları tek tek DPI yapmamak için
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            // Exception middleware DPI
            services.AddTransient<ExceptionMiddleware>();

            // Logger service DPI'yı

            // Fluent Validation pipeline DPI
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));

            // Redis Cache ve Redis pipeline DPI
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehevior<,>));
            services.Configure<RedisCacheSettings>(configuration.GetSection("RedisCacheSettings"));
            services.AddTransient<IRedisCacheService, RedisCacheService>();
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration["RedisCacheSettings:ConnectionString"];
                opt.InstanceName = configuration["RedisCacheSettings:InstanceName"];
            });

            // HttpContext Accessor DPI
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        // Base Ruleden Extend olanları rule sayar asssmbly de 
        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services,
                    Assembly assembly,
                    Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var t in types)
            {
                services.AddTransient(t);
            }
            return services;
        }



    }
}
