using Demkin.StuSystem.Entity.Auth;
using Demkin.StuSystem.Util.DB;
using Demkin.StuSystem.Util.Helper;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Demkin.StuSystem.Entity.DbOperator
{
    /// <summary>
    /// 初始化数据库基本信息
    /// </summary>
    public class DbBasicData
    {
        private static string _initBasicDataFolder = Appsettings.App(new string[] { "MainDB", "InitBasicDataFolder" });

        public static async Task InitDataAsync(MyDbContext dbContext, string webRootPath)
        {
            await Task.Run(async () =>
            {
                try
                {
                    if (string.IsNullOrEmpty(webRootPath))
                        throw new ArgumentNullException("获取wwwroot路径时发生异常");

                    if (Appsettings.App(new string[] { "MainDB", "InitBasicData" }).ObjToBool() && !string.IsNullOrEmpty(_initBasicDataFolder))
                    {
                        _initBasicDataFolder = Path.Combine(webRootPath, _initBasicDataFolder);
                    }

                    // 创建数据库
                    if (DbConfigBase.DbType != DatabaseType.Oracle)
                    {
                        dbContext.Db.DbMaintenance.CreateDatabase();
                        Console.WriteLine($"数据库创建成功!");
                    }
                    else
                    {
                        Console.WriteLine($"Oracle 数据库不支持该操作，可手动创建Oracle数据库!");
                    }
                    // 创建表结构
                    var path = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
                    var referencedAssemblies = Directory.GetFiles(path, "Demkin.StuSystem.Entity.dll").Select(Assembly.LoadFrom).ToArray();
                    var modelTypes = referencedAssemblies
                        .SelectMany(a => a.DefinedTypes)
                        .Select(type => type.AsType())
                        .Where(x => x.IsClass && x.Namespace != null &&
                        (x.Namespace.Equals("Demkin.StuSystem.Entity.Auth")
                        )
                        ).ToList();

                    modelTypes.ForEach(options =>
                    {
                        if (!dbContext.Db.DbMaintenance.IsAnyTable(options.Name))
                        {
                            dbContext.Db.CodeFirst.InitTables(options);
                            Console.WriteLine($"{options.Name} 表创建成功!");
                        }
                        else
                        {
                            Console.WriteLine($"{options.Name} 表已存在,如需生成，请手动删除!");
                        }
                    });

                    //添加初始数据

                    #region SysUserInfo

                    if (!await dbContext.Db.Queryable<SysUser>().AnyAsync())
                    {
                        var data = NPOIHelper.XlsToList<SysUser>(Path.Combine(_initBasicDataFolder, "SysUser.xls"));
                        dbContext.GetEntityDB<SysUser>().InsertRange(data);
                        Console.WriteLine("表：SysUser 数据初始化成功......");
                    }
                    else
                    {
                        Console.WriteLine("表：SysUser 初始化数据失败!");
                    }

                    #endregion SysUserInfo

                    #region Role

                    if (!await dbContext.Db.Queryable<Role>().AnyAsync())
                    {
                        var data = NPOIHelper.XlsToList<Role>(Path.Combine(_initBasicDataFolder, "Role.xls"));
                        dbContext.GetEntityDB<Role>().InsertRange(data);
                        Console.WriteLine("表：Role 数据初始化成功......");
                    }
                    else
                    {
                        Console.WriteLine("表：Role 初始化数据失败!");
                    }

                    #endregion Role

                    #region UserRole

                    if (!await dbContext.Db.Queryable<UserRole>().AnyAsync())
                    {
                        var data = NPOIHelper.XlsToList<UserRole>(Path.Combine(_initBasicDataFolder, "UserRole.xls"));
                        dbContext.GetEntityDB<UserRole>().InsertRange(data);
                        Console.WriteLine("表：UserRole 数据初始化成功......");
                    }
                    else
                    {
                        Console.WriteLine("表：UserRole 初始化数据失败!");
                    }

                    #endregion UserRole

                    #region Module

                    if (!await dbContext.Db.Queryable<Auth.Module>().AnyAsync())
                    {
                        var data = NPOIHelper.XlsToList<Auth.Module>(Path.Combine(_initBasicDataFolder, "Module.xls"));
                        dbContext.GetEntityDB<Auth.Module>().InsertRange(data);
                        Console.WriteLine("表：Module 数据初始化成功......");
                    }
                    else
                    {
                        Console.WriteLine("表：Module 初始化数据失败!");
                    }

                    #endregion Module

                    #region Permission

                    if (!await dbContext.Db.Queryable<Permission>().AnyAsync())
                    {
                        var data = NPOIHelper.XlsToList<Permission>(Path.Combine(_initBasicDataFolder, "Permission.xls"));
                        dbContext.GetEntityDB<Permission>().InsertRange(data);
                        Console.WriteLine("表：Permission 数据初始化成功......");
                    }
                    else
                    {
                        Console.WriteLine("表：Permission 初始化数据失败!");
                    }

                    #endregion Permission

                    #region RoleModulePermission

                    if (!await dbContext.Db.Queryable<RoleModulePermission>().AnyAsync())
                    {
                        var data = NPOIHelper.XlsToList<RoleModulePermission>(Path.Combine(_initBasicDataFolder, "RoleModulePermission.xls"));
                        dbContext.GetEntityDB<RoleModulePermission>().InsertRange(data);
                        Console.WriteLine("表：RoleModulePermission 数据初始化成功......");
                    }
                    else
                    {
                        Console.WriteLine("表：RoleModulePermission 初始化数据失败!");
                    }

                    #endregion RoleModulePermission
                }
                catch (Exception)
                {
                    // todo
                }
            });
        }
    }
}