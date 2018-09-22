using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Farfetch.Domain.Models.Entities
{
    public class ServiceRota
    {
        [Key]
        public int Id { get; set; }
        public string Rota { get; set; }
        public bool Active { get; set; }
        //private string UpdateDateField
        //{
        //    get
        //    {
        //        return UpdateDate.ToString(ServiceConstants.DATE_FORMAT);
        //    }
        //    set
        //    {
        //        UpdateDate = DateTime.ParseExact(value, ServiceConstants.DATE_FORMAT, null);
        //    }
        //}
        public List<ToggleServiceRota> Toggles { get; set; } = new List<ToggleServiceRota>();

        public DateTime UpdateDate { get; set; }        
    }
}
