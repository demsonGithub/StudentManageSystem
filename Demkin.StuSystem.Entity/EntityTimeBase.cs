using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demkin.StuSystem.Entity
{
    public class EntityTimeBase<Tkey> : EntityBase<Tkey> where Tkey : IEquatable<Tkey>
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? ModifyTime { get; set; } = DateTime.Now;

        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsDeleted { get; set; } = false;
    }
}