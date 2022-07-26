using System.ComponentModel;

namespace Demkin.StuSystem.Enum
{
    public enum Gender
    {
        [Description("男")]
        male = 0,

        [Description("女")]
        female = 1,

        [Description("未知")]
        unknow = 2,
    }
}