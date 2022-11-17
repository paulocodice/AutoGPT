using BlockKing.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BlockKing.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace BlockKing.Data.Services
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDataEntities(this IServiceCollection services)
        {
            services.AddTransient<User>();
            services.AddTransient<Work>();
            services.AddTransient<UserBlockSetting>();



            return services;

        }
    }
}
