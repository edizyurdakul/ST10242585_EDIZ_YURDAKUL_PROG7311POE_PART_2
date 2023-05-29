using ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.DataAccessLayer;
using ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DAL dal = new DAL();

        public EmployeeController()
        {
            dal = new DAL();
        }

        public ActionResult Index()
        {
            List<User> farmers = dal.GetAllFarmers();

            return View(farmers);
        }

        public ActionResult AddFarmer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFarmer(User user)
        {
            if (ModelState.IsValid)
            {
                user.RoleId = 2;
                dal.AddUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult ViewFarmer(int id, DateTime? startDate, DateTime? endDate, string productType)
        {
            User user = dal.GetUserById(id);
            List<Product> products = dal.GetProductsByUserId(id);

            // Apply filtering based on the provided parameters
            if (startDate.HasValue)
            {
                products = products.Where(p => p.DateAdded >= startDate.Value).ToList();
            }

            if (endDate.HasValue)
            {
                products = products.Where(p => p.DateAdded <= endDate.Value).ToList();
            }

            if (!string.IsNullOrEmpty(productType))
            {
                products = products.Where(p => p.Type.Equals(productType, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            FarmerProducts farmerProducts = new FarmerProducts
            {
                User = user,
                Products = products
            };

            // Store the filter values in ViewBag for rendering in the view
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.ProductType = productType;

            return View(farmerProducts);
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}