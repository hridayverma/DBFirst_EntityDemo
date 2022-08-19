using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBFirst_EntityDemo.Controllers
{
    public class Employee
    {       
        public int Id { get; set; }
    }
    public class StateMgtController : Controller
    {
        // GET: StateMgt
        public ActionResult Index()
        {
            //Adding data in ViewBag,ViewData and TempData
            ViewBag.Employee = new Employee() { Id = 1000 };
            ViewData["employee2"] = new Employee() { Id = 2000 };
            TempData["Message"] = "Data from TempData";
            TempData.Keep("Message");
           // TempData.Peek()
            return View();
        }
        public ActionResult Index2()
        {
            //Retreiving Data from TempData on second Request
            ViewBag.Message = TempData["Message"];
            //TempData.Keep("Message");
            return View();
        }

        public ActionResult Index3()
        {
            //Retreiving Data from TempData on Third Request
            ViewBag.Message = TempData["Message"];
            return View();
        }
    }
}