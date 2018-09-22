using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Farfetch.App.Messages
{
    [DataContract]
    public class ToggleMessageResponse
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
                
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "flag")]
        public bool Flag { get; set; }

        [DataMember(Name = "active")]
        public bool Active { get; set; }

        [DataMember(Name = "serviceRotas")]
        public List<ServiceRota> ServiceRotas { get; set; }
    }
}
