using SqlSugar;
using System;

namespace Demkin.StuSystem.Entity
{
    public class EntityBase<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 泛型ID主键 Tkey
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true)]
        public TKey Id { get; set; }
    }
}