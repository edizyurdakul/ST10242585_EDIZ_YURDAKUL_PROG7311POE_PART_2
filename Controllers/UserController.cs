using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.DataAccessLayer;
using ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.Models;

namespace ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.Controllers
{
    public class UserController : Controller
    {
        private readonly DAL dal = new DAL();

        public ActionResult Index()
        {
            if (IsUserLoggedIn() && IsUserEmployee())
            {
                List<User> farmers = dal.GetUsersByRole(2);
                return View(farmers);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult AddFarmer()
        {
            if (IsUserLoggedIn() && IsUserEmployee())
            {
                User farmer = new User();
                return View(farmer);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult AddFarmer(User farmer)
        {
            if (IsUserLoggedIn() && IsUserEmployee())
            {
                farmer.RoleId = 2;
                dal.AddUser(farmer);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult SearchFarmer()
        {
            if (IsUserLoggedIn())
            {
                if (IsUserEmployee())
                {
                    List<User> users = dal.GetUsersByRole(2);
                    List<Farmer> farmers = new List<Farmer>();

                    foreach (var user in users)
                    {
                        Farmer farmer = new Farmer();
                        farmer.Name = user.FirstName;
                        farmer.Surname = user.LastName;
                        farmer.Email = user.Email;
                        farmer.StartDate = user.StartDate;

                        farmers.Add(farmer);
                    }

                    List<Product> products = (List<Product>)dal.GetAllProducts();
                    ProductFarmer model = new ProductFarmer
                    {
                        Farmers = farmers,
                        Products = products
                    };
                    return View(model);
                }
                else
                {
                    return RedirectToAction("Index", "Farmer");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // Search for product type
        public ActionResult SearchProductType()
        {
            if (IsUserLoggedIn() && IsUserEmployee())
            {
                List<Product> items = (List<Product>)dal.GetAllProducts();
                return View(items);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // Helper method to check if a user is logged in
        private bool IsUserLoggedIn()
        {
            User user = Session["CurrentUser"] as User;
            return user != null;
        }

        // Helper method to check if a user is an employee
        private bool IsUserEmployee()
        {
            User user = Session["CurrentUser"] as User;
            return user?.RoleId == 1;
        }
    }
}
