using DSPsafe.DAL;
using DSPsafe.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSPsafe.Controllers
{
    public class HomeController : Controller


    {

        //private SafetyContext db = new SafetyContext();
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var query = from d in db.Incidents
                        select d;

            IEnumerable<Incident> incidentList = query;
            var emptyList = new List<Tuple<string, int>>()
                .Select(t => new { typeInc = t.Item1, countOf = t.Item2 }).ToList();
            //var emptyList = new List<object>()
            //    .Select(t => new { })
            foreach (var row in incidentList.GroupBy(info => info.TypeOfIncident)
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
            IEnumerable<object> incidentList = query;
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

            foreach (var line in incidentList)
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