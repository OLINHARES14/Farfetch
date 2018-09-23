using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Farfetch.Domain.Models.Entities
{
    public class Toggle
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Flag { get; set; }

        public bool Active { get; set; }
        
        public List<ToggleServiceRota> ToggleServiceRotas { get; set; } = new List<ToggleServiceRota>();
    }
}
