using Buber.Application.Common.Interfaces.Authentication;
using Buber.Application.Common.Interfaces.Services;
using Buber.Application.Persistence;
using Buber.Domain.Persistence;
using Buber.Infrastructure.Authentication;
using Buber.Infrastructure.Persistence;
using Buber.Infrastructure.Persistence.BuberDataBaseContext;
using Buber.Infrastructure.Services;
using Jose;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,ConfigurationManager configuration)
        {
            services.Configure<Authentication.JwtSettings>(configuration.GetSection(Authentication.JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();


            #region Repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            #endregion

            #region DbContext
            services.AddDbContext<BuberDbContext>(options => options.UseSqlServer());
            #endregion
            return services;
        }
    }
}
