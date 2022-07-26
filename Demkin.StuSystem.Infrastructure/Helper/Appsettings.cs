using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demkin.StuSystem.Util.Helper
{
    /// <summary>
    /// appsettings.json 操作类
    /// </summary>
    public class Appsettings
    {
        /*
         * 需要引用的Nuget包：
         * Microsoft.Extensions.Configuration.Binder
         * Microsoft.Extensions.Configuration.Json
         */

        private static IConfiguration Configuration { get; set; }

        public Appsettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Appsettings(string contentPath)
        {
            string Path = "appsettings.json";

            Configuration = new ConfigurationBuilder()
               .SetBasePath(contentPath)
               .Add(new JsonConfigurationSource { Path = Path, Optional = false, ReloadOnChange = true })//这样的话，可以直接读目录里的json文件，而不是 bin 文件夹下的，所以不用修改复制属性
               .Build();
        }

        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static string App(params string[] sections)
        {
            try
            {
                if (sections.Any())
                {
                    return Configuration[string.Join(":", sections)];
                }
            }
            catch (Exception)
            {
                // todo
            }
            return "";
        }

        /// <summary>
        ///  递归获取配置信息数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static List<T> App<T>(params string[] sections)
        {
            List<T> list = new List<T>();
            Configuration.Bind(string.Join(":", sections), list);
            return list;
        }

        /// <summary>
        ///  根据路径 configuration["Key:Value"]
        /// </summary>
        /// <param name="sectionsPath"></param>
        /// <returns></returns>
        public static string GetValue(string sectionsPath)
        {
            try
            {
                return Configuration[sectionsPath];
            }
            catch (Exception)
            {
                // todo
            }
            return "";
        }
    }
}