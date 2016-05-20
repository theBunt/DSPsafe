using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSPsafe.DAL;
using DSPsafe.Models;

namespace DSPsafe.Controllers
{
    public class IncidentsController : Controller
    {
        private SafetyContext db = new SafetyContext();

        private SelectList types = new SelectList(new[]
                                          {
                                              new {ID="Damage",Name="Damage"},
                                              new{ID="Assault",Name="Assault"},
                                              new{ID="Threat",Name="Threat"},
                                              new {ID="Slip/Trip/Fall",Name="Slip/Trip/Fall"},
                                              new{ID="Manual Handling",Name="Manual Handling"}
                                          },
                            "ID", "Name", 1);

        private SelectList regions = new SelectList(new[]
                                          {
                                              new {ID="North",Name="North"},
                                              new{ID="South",Name="South"},
                                              new{ID="East",Name="East"},
                                              new{ID="West",Name="West"}
                                      },
                        "ID", "Name", 1);

        // GET: Incidents
        public ActionResult Index(string sortOrder, string searchStringRegion, string searchStringType)
        {

            var incidents = db.Incidents.Include(i => i.StaffReportee).Include(i => i.WhereHappened);
            ViewBag.searchStringRegion = regions;
            ViewBag.searchStringType = types;
            ViewBag.NameSort = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.DateSort = String.IsNullOrEmpty(sortOrder) ? "Date_desc" : "";


            switch (sortOrder)
            {
                case "name_desc":
                    incidents = incidents.OrderByDescending(i => i.StaffReportee.LastName);
                    break;
                case "Name":
                    incidents = incidents.OrderBy(i => i.StaffReportee.LastName);
                    break;
                case "Date":
                    incidents = incidents.OrderByDescending(i => i.DateOccurred);
                    break;
                default:
                    incidents = incidents.OrderBy(i => i.DateOccurred);
                    break;
            }

            var searchString = "";
            var searchType = 0;

            if (!String.IsNullOrEmpty(searchStringRegion) && String.IsNullOrEmpty(searchStringType))
            {
                searchString = searchStringRegion.ToString();
                searchType = 1;
            }
            else if (String.IsNullOrEmpty(searchStringRegion) && !String.IsNullOrEmpty(searchStringType))
            {
                searchString = searchStringType.ToString();
                searchType = 2;
            }
            else if (!String.IsNullOrEmpty(searchStringRegion) && !String.IsNullOrEmpty(searchStringType))
            {
                searchString = (searchStringRegion + "," + searchStringType).ToString(); 
                searchType = 3;
            }


            //var query = from loc in db.Locations
            //            join inc in db.Incidents on loc.LocationId equals inc.LocationId
            //            select new
            //            {
            //                StaffLast = inc.StaffReportee.LastName,
            //                Stafffirst = inc.StaffReportee.FirstName,
            //                Building = loc.Building,
            //                WhereHappened = inc.LocationId,
            //                StaffIncident = inc.StaffIncident,
            //                HomeVisit = inc.HomeVisitIncident,
            //                Description = inc.BriefDesc,
            //                DateHappened = inc.DateOccurred,
            //                TypeIncident = inc.TypeOfIncident,
            //                Place = loc.Region
            //            };

            //IEnumerable<object> incidents = query;

            switch (searchType)
            {
                case 1:
                    incidents = incidents.Where(i => i.WhereHappened.Region.Equals(searchStringRegion));
                    break;

                case 2:
                    incidents = incidents.Where(i => i.TypeOfIncident.Equals(searchStringType));
                    break;

                case 3:
                    incidents = incidents.Where(i => i.WhereHappened.Region.Equals(searchStringRegion) && (i.TypeOfIncident.Equals(searchStringType)));
                    break;
            }
            return View(incidents.ToList());
        }

