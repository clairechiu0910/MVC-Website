using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using aspnetmvc2_ska.Models;
using aspnetmvc2_ska.Repositories;


namespace aspnetmvc2_ska.Controllers
{
    public class HomeController : Controller
    {
        private readonly NorthwindRepo _northwindRepo = new NorthwindRepo();
        private readonly SuppliersRepo _suppliersRepo = new SuppliersRepo();
        private readonly CategoriesRepo _categoriesRepo = new CategoriesRepo();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateProduct()
        {
            ModelState.Clear();
            var newProduct = new Product { };

            GetSuppliersName(newProduct);
            GetCategoriesName(newProduct);

            return View(newProduct);
        }

        public ActionResult ReceiveNewProduct(Product newProduct)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "hihi");

                GetSuppliersName(newProduct);
                GetCategoriesName(newProduct);

                return View(nameof(CreateProduct), newProduct);
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

        private void GetSuppliersName(Product newProduct)
        {
            var suppliersList = _suppliersRepo.GetSuppliersList();
            newProduct.SuppliersList = new List<SelectListItem>();
            foreach (var supplier in suppliersList)
            {
                newProduct.SuppliersList.Add(new SelectListItem()
                {
                    Text = supplier.CompanyName,
                    Value = supplier.SupplierID.ToString()
                });
            }
        }

        private void GetCategoriesName(Product newProduct)
        {
            var categoriesList = _categoriesRepo.GetCategoriesList();
            newProduct.CategoryList = new List<SelectListItem>();
            foreach (var category in categoriesList)
            {
                newProduct.CategoryList.Add(new SelectListItem()
                {
                    Text = category.CategoryName,
                    Value = category.CategoryID.ToString()
                });
            }
        }
    }
}