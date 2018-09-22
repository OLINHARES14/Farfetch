using System.ComponentModel.DataAnnotations;

namespace Farfetch.Domain.Models.Entities
{
    public class ToggleServiceRota
    {
        [Key]
        public int Id { get; set; }

        public int ToggleId { get; set; }

        public int ServiceRotaId { get; set; }

        public Toggle Toggle { get; set; }

        public ServiceRota ServiceRota { get; set; }
    }
}
