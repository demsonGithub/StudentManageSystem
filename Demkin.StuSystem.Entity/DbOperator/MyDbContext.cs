using Demkin.StuSystem.Util.DB;
using SqlSugar;
using System;

namespace Demkin.StuSystem.Entity.DbOperator
{
    public class MyDbContext
    {
        private SqlSugarScope _db;
        private static string _connectionString = DbConfigBase.ConnectionString;
        private static DbType _dbType = (DbType)DbConfigBase.DbType;

        /// <summary>
        /// 数据连接对象
        /// Student.Achieve
        /// </summary>
        public SqlSugarScope Db
        {
            get { return _db; }
            private set { _db = value; }
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        /// 数据库类型
        /// Student.Achieve
        /// </summary>
        public static DbType DbType
        {
            get { return _dbType; }
            set { _dbType = value; }
        }

        public MyDbContext(ISqlSugarClient sqlSugarClient)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentNullException("数据库连接字符串为空");
            }
            _db = sqlSugarClient as SqlSugarScope;
        }

        #region 实例方法

        /// <summary>
        /// 功能描述:获取数据库处理对象
        /// </summary>
        /// <returns>返回值</returns>
        public SimpleClient<T> GetEntityDB<T>() where T : class, new()
        {
            return new SimpleClient<T>(_db);
        }

        /// <summary>
        /// 功能描述:获取数据库处理对象
        /// </summary>
        /// <param name="db">db</param>
        /// <returns>返回值</returns>
        public SimpleClient<T> GetEntityDB<T>(SqlSugarClient db) where T : class, new()
        {
            return new SimpleClient<T>(db);
        }

        #endregion 实例方法
    }
}