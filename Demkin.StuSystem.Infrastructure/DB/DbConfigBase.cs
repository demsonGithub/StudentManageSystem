using Demkin.StuSystem.Util.Helper;
using System;
using System.IO;

namespace Demkin.StuSystem.Util.DB
{
    public class DbConfigBase
    {
        public static string ConnectionString => _initConnection();
        public static DatabaseType DbType = DatabaseType.SqlServer;

        private static string _sqliteConnection = Appsettings.App(new string[] { "MainDB", "Sqlite", "Connection" });
        private static bool _isSqliteEnabled = Appsettings.App(new string[] { "MainDB", "Sqlite", "Enabled" }).ObjToBool();

        private static string _sqlServerConnection = Appsettings.App(new string[] { "MainDB", "SqlServer", "Connection" });
        private static bool _isSqlServerEnabled = Appsettings.App(new string[] { "MainDB", "SqlServer", "Enabled" }).ObjToBool();

        private static string _mySqlConnection = Appsettings.App(new string[] { "MainDB", "MySql", "Connection" });
        private static bool _isMySqlEnabled = Appsettings.App(new string[] { "MainDB", "MySql", "Enabled" }).ObjToBool();

        private static string _initConnection()
        {
            if (_isSqliteEnabled)
            {
                DbType = DatabaseType.Sqlite;
                return $"DataSource=" + Path.Combine(Environment.CurrentDirectory, _sqliteConnection);
            }
            else if (_isSqlServerEnabled)
            {
                DbType = DatabaseType.SqlServer;
                return _sqlServerConnection;
            }
            else if (_isMySqlEnabled)
            {
                DbType = DatabaseType.MySql;
                return _mySqlConnection;
            }
            else
            {
                return "server=.;uid=sa;pwd=sa;database=WMBlogDB";
            }
        }
    }
}