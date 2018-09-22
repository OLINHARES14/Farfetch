using System;
using System.ComponentModel.DataAnnotations;

namespace Farfetch.Domain.Models.Entities
{
    public class ServiceRotaToggle
    {
        [Key]
        public int Id { get; set; }

        public string Rota { get; set; }

        public bool Active { get; set; }   
        
        public Toggle Toggle { get; set; }
    }
}
