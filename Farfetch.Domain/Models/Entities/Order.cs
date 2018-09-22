using System;
using System.ComponentModel.DataAnnotations;

namespace Farfetch.Domain.Models.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Toggle Togle { get; set; }
        public ServiceRota Rota { get; set; }        
        public DateTime CreationDate { get; set; }
    }
}