        // GET: Incidents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = db.Incidents.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // GET: Incidents/Create
        public ActionResult Create()
        {
            ViewBag.TypeOfIncident = types;
            ViewBag.StaffId = new SelectList(db.Staff, "StaffId", "LastName");
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Region");
            ViewBag.Region = new SelectList(new[]
                                          {
                                              new {ID="North",Name="North"},
                                              new{ID="South",Name="South"},
                                              new{ID="East",Name="East"},
                                              new{ID="West",Name="West"}
                                          },
                            "ID", "Name", 1);
            ViewBag.Building = new SelectList(db.Locations, "LocationId", "Building");
            return View();
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "IncidentId,TypeOfIncident,StaffIncident,HomeVisitIncident,BriefDesc,DateOccurred,StaffId,LocationId")] Incident incident)
        public ActionResult Create([Bind(Include = "IncidentId,TypeOfIncident,StaffIncident,HomeVisitIncident,BriefDesc,DateOccurred,LocationId")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                db.Incidents.Add(incident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffId = new SelectList(db.Staff, "StaffId", "LastName", incident.StaffId);
            ViewBag.Building = new SelectList(db.Locations, "LocationId", "Region", incident.LocationId);


            return View(incident);
        }

        // GET: Incidents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = db.Incidents.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffId = new SelectList(db.Staff, "StaffId", "LastName", incident.StaffId);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Region", incident.LocationId);
            return View(incident);
        }

        // POST: Incidents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IncidentId,TypeOfIncident,StaffIncident,HomeVisitIncident,BriefDesc,DateOccurred,StaffId,LocationId")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffId = new SelectList(db.Staff, "StaffId", "LastName", incident.StaffId);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Region", incident.LocationId);
            return View(incident);
        }

        // GET: Incidents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = db.Incidents.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incident incident = db.Incidents.Find(id);
            db.Incidents.Remove(incident);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public JsonResult GetData()
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //    var query = from d in db.Incidents
        //                select d;

        //    IEnumerable<Incident> incidents = query;
        //    return Json(incidents);
        //}

        public JsonResult GetBuildings(string region)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var query = from d in db.Locations
                        where d.Region.Equals(region)
                        //where d.LocationId == region
                        select d;

            IEnumerable<Location> buildingList = query;
            return Json(buildingList);
        }

        public JsonResult GetData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var query = from d in db.Incidents
                        select d;

            IEnumerable<Incident> incidents = query;
            var emptyList = new List<Tuple<string, int>>()
                .Select(t => new { typeInc = t.Item1, countOf = t.Item2 }).ToList();
            //var emptyList = new List<object>()
            //    .Select(t => new { })
            foreach (var row in incidents.GroupBy(info => info.TypeOfIncident)
                .Select(group => new
                {
                    IncidentType = group.Key,
                    Count = group.Count()
                })
                .OrderBy(x => x.IncidentType))
            {
                Console.WriteLine("{0} {1}", row.IncidentType, row.Count);
                emptyList.Add(new { typeInc = row.IncidentType, countOf = row.Count });
            }
            return Json(emptyList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBreakdown()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var query = from loc in db.Locations
                        join inc in db.Incidents on loc.LocationId equals inc.LocationId
                        select new { TypeIncident = inc.TypeOfIncident, Place = loc.Region };
            IEnumerable<object> incidents = query;
            string toExtract = "";
            string[] words;
            string region = "";
            //string what = "";
            int countAssaultNorth = 0, countThreatNorth = 0, countSlipNorth = 0, countManualNorth = 0, countDamageNorth = 0;
            int countAssaultSouth = 0, countThreatSouth = 0, countSlipSouth = 0, countManualSouth = 0, countDamageSouth = 0;
            int countAssaultEast = 0, countThreatEast = 0, countSlipEast = 0, countManualEast = 0, countDamageEast = 0;
            int countAssaultWest = 0, countThreatWest = 0, countSlipWest = 0, countManualWest = 0, countDamageWest = 0;

            var emptyList = new List<Tuple<string, int, int, int, int, int, int>>()
                .Select(t => new { Type = t.Item1, countAssault = t.Item2, countThreat = t.Item3, countSlip = t.Item4, countManual = t.Item5, countDamage = t.Item6 }).ToList();

            foreach (var line in incidents)
            {
                toExtract = line.ToString();
                words = toExtract.Split(' ');
                //what = words[0];
                int lastword = (words.Length - 2);
                region = words[lastword];
                if (toExtract.Contains("Assault"))
                {
                    switch (region)
                    {
                        case "North":
                            countAssaultNorth++;
                            break;
                        case "South":
                            countAssaultSouth++;
                            break;
                        case "East":
                            countAssaultEast++;
                            break;
                        case "West":
                            countAssaultWest++;
                            break;
                    }
                }
                else if (toExtract.Contains("Threat"))
                {
                    switch (region)
                    {
                        case "North":
                            countThreatNorth++;
                            break;
                        case "South":
                            countThreatSouth++;
                            break;
                        case "East":
                            countThreatEast++;
                            break;
                        case "West":
                            countThreatWest++;
                            break;
                    }
                }
                else if (toExtract.Contains("Manual"))
                {
                    switch (region)
                    {
                        case "North":
                            countManualNorth++;
                            break;
                        case "South":
                            countManualSouth++;
                            break;
                        case "East":
                            countManualEast++;
                            break;
                        case "West":
                            countManualWest++;
                            break;
                    }
                }
                else if (toExtract.Contains("Damage"))
                {
                    switch (region)
                    {
                        case "North":
                            countDamageNorth++;
                            break;
                        case "South":
                            countDamageSouth++;
                            break;
                        case "East":
                            countDamageEast++;
                            break;
                        case "West":
                            countDamageWest++;
                            break;
                    }
                }
                else if (toExtract.Contains("Slip"))
                {
                    switch (region)
                    {
                        case "North":
                            countSlipNorth++;
                            break;
                        case "South":
                            countSlipSouth++;
                            break;
                        case "East":
                            countSlipEast++;
                            break;
                        case "West":
                            countSlipWest++;
                            break;
                    }
                }
            }
            string[] regions = new string[] { "North", "South", "East", "West" };
            //string[] regions = new string[] { "Assault", "Threat", "Manual Handling", "Damage", "Slip" };
            //int[] counts = new int[] { countAssault, countThreat, , countManual, countDamage, countSlip };

            foreach (string s in regions)
            {
                region = s;
                switch (region)
                {
                    case "North":
                        emptyList.Add(new
                        {
                            Type = s,
                            countAssault = countAssaultNorth,
                            countThreat = countThreatNorth,
                            countSlip = countSlipNorth,
                            countManual = countManualNorth,
                            countDamage = countDamageNorth
                        });
                        break;
                    case "South":
                        emptyList.Add(new
                        {
                            Type = s,
                            countAssault = countAssaultSouth,
                            countThreat = countThreatSouth,
                            countSlip = countSlipSouth,
                            countManual = countManualSouth,
                            countDamage = countDamageSouth
                        });
                        break;
                    case "East":
                        emptyList.Add(new
                        {
                            Type = s,
                            countAssault = countAssaultEast,
                            countThreat = countThreatEast,
                            countSlip = countSlipEast,
                            countManual = countManualEast,
                            countDamage = countDamageEast
                        });
                        break;
                    case "West":
                        emptyList.Add(new
                        {
                            Type = s,
                            countAssault = countAssaultWest,
                            countThreat = countThreatWest,
                            countSlip = countSlipWest,
                            countManual = countManualWest,
                            countDamage = countDamageWest
                        });
                        break;
                        //new { Type = t.Item1, countAssault = t.Item2, countThreat = t.Item3, countSlip = t.Item4, countManual = t.Item5})
                        // emptyList.Add(new { typeInc = row.IncidentType, countOf = row.Count });
                }
            }
            //emptyList.Add(new { typeInc = row.IncidentType, countOf = row.Count });
            return Json(emptyList, JsonRequestBehavior.AllowGet);

        }
    }
}
