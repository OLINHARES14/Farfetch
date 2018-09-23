using System.Runtime.Serialization;

namespace Farfetch.App.Messages
{
    [DataContract]
    public class ServiceRotaMessageResponse
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "rota")]
        public string Rota { get; set; }

        [DataMember(Name = "authorization")]
        public string Authorization { get; set; }

        [DataMember(Name = "active")]
        public bool Active { get; set; }
    }
}