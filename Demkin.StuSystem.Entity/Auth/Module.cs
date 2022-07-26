using SqlSugar;

namespace Demkin.StuSystem.Entity.Auth
{
    /// <summary>
    /// 菜单模块表
    /// </summary>
    [SugarTable("Auth_Module")]
    public class Module : EntityTimeBase<long>
    {
        /// <summary>
        /// 父级Id
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public long? ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = false)]
        public string ModuleName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 菜单链接地址
        /// </summary>
        [SugarColumn(Length = 255, IsNullable = false)]
        public string LinkUrl { get; set; }

        /// <summary>
        /// /描述
        /// </summary>
        [SugarColumn(Length = 255, IsNullable = true)]
        public string Description { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool Enabled { get; set; }
    }
}