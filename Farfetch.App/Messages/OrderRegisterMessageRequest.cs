using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Farfetch.App.Messages
{
    [DataContract]
    public class OrderRegisterMessageRequest : BaseRequest
    {
        [DataMember(Name = "descriptionProduto")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string DescriptionProduto { get; set; }
    }
}
