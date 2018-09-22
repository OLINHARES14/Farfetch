using System;
using System.ComponentModel.DataAnnotations;

namespace Farfetch.Domain.Models.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Protocol { get; set; }

        public string DescriptionToggle { get; set; }
        
        public string DescriptionServiceRota { get; set; }

        public string DescriptionProduto { get; set; }
    }
}
