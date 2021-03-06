﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Farfetch.App.Messages
{
    [DataContract]
    public class ServiceRotaCreateMessageRequest : BaseRequest
    {
        [DataMember(Name = "rota")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Rota { get; set; }
    }
}
