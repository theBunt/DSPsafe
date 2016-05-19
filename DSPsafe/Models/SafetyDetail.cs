using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DSPsafe.Models
{
    public class SafetyDetail
    {
        public int SafetyDetailId;
        //[ForeignKey("Staff")]
        public int StaffId { get; set; }
        //[ForeignKey("Locations")]
        public int LocationId { get; set; }
        public string Role { get; set; }
        public string Area { get; set; }

        //public virtual ICollection<Staff> Details { get; set; }
        public virtual Staff Staff { get; set; }
        //public virtual ICollection<Location> Locations { get; set; }
        public virtual Location Location { get; set; }

    }
}