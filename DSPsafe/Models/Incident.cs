using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSPsafe.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }
        [DisplayName("Type of Incident")]
        public string TypeOfIncident  { get; set; }
        //public string [] Injuries { get; set; }
        [DisplayName("Staff or Public")]
        public bool StaffIncident { get; set; }
        [DisplayName("Home Visit")]
        public bool HomeVisitIncident { get; set; }
        [DisplayName("Brief Description")]
        public string BriefDesc { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Incident")]
        public DateTime DateOccurred { get; set; }
        public int StaffId { get; set; }
        public int LocationId { get; set; }

        public virtual Staff StaffReportee { get; set; }
        public virtual Location WhereHappened { get; set; }
    }
}