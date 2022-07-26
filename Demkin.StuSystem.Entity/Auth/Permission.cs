using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demkin.StuSystem.Entity.Auth
{
    /// <summary>
    /// 路由表
    /// </summary>
    [SugarTable("Auth_Permission")]
    public class Permission : EntityTimeBase<long>
    {
        /// <summary>
        /// 显示名（如用户页、编辑(按钮)、删除(按钮)）
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = false)]
        public string Name { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string Icon { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string Description { get; set; }

        /// <summary>
        /// 对应的action名称
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = false)]
        public string ActionCode { get; set; }

        /// <summary>
        /// 对应模块Id
        /// </summary>
        public long ModuleId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 激活状态
        /// </summary>
        public bool Enabled { get; set; }
    }
}