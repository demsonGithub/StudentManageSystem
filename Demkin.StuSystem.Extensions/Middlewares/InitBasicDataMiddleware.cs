using Demkin.StuSystem.Entity.DbOperator;
using Demkin.StuSystem.Util.Helper;
using Microsoft.AspNetCore.Builder;

using System;

namespace Demkin.StuSystem.Extensions.Middlewares
{
    /// <summary>
    /// 初始化基本表结构和数据
    /// </summary>
    public static class InitBasicDataMiddleware
    {
        public static void UseInitBasicDataMidd(this IApplicationBuilder app, MyDbContext myDbContext, string webRootPath)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            try
            {
                if (Appsettings.App("MainDB", "InitTables").ObjToBool())
                {
                    DbBasicData.InitDataAsync(myDbContext, webRootPath).Wait();
                }
            }
            catch (Exception)
            {
                // todo
            }
        }
    }
}