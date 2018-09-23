using System.Runtime.Serialization;

namespace Farfetch.App.Messages
{
    [DataContract]
    public class OrderRegisterMessageResponse
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "protocol")]
        public string Protocol { get; set; }

        [DataMember(Name = "descriptionToggle")]
        public string DescriptionToggle { get; set; }

        [DataMember(Name = "descriptionServiceRota")]
        public string DescriptionServiceRota { get; set; }

        [DataMember(Name = "descriptionProduto")]
        public string DescriptionProduto { get; set; }
    }
}