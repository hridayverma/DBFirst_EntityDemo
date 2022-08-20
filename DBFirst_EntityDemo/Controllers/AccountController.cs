using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBFirst_EntityDemo.Models;

namespace DBFirst_EntityDemo.Controllers
{
    public class AccountController : Controller
    {
        CollegeDbEntities1 db = new CollegeDbEntities1();//context reference for db operation
        // GET: Account
        //for Login
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid) {
            //check for user authentication
            bool isValidUser =db.Logins.Any
                                  (u=>u.Username==login.Username && u.Password==login.Password);
                if (isValidUser)
                {
                    //cookie creation
                    HttpCookie ht = new HttpCookie("PGDAC");
                    ht.Values.Add("username", login.Username);
                    ht.Values.Add("logintime", DateTime.Now.ToString());
                    //ht.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(ht);
                    return RedirectToAction("Index", "Students");
                }
                else
                {
                    //ModelState.AddModelError("error", "Invalid Username/Password");
                    ViewBag.Error = "Invalid UserName/Password";
                    return View(login);
                }

            }   

            return View(login);
        }

        //for signup
        public ViewResult Register() {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Login login)
        {
            if (ModelState.IsValid) {
                db.Logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(login);
            //return View();
        }

        //for SignOut/Logout
        public ActionResult SignOut()
        {
            HttpCookie ht = Request.Cookies["PGDAC"];
            ht.Expires = DateTime.Now.AddMilliseconds(-1);
            Response.Cookies.Add(ht);
            //return View("Login");
            return RedirectToAction("Login");
        }








    }
}