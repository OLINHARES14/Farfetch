using Farfetch.Infra.Cross.Helpers;
using System;
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

        private string CreationDateField
        {
            get
            {
                return CreationDate.ToString(ServiceConstants.DATE_FORMAT);
            }
            set
            {
                CreationDate = DateTime.ParseExact(value, ServiceConstants.DATE_FORMAT, null);
            }
        }

        public DateTime CreationDate { get; set; }        
    }
}
