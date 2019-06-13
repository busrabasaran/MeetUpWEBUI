using MeetUp.BLL;
using MeetUp.Entity;
using MeetUp.WEBUI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetUp.WEBUI.Controllers
{
    public class LoginController : Controller
    {
        UserBLL userBLL = new UserBLL();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users usr)
        {
            Users user = userBLL.GetUser(usr.Email);
            if (user != null)
            {
                if (user.Password == usr.Password)
                {
                    Session["Login"] = user;
                    return RedirectToAction("OrganizationsList", "Organization");
                }
                else
                {
                    return RedirectToAction("LoginHata");
                }
            }
            else
            {
                return RedirectToAction("LoginHata");
            }
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(Users user)
        {
            userBLL.AddUser(user);
            return RedirectToAction("Login");
        }

        [MyAuthenticationFilter]
        public ActionResult Logout()
        {
            Session.Remove("Login");
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult LoginHata()
        {
            return View();
        }
    }
}