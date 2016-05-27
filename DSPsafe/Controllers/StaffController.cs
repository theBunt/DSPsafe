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
    public class StaffController : Controller
    {
        //private SafetyContext db = new SafetyContext();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Staff
        public ActionResult Index(string Region, string Building)
        {

            ViewBag.Region = new SelectList(new[]
                                          {
                                              new {ID="North",Name="North"},
                                              new{ID="South",Name="South"},
                                              new{ID="East",Name="East"},
                                              new{ID="West",Name="West"}
                                          },
                            "ID", "Name", "Select Region");
            ViewBag.Building = new SelectList(db.Locations.Where(i => i.Region.Equals(Region)), "LocationId", "Building");
            //ViewBag.Building = new SelectList(null, "LocationId", "Building");


            if (!String.IsNullOrEmpty(Building))
            {
                var staff = from s in db.Staff select s;

                int locId = int.Parse(Building);
                staff = staff.Where(s => s.LocationId.Equals(locId));

                return View(staff.ToList());
            }

            return View();
        }

        // GET: Staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffId,LastName,FirstName,Email,EmpType,Phone,SafetyRole,Area")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staff.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staff.Find(id);

            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffId,LastName,FirstName,Email,EmpType,Phone,SafetyRole,Area")] Staff staff)
        {
            ViewBag.Role = new SelectList(new[]
                                          {
                                              new{ID="Fire Marshal",Name="Fire Marshal"},
                                              new {ID="First Aid",Name="First Aid"},
                                              new {ID="Safety Rep",Name="West"}
                                          },
                            "ID", "Name", "Select Role");
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff staff = db.Staff.Find(id);
            db.Staff.Remove(staff);
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
    }
}
