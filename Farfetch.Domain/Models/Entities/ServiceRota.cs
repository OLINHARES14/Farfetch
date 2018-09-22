using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Farfetch.Domain.Models.Entities
{
    public class ServiceRota
    {
        [Key]
        public int Id { get; set; }

        public string Authorization { get; set; }

        public string Rota { get; set; }

        public bool Active { get; set; }

        public List<ToggleServiceRota> ToggleServiceRotas { get; set; } = new List<ToggleServiceRota>();
    }
}
