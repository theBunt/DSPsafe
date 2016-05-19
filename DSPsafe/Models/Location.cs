using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSPsafe.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Region { get; set; }
        public string Building { get; set; }
        

        public virtual ICollection<Incident> Incidents { get; set; }
        public virtual Staff Employees { get; set; }
    }
}