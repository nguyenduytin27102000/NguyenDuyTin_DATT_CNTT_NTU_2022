using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QLPBService.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPBService.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {           
            #region Services
            services.AddScoped<IKhoiPhongBanCRUDService, KhoiPhongBanCRUDService>();
            #endregion Services
        }
    }
}
