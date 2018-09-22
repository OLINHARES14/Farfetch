using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Farfetch.App.Messages
{
    [DataContract]
    public class ToggleCreateMessageRequest
    {
        [DataMember(Name = "description")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Description { get; set; }

        [DataMember(Name = "flag")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Flag { get; set; }

        [DataMember(Name = "idsServiceRota")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public List<int> IdsServiceRota { get; set; }
    }
}
