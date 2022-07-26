using Demkin.StuSystem.Util.DB;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demkin.StuSystem.Extensions.ServiceExtensions
{
    /// <summary>
    /// sqlsugar 连接服务
    /// </summary>
    public static class SqlSugarSetup
    {
        public static void AddSqlSugarSetup(this IServiceCollection service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));

            // 数据库连接
            service.AddScoped<ISqlSugarClient>(o =>
            {
                var connectionConfig = new ConnectionConfig
                {
                    ConnectionString = DbConfigBase.ConnectionString,// 必填，数据库连接字符串
                    DbType = (DbType)DbConfigBase.DbType,//必填, 数据库类型
                    IsAutoCloseConnection = true,       //默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作
                    InitKeyType = InitKeyType.Attribute,   //默认SystemTable, 字段信息读取, 如：该属性是不是主键，标识列等等信息
                };
                return new SqlSugarScope(connectionConfig);
            });
        }
    }
}