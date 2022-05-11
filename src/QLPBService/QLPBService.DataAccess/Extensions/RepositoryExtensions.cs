using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QLPBService.DataAccess.Context;
using QLPBService.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPBService.DataAccess.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddAppRepositories(this IServiceCollection services, IConfiguration Configuration)
        {            
            services.AddScoped<IPhongBanRepository, PhongBanRepository>();
            services.AddScoped<IKhoiPhongBanRepository, KhoiPhongBanRepository>();

            return services;
        }
    }
}
