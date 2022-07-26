using Demkin.StuSystem.Util.Helper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Demkin.StuSystem.Extensions.ServiceExtensions
{
    /// <summary>
    /// Swagger 相关服务
    /// </summary>
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            string apiName = Appsettings.App("");
            string versionName = "v1";
            string basePath = AppContext.BaseDirectory;

            services.AddSwaggerGen(c =>
            {
                // 添加版本说明
                c.SwaggerDoc(versionName, new OpenApiInfo
                {
                    Version = versionName,
                    Title = $"{apiName} 接口文档——{RuntimeInformation.FrameworkDescription}",
                    Description = $"{apiName} Http Api {versionName}",
                });
                c.OrderActionsBy(o => o.RelativePath);

                // 将注释显示在接口上说明
                var xmlPath = Path.Combine(basePath, "Demkin.StuSystem.WebApi.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}