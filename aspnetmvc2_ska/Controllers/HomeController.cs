using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspnetmvc2_ska.Models;
using aspnetmvc2_ska.Repositories;


namespace aspnetmvc2_ska.Controllers
{
    public class HomeController : Controller
    {
        private readonly NorthwindRepo _northwindRepo = new NorthwindRepo();

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CreateProduct()
        {
            ModelState.Clear();
            var newProduct = new Product
            {

            };
            return View(newProduct);
        }

        public ActionResult ReceiveNewProduct(Product newProduct)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "hihi");
                return View(nameof(CreateProduct));
            }

            _northwindRepo.InsertNewProduct(newProduct);
            TempData["IsCreateProductSuccessful"] = true;
            return Redirect("CreateProduct");
        }

        public ActionResult ViewProduct()
        {
            List<Product> productsList = _northwindRepo.GetProductsList();
            return View(productsList);
        }
    }
}