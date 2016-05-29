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
using System.Net.Mail;
using SelectPdf;
using System.Web.UI.WebControls;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace DSPsafe.Controllers
{
    public class IncidentsController : Controller
    {
        //private SafetyContext db = new SafetyContext();
        private ApplicationDbContext db = new ApplicationDbContext();

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
                            "ID", "Name", "Select Region");


        // GET: Incidents
        public ActionResult Index(string sortOrder, string searchStringRegion, string searchStringType)
        {

            var incidents = db.Incidents.Include(i => i.StaffReportee).Include(i => i.WhereHappened);
            ViewBag.Region = regions;
            ViewBag.Type = types;
            ViewBag.Building = new SelectList(db.Locations.Include(i => i.LocationId).Where(i => i.Region.Equals(searchStringRegion)), "LocationId", "Building");
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
            //ViewBag.StaffId = new SelectList(db.Staff, "StaffId", "LastName");
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Region");
            ViewBag.Region = regions;
            // ViewBag.Building = new SelectList(db.Locations.Where(i => i.Region.Equals(regions)), "LocationId", "Building");
            ViewBag.Building = new SelectList(db.Locations, "LocationId", "Building");
            return View();
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IncidentId,TypeOfIncident,StaffIncident,HomeVisitIncident,BriefDesc,DateOccurred,StaffId,LocationId")] Incident incident)
        //public ActionResult Create([Bind(Include = "IncidentId,TypeOfIncident,StaffIncident,HomeVisitIncident,BriefDesc,DateOccurred,LocationId")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                var manager = new UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = manager.FindById(User.Identity.GetUserId());
                incident.StaffId = user.StaffId.Value;
                db.Incidents.Add(incident);
                sendEmail("Harry", incident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffId = new SelectList(db.Staff, "StaffId", "LastName", incident.StaffId);
            //ViewBag.Building = new SelectList(db.Locations, "LocationId", "Region", incident.LocationId);


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


            //Used for populating the drop down list of buildings
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

        //Gets the data for the pie chart
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

        //Gets the data for the stacked bar chart
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

            var emptyList = new List<Tuple<string, string, int, int, int, int, int, int>>()
                .Select(t => new { category = t.Item1, Type = t.Item2, countAssault = t.Item3, countThreat = t.Item4, countSlip = t.Item5, countManual = t.Item6, countDamage = t.Item7}).ToList();

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
                            category = "North",
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
                            category = "South",
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
                            category = "East",
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
                            category = "West",
                            Type = s,
                            countAssault = countAssaultWest,
                            countThreat = countThreatWest,
                            countSlip = countSlipWest,
                            countManual = countManualWest,
                            countDamage = countDamageWest
                        });
                        break;
                       
                }
            }
            return Json(emptyList, JsonRequestBehavior.AllowGet);

        }

        ////Converts the view to a PDF
        //public ActionResult GeneratePDF(string sortOrder, string searchStringRegion, string searchStringType)
        //{
        //    IQueryable<Incident> myList = getIncidentList(sortOrder, searchStringRegion, searchStringType);
        //    return new Rotativa.ActionAsPdf("Index", myList);
        //}

        //public ActionResult PDF()
        //{
        //    return new Rotativa.ActionAsPdf("Index");
        //}

        //public ActionResult DownloadPartialViewPDF(string sortOrder, string searchStringRegion, string searchStringType)
        //{
        //    var model = GeneratePDF(sortOrder, searchStringRegion, searchStringType);
        //    //Code to get content
        //    return new Rotativa.PartialViewAsPdf("_incidentTable", model) { FileName = "TestPartialViewAsPdf.pdf" };
        //}


        public ActionResult ExportData(string sortOrder, string searchStringRegion, string searchStringType)
        {
            GridView gv = new GridView();
            // gv.DataSource = getIncidentList(sortOrder, searchStringRegion, searchStringType);
            gv.DataSource = db.Incidents.Include(i => i.StaffReportee).Include(i => i.WhereHappened).ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string time = DateTime.Now.ToShortTimeString();
            Response.AddHeader("content-disposition", "attachment; filename=Incidentlist"+time+".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }

        //Send email when incident reported
        public string sendEmail(string mail, Incident reported)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("YourMail@gmail.com");
            msg.To.Add("buntmcbunt@gmail.com");
            msg.Subject = "Health & Safety Incident reported" + DateTime.Now.ToString();
            //msg.Body = "To whom it concerns, " + reported.StaffReportee.FirstName + " " + reported.StaffReportee.LastName + " reported an incident of type " + reported.TypeOfIncident+ ". The incident occurred at " + reported.WhereHappened.Building + ".";
            msg.Body = "To whom it concerns, An incident of type " + reported.TypeOfIncident + " has occurred.";
            msg.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("javabraybowl@gmail.com", "DanoBucko");
            client.Timeout = 20000;
            try
            {
                client.Send(msg);
                return "Mail has been successfully sent!";
            }
            catch (Exception ex)
            {
                return "Fail Has error" + ex.Message;
            }
            finally
            {
                msg.Dispose();
            }
        }

        public IQueryable<Incident> getIncidentList(string sortOrder, string searchStringRegion, string searchStringType)
        {
            var incidents = db.Incidents.Include(i => i.StaffReportee).Include(i => i.WhereHappened);
            ViewBag.Region = regions;
            ViewBag.Type = types;
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

            return incidents;
        }
    }
}
