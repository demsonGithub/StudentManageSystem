using Demkin.StuSystem.Entity.DbOperator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demkin.StuSystem.Extensions.ServiceExtensions
{
    /// <summary>
    /// Db 服务
    /// </summary>
    public static class DbSetup
    {
        public static void AddDbSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<MyDbContext>();
        }
    }
}