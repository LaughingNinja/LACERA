using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LACERAWebMVCApp.Models;
using System.IO;
using LACERAShared;
using LACERAShared.Models;
using LACERAShared.Library;

namespace LACERAWebMVCApp.Controllers
{
    public class HomeController : Controller
    {
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

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            string path = null;

            List<Employee> employees = new List<Employee>();

            try
            {
                if (file.ContentLength > 0)
                {
                    Utility util = new Utility();
                    var fileName = Path.GetFileName(file.FileName);
                    path = AppDomain.CurrentDomain.BaseDirectory + "CSVUpload\\" + fileName;
                    file.SaveAs(path);
                    employees = util.ParseCSVEmployee(path);
                }
            }
            catch
            {
                ViewData["error"] = "Upload failed";
            }
            return View(employees);
        }

    }
}