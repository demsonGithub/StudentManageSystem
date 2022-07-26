using SqlSugar;

namespace Demkin.StuSystem.Entity.Auth
{
    /// <summary>
    /// 角色关系
    /// </summary>
    [SugarTable("Auth_UserRole")]
    public class UserRole : EntityBase<long>
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public long RoleId { get; set; }
    }
}