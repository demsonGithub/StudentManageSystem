using SqlSugar;

namespace Demkin.StuSystem.Entity.Auth
{
    /// <summary>
    /// 角色权限关系表
    /// </summary>
    [SugarTable("Auth_RoleModulePermission")]
    public class RoleModulePermission : EntityBase<long>
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public long ModuleId { get; set; }

        /// <summary>
        /// 路由ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public long? PermissionId { get; set; }
    }
}