namespace DSPsafe.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var employees = new List<Staff>
            {
            new Staff{FirstName="Loon",LastName="Paul",Email="Paul@dspmail",EmpType="emp",Phone="5343", LocationId = 1, SafetyRole = "First Aid", ManagerId = 8, Area = "Top floor"},
            new Staff{FirstName="Meredith",LastName="Alonso",Email="Alonso@dsp.mail",EmpType="emp",Phone="3877", LocationId = 18, SafetyRole = "Safety Rep", ManagerId = 4, Area = "Reception"},
            new Staff{FirstName="Arturo",LastName="Anand",Email="Anand@dsp.mail",EmpType="emp",Phone="3544", LocationId = 9, SafetyRole = "First Aid", ManagerId = 8, Area = "Head office"},
            new Staff{FirstName="Gytis",LastName="Barzdukas",Email="Barzdukas@dsp.mail",EmpType="mngr",Phone="3535", LocationId = 12, SafetyRole = "Fire Marshal", Area = "1st floor"},
            new Staff{FirstName="Yan",LastName="Li",Email="Li@dsp.mail",EmpType="emp",Phone="8788", LocationId = 6, SafetyRole = "First Aid", ManagerId = 8, Area = "2nd floor"},
            new Staff{FirstName="Peggy",LastName="Justice",Email="Justice@dsp.mail",EmpType="emp",Phone="3598", LocationId = 21, SafetyRole = "Fire Marshal", ManagerId = 4, Area = "1st floor"},
            new Staff{FirstName="Laura",LastName="Norman",Email="Norman@dsp.mail",EmpType="emp",Phone="4125", LocationId = 6, SafetyRole = "Safety Rep", ManagerId = 8, Area = "3rd floor"},
            new Staff{FirstName="Nino",LastName="Olivetto",Email="Olivetto@dsp.mail",EmpType="mngr",Phone="9652", LocationId = 11, SafetyRole = "First Aid", ManagerId = 8, Area = "Ground floor"},
            new Staff{FirstName="Alan",LastName="Byrne",Email="Byrne@vvf",EmpType="emp",Phone="8521", LocationId = 6, SafetyRole = "First Aid", ManagerId = 8, Area = "Reception"},
            new Staff{FirstName="Kim",LastName="Butler",Email="Butler@dsp.mail",EmpType="emp",Phone="7745", LocationId = 6, SafetyRole = "First Aid", ManagerId = 4, Area = "Back office"},
            new Staff{FirstName="Arthur",LastName="Smith",Email="Smith@dsp.mail",EmpType="emp",Phone="5218", LocationId = 6, SafetyRole = "Fire Marshal", ManagerId = 8, Area = "Reception"},
            new Staff{FirstName="Kieth",LastName="Barry",Email="Kieth@dsp.mail",EmpType="emp",Phone="6321", LocationId = 18, SafetyRole = "First Aid", ManagerId = 8, Area = "1st floor"},
            new Staff{FirstName="Greg",LastName="Lilly",Email="Greg@dsp.mail",EmpType="emp",Phone="4589", LocationId = 4, SafetyRole = "Fire Marshal", ManagerId = 8, Area = "reception"},
            new Staff{FirstName="Peggy",LastName="Hope",Email="hope@dsp.mail",EmpType="mngr",Phone="6674", LocationId = 7, SafetyRole = "First Aid", ManagerId = 4, Area = "2nd floor"},
            new Staff{FirstName="Laura",LastName="Fulton",Email="Colt@dsp.mail",EmpType="emp",Phone="4425", LocationId = 22, SafetyRole = "First Aid", ManagerId = 8, Area = "2nd floor"},
            new Staff{FirstName="Oliver",LastName="Vitto",Email="Oliver@dsp.mail",EmpType="emp",Phone="8278", LocationId = 1, SafetyRole = null, ManagerId = 4, Area = "Reception"},
            new Staff{FirstName="Alonso",LastName="Birch",Email="birch@dsp.mail",EmpType="emp",Phone="5343", LocationId = 1, SafetyRole = null, ManagerId = 8, Area = "Top floor"},
            new Staff{FirstName="Meredith",LastName="Alan",Email="Meredith@dsp.mail",EmpType="emp",Phone="3877", LocationId = 18, SafetyRole = "Safety Rep", ManagerId = 4, Area = "Reception"},
            new Staff{FirstName="Artur",LastName="Anders",Email="Arturo@dsp.mail",EmpType="emp",Phone="3544", LocationId = 9, SafetyRole = "First Aid", ManagerId = 8, Area = "Head office"},
            new Staff{FirstName="Jim",LastName="Barthew",Email="Gytis@dsp.mail",EmpType="mngr",Phone="3535", LocationId = 12, SafetyRole = "Fire Marshal", Area = "1st floor"},
            new Staff{FirstName="Yan",LastName="Lizton",Email="Yan@dsp.mail",EmpType="emp",Phone="8788", LocationId = 6, SafetyRole = "First Aid", ManagerId = 8, Area = "2nd floor"},
            new Staff{FirstName="Liz",LastName="Justin",Email="Peggy@dsp.mail",EmpType="emp",Phone="3598", LocationId = 21, SafetyRole = null, ManagerId = 4, Area = "1st floor"},
            new Staff{FirstName="Laura",LastName="Normer",Email="Normer@dsp.mail",EmpType="emp",Phone="4125", LocationId = 16, SafetyRole = "Safety Rep", ManagerId = 8, Area = "3rd floor"},
            new Staff{FirstName="Nino",LastName="Olive",Email="Nino@dsp.mail",EmpType="mngr",Phone="9652", LocationId = 11, SafetyRole = "First Aid", ManagerId = 8, Area = "Ground floor"},
            new Staff{FirstName="Alan",LastName="Simon",Email="carson@vvf.gmail",EmpType="emp",Phone="8521", LocationId = 27, SafetyRole = "First Aid", ManagerId = 8, Area = "Reception"},
            new Staff{FirstName="Jim",LastName="Butler",Email="Jimmy@dsp.mail",EmpType="emp",Phone="7745", LocationId = 26, SafetyRole = "First Aid", ManagerId = 4, Area = "Back office"},
            new Staff{FirstName="Oliver",LastName="Smith",Email="Arthur@dsp.mail",EmpType="emp",Phone="5218", LocationId = 26, SafetyRole = "Fire Marshal", ManagerId = 8, Area = "Reception"},
            new Staff{FirstName="Norman",LastName="Barry",Email="Kietho@dsp.mail",EmpType="emp",Phone="6321", LocationId = 28, SafetyRole = "First Aid", ManagerId = 8, Area = "1st floor"},
            new Staff{FirstName="Justice",LastName="Lilly",Email="Greg@dsmail",EmpType="emp",Phone="4589", LocationId = 24, SafetyRole = "Fire Marshal", ManagerId = 8, Area = "reception"},
            new Staff{FirstName="Li",LastName="Hope",Email="Lilo@dsp.mail",EmpType="mngr",Phone="6674", LocationId = 27, SafetyRole = "First Aid", ManagerId = 4, Area = "2nd floor"},
            new Staff{FirstName="Barzdukas",LastName="Colt",Email="Laura@dsmail",EmpType="emp",Phone="4425", LocationId = 29, SafetyRole = "First Aid", ManagerId = 8, Area = "2nd floor"},
            new Staff{FirstName="Anand",LastName="Vitto",Email="Oliver@dsmail",EmpType="emp",Phone="8278", LocationId = 29, SafetyRole = "Fire Marshal", ManagerId = 4, Area = "Reception"},
            new Staff{FirstName="Fred",LastName="Smith",Email="Arthur@dmail",EmpType="emp",Phone="5218", LocationId = 26, SafetyRole = "Fire Marshal", ManagerId = 8, Area = "Reception"},
            new Staff{FirstName="Barry",LastName="Scott",Email="Kieth@dmail",EmpType="emp",Phone="6321", LocationId = 1, SafetyRole = "First Aid", ManagerId = 8, Area = "1st floor"},
            new Staff{FirstName="Scot",LastName="Holt",Email="Greg@dgmail",EmpType="emp",Phone="4589", LocationId = 1, SafetyRole = null, ManagerId = 8, Area = "reception"},
            new Staff{FirstName="Linda",LastName="Hope",Email="linda@dsp.mail",EmpType="mngr",Phone="6674", LocationId = 1, SafetyRole = null, ManagerId = 4, Area = "2nd floor"},
            new Staff{FirstName="brendan",LastName="Arlen",Email="Arlen@gmail",EmpType="emp",Phone="4425", LocationId = 1, SafetyRole = null, ManagerId = 8, Area = "2nd floor"},
            new Staff{FirstName="Reg",LastName="Gertez",Email="Oliver@gmail",EmpType="emp",Phone="8278", LocationId = 1, SafetyRole = null, ManagerId = 4, Area = "Reception"}
            };
            employees.ForEach(s => context.Staff.Add(s));
            context.SaveChanges();
            CreateManagerRoleAndPopuate(context);
            CreateStaffRoleAndPopulate(context);

            var locations = new List<Location>
            {
                new Location {Region="North",Building="Marcus House", },
                new Location {Region="North",Building="Queen st", },
                new Location {Region="North",Building="Brunswick Ave.", },
                new Location {Region="North",Building="Thomas Lane", },
                new Location {Region="North",Building="Harrow St.", },
                new Location {Region="North",Building="Barrow House", },
                new Location {Region="North",Building="Frederick Hall", },
                new Location {Region="North",Building="Green St.", },
                new Location {Region="South",Building="Frederick Hall", },
                new Location {Region="South",Building="Kelly House", },
                new Location {Region="South",Building="Barry House", },
                new Location {Region="South",Building="Smith CQ", },
                new Location {Region="South",Building="IGGH House", },
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
                new Incident {TypeOfIncident="Threat", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-09-01"),
                    BriefDesc = "Lorem ipsum convallis vel etiam eleifend ultrices nec duis imperdiet, augue taciti vulputate commodo gravida tortor dapibus elementum netus justo proin nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 1, LocationId = 2},
                new Incident {TypeOfIncident="Damage", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2015-10-12"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 2, LocationId = 1},
                new Incident {TypeOfIncident="Assault", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-05-25"),
                    BriefDesc = "Lorem ipsum convallis vel etiam eleifend ultrices nec duis imperdiet, augue taciti vulputate commodo gravida tortor dapibus elementum netus justo proin nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 3, LocationId = 12},
                new Incident {TypeOfIncident="Slip", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-06-09"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 4, LocationId = 5},
                new Incident {TypeOfIncident="Threat", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-09-18"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 5, LocationId = 22},
                new Incident {TypeOfIncident="Threat", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2015-01-12"),
                    BriefDesc = "Lorem ipsum convallis vel etiam eleifend ultrices nec duis imperdiet, augue taciti vulputate commodo gravida tortor dapibus elementum netus justo proin nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 6, LocationId = 18},
                new Incident {TypeOfIncident="Manual Handling", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-11-01"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 7, LocationId = 16},
                new Incident {TypeOfIncident="Threat", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-12-01"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 1, LocationId = 21},
                new Incident {TypeOfIncident="Slip", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2015-09-05"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 3, LocationId = 2},
                new Incident {TypeOfIncident="Slip", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-07-09"),
                    BriefDesc = "Lorem ipsum convallis vel etiam eleifend ultrices nec duis imperdiet, augue taciti vulputate commodo gravida tortor dapibus elementum netus justo proin nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 8, LocationId = 8},
                new Incident {TypeOfIncident="Damage", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-04-14"),
                    BriefDesc = "Lorem ipsum convallis vel etiam eleifend ultrices nec duis imperdiet, augue taciti vulputate commodo gravida tortor dapibus elementum netus justo proin nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 4, LocationId = 14},
                new Incident {TypeOfIncident="Threat", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-09-16"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 2, LocationId = 9},
                new Incident {TypeOfIncident="Slip", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-05-28"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 1, LocationId = 7},
                new Incident {TypeOfIncident="Assault", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-09-03"),
                    BriefDesc = "Lorem ipsum convallis vel etiam eleifend ultrices nec duis imperdiet, augue taciti vulputate commodo gravida tortor dapibus elementum netus justo proin nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 5, LocationId = 17},
                new Incident {TypeOfIncident="Threat", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-08-05"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 1, LocationId = 2},
                new Incident {TypeOfIncident="Damage", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2015-11-14"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 2, LocationId = 1},
                new Incident {TypeOfIncident="Assault", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-02-21"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 3, LocationId = 16},
                new Incident {TypeOfIncident="Threat", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-04-09"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 4, LocationId = 15},
                new Incident {TypeOfIncident="Manual Handling", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-05-18"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 5, LocationId = 20},
                new Incident {TypeOfIncident="Threat", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2015-06-08"),
                    BriefDesc = "Lorem ipsum convallis vel etiam eleifend ultrices nec duis imperdiet, augue taciti vulputate commodo gravida tortor dapibus elementum netus justo proin nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 6, LocationId = 4},
                new Incident {TypeOfIncident="Slip", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-11-06"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 7, LocationId = 5},
                new Incident {TypeOfIncident="Threat", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-08-01"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 1, LocationId = 6},
                new Incident {TypeOfIncident="Slip", StaffIncident = true, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2015-09-15"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 3, LocationId = 12},
                new Incident {TypeOfIncident="Damage", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-08-09"),
                    BriefDesc = "Lorem ipsum convallis vel etiam eleifend ultrices nec duis imperdiet, augue taciti vulputate commodo gravida tortor dapibus elementum netus justo proin nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 8, LocationId = 18},
                new Incident {TypeOfIncident="Slip", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-04-13"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 4, LocationId = 4},
                new Incident {TypeOfIncident="Manual Handling", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-09-16"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 2, LocationId = 19},
                new Incident {TypeOfIncident="Damage", StaffIncident = false, HomeVisitIncident = false, DateOccurred = DateTime.Parse("2016-05-28"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 1, LocationId = 17},
                new Incident {TypeOfIncident="Slip", StaffIncident = true, HomeVisitIncident = true, DateOccurred = DateTime.Parse("2016-09-03"),
                    BriefDesc = "Lorem ipsum convallis  imperdiet, augue taciti vulputate commodo gravida tortor dapibus nec facilisis conubia posuere inceptos ante mattis malesuadaHabitant purus vitae et purus pharetra consectetur vel sapien eget ad, etiam aliquet sociosqu varius phasellus tortor morbi semper."
                    , StaffId = 5, LocationId = 7}
            };
            inc.ForEach(l => context.Incidents.Add(l));
            context.SaveChanges();
        }

        public void CreateManagerRoleAndPopuate(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            const string ManagerRole = "Manager";

            var userRole = new IdentityRole { Name = ManagerRole, Id = Guid.NewGuid().ToString() };
            context.Roles.Add(userRole);

            PasswordHasher pass = new PasswordHasher();
            foreach (var staff in context.Staff)
            {
                if (staff.EmpType == "mngr")
                {
                    var user = new ApplicationUser
                    {
                        StaffId = staff.StaffId,
                        UserName = staff.Email,
                        Email = staff.Email,
                        PasswordHash = pass.HashPassword("PassWord1'"),
                        SecurityStamp = Guid.NewGuid().ToString()
                    };
                    user.Roles.Add(new IdentityUserRole { RoleId = userRole.Id, UserId = user.Id });
                    context.Users.Add(user);
                    base.Seed(context);
                }
            }
        }

        public void CreateStaffRoleAndPopulate(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            const string CustomerRole = "Staff";

            var userRole = new IdentityRole { Name = CustomerRole, Id = Guid.NewGuid().ToString() };
            context.Roles.Add(userRole);

            PasswordHasher pass = new PasswordHasher();
            foreach (var staff in context.Staff)
            {
                if (staff.EmpType == "emp")
                {
                    var user = new ApplicationUser
                    {
                        StaffId = staff.StaffId,
                        UserName = staff.Email,
                        Email = staff.Email,
                        PasswordHash = pass.HashPassword("PassWord1'"),
                        SecurityStamp = Guid.NewGuid().ToString()
                    };


                    user.Roles.Add(new IdentityUserRole { RoleId = userRole.Id, UserId = user.Id });
                    context.Users.Add(user);
                    base.Seed(context);
                }
            }
        }
    }
}


