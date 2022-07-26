using Demkin.StuSystem.Enum;
using SqlSugar;
using System;

namespace Demkin.StuSystem.Entity.Auth
{
    [SugarTable("Auth_SysUser")]
    public class SysUser : EntityBase<long>
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 60)]
        public string LoginAccount { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 60)]
        public string LoginPwd { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 60)]
        public string NickName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 60)]
        public string RealName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 255)]
        public string Address { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true, Length = int.MaxValue)]
        public string Remark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateTime { get; set; } = new DateTime();

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifyTime { get; set; } = new DateTime();

        /// <summary>
        /// 错误次数
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int ErrorCount { get; set; }

        /// <summary>
        /// 最后登录错误时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime LastErrTime { get; set; }
    }
}