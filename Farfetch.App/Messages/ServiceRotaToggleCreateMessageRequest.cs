using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Farfetch.App.Messages
{
    [DataContract]
    public class ServiceRotaToggleCreateMessageRequest
    {
        [DataMember(Name = "rota")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Rota { get; set; }

        [DataMember(Name = "toggleId")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int toggleId { get; set; }
    }
}
