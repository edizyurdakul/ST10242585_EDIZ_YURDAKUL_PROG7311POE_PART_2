using ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.DataAccessLayer;
using ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.Controllers
{
    public class HomeController : Controller
    {
        private DAL dal;

        public HomeController()
        {
            dal = new DAL();
        }

        public ActionResult Index()
        {
            User user = new User();

            return View(user);
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            User retrievedUser = dal.GetUserByEmailAndPassword(user.Email, user.Password);

            if (retrievedUser != null)
            {
                Session["User"] = retrievedUser;
                if (retrievedUser.RoleId == 1)
                {
                    return RedirectToAction("Index", "Employee");
                }
                else if (retrievedUser.RoleId == 2)
                {
                    return RedirectToAction("Index", "Farmer");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
