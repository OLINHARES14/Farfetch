using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Farfetch.App.Messages
{
    [DataContract]
    public class ServiceRotaUpdateMessageRequest
    {
        [DataMember(Name = "rota")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Rota { get; set; }
    }
}
