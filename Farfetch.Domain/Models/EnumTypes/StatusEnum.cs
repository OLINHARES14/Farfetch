using System.Runtime.Serialization;

namespace Farfetch.Domain.Models.EnumTypes
{
    public enum StatusEnum
    {
        [EnumMember]
        Active = 1,

        [EnumMember]
        Inactive = 2
    }
}
