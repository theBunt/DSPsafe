using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace DSPsafe.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [DisplayName("Employee type")]
        public string EmpType { get; set; }
       
        public string Phone { get; set; }
        public int ManagerId { get; set; }
        [DisplayName("Safety Role")]
        public string SafetyRole { get; set; }
        public string Area { get; set; }
        public int LocationId { get; set; }
        //public virtual SafetyDetail SafetyRep { get; set; }
        //public virtual Location BuildingArea { get; set; }
        public virtual ICollection<Incident> Incidents { get; set; }
        public virtual ICollection<Location> Buildings { get; set; }
        //public virtual ICollection<Staff> Managers { get; set; }
    }
}