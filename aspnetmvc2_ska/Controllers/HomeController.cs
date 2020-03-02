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
        private readonly ProductsRepo _productsRepo = new ProductsRepo();
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

            _productsRepo.InsertNewProduct(newProduct);
            TempData["IsCreateProductSuccessful"] = true;
            return Redirect("CreateProduct");
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

        public ActionResult ViewProduct()
        {
            List<Product> productsList = _productsRepo.GetProductsList();
            return View(productsList);
        }

        [HttpPost]
        public ActionResult ApplyFilter(string searchProductName)
        {
            List<Product> productsList = _productsRepo.GetProductsList();
            if (searchProductName != null)
            {
                productsList = FilterProductName(productsList, searchProductName);
            }
            return View("ViewProduct", productsList);
        }

        private static List<Product> FilterProductName(IEnumerable<Product> productsList, string searchProductName)
        {
            var filteredProductsList = new List<Product>{};
            foreach (var product in productsList)
            {
                if (product.ProductName.IndexOf(searchProductName, StringComparison.Ordinal) != -1)
                {
                    filteredProductsList.Add(product);
                }
            }

            return filteredProductsList;
        }

    }
}