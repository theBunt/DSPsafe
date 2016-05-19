using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DSPsafe.Models;

namespace DSPsafe.DAL
{
    public class SafetyInitializer : System.Data.Entity.DropCreateDatabaseAlways<SafetyContext>
    {
        protected override void Seed(SafetyContext context)
        {
            var employees = new List<Staff>
            {
            new Staff{FirstName="First",LastName="Initializer",Email="carson@vvf",EmpType="emp",Phone="5343"},
            new Staff{FirstName="Meredith",LastName="Alonso",Email="Meredith@dsp.mail",EmpType="emp",Phone="3877"},
            new Staff{FirstName="Arturo",LastName="Anand",Email="Arturo@dsp.mail",EmpType="emp",Phone="3544"},
            new Staff{FirstName="Gytis",LastName="Barzdukas",Email="Gytis@dsp.mail",EmpType="mngr",Phone="3535"},
            new Staff{FirstName="Yan",LastName="Li",Email="Yan@dsp.mail",EmpType="emp",Phone="8788"},
            new Staff{FirstName="Peggy",LastName="Justice",Email="Peggy@dsp.mail",EmpType="emp",Phone="3598"},
            new Staff{FirstName="Laura",LastName="Norman",Email="Laura@dsp.mail",EmpType="emp",Phone="4125"},
            new Staff{FirstName="Nino",LastName="Olivetto",Email="Nino@dsp.mail",EmpType="mngr",Phone="9652"},
            new Staff{FirstName="Alan",LastName="Byrne",Email="carson@vvf",EmpType="emp",Phone="8521"},
            new Staff{FirstName="Kim",LastName="Butler",Email="Kim@dsp.mail",EmpType="emp",Phone="7745"},
            new Staff{FirstName="Arthur",LastName="Smith",Email="Arthur@dsp.mail",EmpType="emp",Phone="5218"},
            new Staff{FirstName="Kieth",LastName="Barry",Email="Kieth@dsp.mail",EmpType="emp",Phone="6321"},
            new Staff{FirstName="Greg",LastName="Lilly",Email="Greg@dsp.mail",EmpType="emp",Phone="4589"},
            new Staff{FirstName="Peggy",LastName="Hope",Email="Peggy@dsp.mail",EmpType="mngr",Phone="6674"},
            new Staff{FirstName="Laura",LastName="Colt",Email="Laura@dsp.mail",EmpType="emp",Phone="4425"},
            new Staff{FirstName="Oliver",LastName="Vitto",Email="Oliver@dsp.mail",EmpType="emp",Phone="8278"}
            };
            employees.ForEach(s => context.Staff.Add(s));
            context.SaveChanges();

            var locations = new List<Location>
            {
                new Location {Region="North",Building="Marcus House", },
                new Location {Region="North",Building="Queen st", },
                new Location {Region="North",Building="Brunswick Ave.", },
                new Location {Region="North",Building="Thomas Lane", },
                new Location {Region="North",Building="Harrow St.", },
                new Location {Region="North",Building="Kelly House", },
                new Location {Region="North",Building="Frederick Hall", },
                new Location {Region="North",Building="Green St.", },
                new Location {Region="South",Building="Frederick Hall", },
                new Location {Region="South",Building="Kelly House", },
                new Location {Region="South",Building="Barry House", },
                new Location {Region="South",Building="Smith CQ", },
                new Location {Region="South",Building="IGGH Hall", },
                new Location {Region="South",Building="Tony Row", },
                new Location {Region="South",Building="Kilkenny Rd.", },
                new Location {Region="South",Building="Cork Rd.", },
                new Location {Region="South",Building="Arrow Hall", },
                new Location {Region="East",Building="Xavi St.", },
                new Location {Region="East",Building="Qwerty House", },
                new Location {Region="East",Building="Frederick Hall", },
                new Location {Region="East",Building="Greer House", },
                new Location {Region="East",Building="Peter St.", },
                new Location {Region="East",Building="Kelly House", },
                new Location {Region="East",Building="Barry House", },
                new Location {Region="East",Building="Connacht ", },
                new Location {Region="East",Building="Liffey ", },
                new Location {Region="West",Building="Arrow Rd.", },
                new Location {Region="West",Building="Murphy House", },
                new Location {Region="West",Building="Kelly House", },
                new Location {Region="West",Building="Barry House", },
                new Location {Region="West",Building="Green lane", },
                new Location {Region="West",Building="Harrow St.", },

            };
            locations.ForEach(l => context.Locations.Add(l));
            context.SaveChanges();

            var inc = new List<Incident>
            {
                new Incident {TypeOfIncident="Threat", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-09-01"), StaffId = 1, LocationId = 2},
                new Incident {TypeOfIncident="Damage", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2015-10-12"), StaffId = 2, LocationId = 1},
                new Incident {TypeOfIncident="Assault", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-05-25"), StaffId = 3, LocationId = 12},
                new Incident {TypeOfIncident="Slip", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-06-09"), StaffId = 4, LocationId = 5},
                new Incident {TypeOfIncident="Threat", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-09-18"), StaffId = 5, LocationId = 22},
                new Incident {TypeOfIncident="Threat", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2015-01-12"), StaffId = 6, LocationId = 18},
                new Incident {TypeOfIncident="Manual Handling", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-11-01"), StaffId = 7, LocationId = 16},
                new Incident {TypeOfIncident="Threat", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-12-01"), StaffId = 1, LocationId = 21},
                new Incident {TypeOfIncident="Slip", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2015-09-05"), StaffId = 3, LocationId = 2},
                new Incident {TypeOfIncident="Slip", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-07-09"), StaffId = 8, LocationId = 8},
                new Incident {TypeOfIncident="Damage", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-04-14"), StaffId = 4, LocationId = 14},
                new Incident {TypeOfIncident="Threat", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-09-16"), StaffId = 2, LocationId = 9},
                new Incident {TypeOfIncident="Slip", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-05-28"), StaffId = 1, LocationId = 7},
                new Incident {TypeOfIncident="Assault", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-09-03"), StaffId = 5, LocationId = 17},
                new Incident {TypeOfIncident="Threat", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-08-05"), StaffId = 1, LocationId = 2},
                new Incident {TypeOfIncident="Damage", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2015-11-14"), StaffId = 2, LocationId = 1},
                new Incident {TypeOfIncident="Assault", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-02-21"), StaffId = 3, LocationId = 16},
                new Incident {TypeOfIncident="Threat", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-04-09"), StaffId = 4, LocationId = 15},
                new Incident {TypeOfIncident="Manual Handling", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-05-18"), StaffId = 5, LocationId = 20},
                new Incident {TypeOfIncident="Threat", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2015-06-08"), StaffId = 6, LocationId = 4},
                new Incident {TypeOfIncident="Slip", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-11-06"), StaffId = 7, LocationId = 5},
                new Incident {TypeOfIncident="Threat", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-08-01"), StaffId = 1, LocationId = 6},
                new Incident {TypeOfIncident="Slip", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2015-09-15"), StaffId = 3, LocationId = 12},
                new Incident {TypeOfIncident="Damage", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-08-09"), StaffId = 8, LocationId = 18},
                new Incident {TypeOfIncident="Slip", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-04-13"), StaffId = 4, LocationId = 4},
                new Incident {TypeOfIncident="Manual Handling", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-09-16"), StaffId = 2, LocationId = 19},
                new Incident {TypeOfIncident="Damage", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-05-28"), StaffId = 1, LocationId = 17},
                new Incident {TypeOfIncident="Slip", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-09-03"), StaffId = 5, LocationId = 7}
            };
            inc.ForEach(l => context.Incidents.Add(l));
            context.SaveChanges();

            //var safe = new List<SafetyDetail>
            //{
            //    new SafetyDetail {StaffId = 2 , LocationId = 4, Area = "Front Desk" , Role = "First Aid" },
            //    new SafetyDetail {StaffId = 4 , LocationId = 3, Area = "Ground floor" , Role = "First Aid" },
            //    new SafetyDetail {StaffId = 5 , LocationId = 3, Area = "Canteen" , Role = "Fire Marshal" },
            //    new SafetyDetail {StaffId = 4 , LocationId = 2, Area = "Top floor" , Role = "First Aid" },
            //    new SafetyDetail {StaffId = 9 , LocationId = 4, Area = "Floor 2" , Role = "First Aid" },
            //    new SafetyDetail {StaffId = 3 , LocationId = 4, Area = "Top floor" , Role = "Fire Marshal" },
            //    new SafetyDetail {StaffId = 7 , LocationId = 8, Area = "Top floor" , Role = "First Aid" },
            //    new SafetyDetail {StaffId = 11 , LocationId = 12, Area = "Ground floor" , Role = "First Aid" },
            //    new SafetyDetail {StaffId = 10 , LocationId = 14, Area = "Canteen" , Role = "Fire Marshal" },
            //    new SafetyDetail {StaffId = 1 , LocationId = 24, Area = "Reception" , Role = "First Aid" },
            //    new SafetyDetail {StaffId = 9 , LocationId = 28, Area = "Office 2" , Role = "First Aid" },
            //    new SafetyDetail {StaffId = 3 , LocationId = 21, Area = "Liffey Room" , Role = "Fire Marshal" }
            //};

            //safe.ForEach(s => context.SafetyDetails.Add(s));
            //context.SaveChanges();

        }
    }
}