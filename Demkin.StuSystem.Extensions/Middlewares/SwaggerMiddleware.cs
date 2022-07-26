using Demkin.StuSystem.Util.Helper;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demkin.StuSystem.Extensions.Middlewares
{
    public static class SwaggerMiddleware
    {
        public static void UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            string apiName = Appsettings.App("ApiBasicInfo", "ApiName");
            string versionName = "v1";

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{versionName}/swagger.json", $"{apiName}_{versionName}");
                c.RoutePrefix = "api";
            });
        }
    }
}