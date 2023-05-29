using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.DataAccessLayer;
using ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.Models;

namespace ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.Controllers
{
    public class FarmerController : Controller
    {
        private readonly DAL dal = new DAL();

        public ActionResult Index()
        {
            User currentUser = Session["User"] as User;

            if (IsUserLoggedIn() && IsUserFarmer())
            {
                currentUser = Session["User"] as User;
                List<Product> products = dal.GetProductsByUserId(currentUser.UserId);

                FarmerProducts model = new FarmerProducts
                {
                    User = currentUser,
                    Products = products
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult AddProduct()
        {
            if (IsUserLoggedIn() && IsUserFarmer())
            {
                Product product = new Product();
                return View(product);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (IsUserLoggedIn() && IsUserFarmer())
            {
                User currentUser = Session["User"] as User;
                product.UserId = currentUser.UserId;
                dal.AddProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult EditProduct(int productId)
        {
            if (IsUserLoggedIn() && IsUserFarmer())
            {
                Product product = dal.GetProductById(productId);
                return View("EditProduct", product);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (IsUserLoggedIn() && IsUserFarmer())
            {
                dal.UpdateProduct(product);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            if (IsUserLoggedIn() && IsUserFarmer())
            {
                dal.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        public ActionResult DeleteProduct(int productId)
        {
            if (IsUserLoggedIn() && IsUserFarmer())
            {
                Product product = dal.GetProductById(productId);

                if (product != null)
                {
                    return View(product);
                }
            }

            return RedirectToAction("Index", "Home");
        }
        private bool IsUserLoggedIn()
        {
            User user = Session["User"] as User;
            return user != null && user.RoleId != 0;
        }
        private bool IsUserFarmer()
        {
            User user = Session["User"] as User;
            return user?.RoleId == 2;
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
