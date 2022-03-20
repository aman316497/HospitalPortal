using Hospital_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Portal.Controllers
{
    public class HospitalController : Controller
    {
        // GET: Hospital
        public ActionResult Index()
        {
            HospitalDBContext dBContext = new HospitalDBContext();
            List<tbl_MstHospital> hospitalList = dBContext.tbl_MstHospital.ToList();
            return View(hospitalList);
        }
        [HttpPost]
        public ActionResult Index(string HospitalName)
        {
            HospitalDBContext dBContext = new HospitalDBContext();
            return View(dBContext.SearchHospital(HospitalName));
        }
        
        public async Task<ActionResult> HospitalDetails(int HospitalId)
        {
            ViewBag.PageName = "HospitalDetails";
            HospitalDBContext dBContext = new HospitalDBContext();
            return View(dBContext.tbl_MstHospital.Find(HospitalId));
        }
    }
}