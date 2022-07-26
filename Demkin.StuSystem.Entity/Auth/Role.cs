using SqlSugar;

namespace Demkin.StuSystem.Entity.Auth
{
    [SugarTable("Auth_Role")]
    public class Role : EntityBase<long>
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [SugarColumn(Length = 50)]
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 100)]
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