using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using aspnetmvc2_ska.Models;
using Microsoft.Ajax.Utilities;

namespace aspnetmvc2_ska.Repositories   
{
    public class ProductsRepo : DataAccessLayer
    {
        public List<Product> GetProductsList()
        {
            return Query<Product>(
                @"SELECT * 
                        FROM [Northwind].[dbo].[Products] P LEFT JOIN [Northwind].[dbo].[Categories] S ON P.CategoryID = S.CategoryID").ToList();
        }

        public List<Product> GetProductsSearchName(string searchProductName)
        {
            return Query<Product>(
                @"SELECT * 
                        FROM [Northwind].[dbo].[Products] P LEFT JOIN [Northwind].[dbo].[Categories] S ON P.CategoryID = S.CategoryID
                        WHERE p.ProductName LIKE @n"
                , new
                {
                    n = '%' + searchProductName +'%'
                }).ToList();
        }

        public void InsertNewProduct(Product newProduct)
        {
            Execute(@"INSERT INTO[Products]( [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit],
                        [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued])
                        VALUES (
                        @ProductName, @SupplierID, @CategoryID, @QuantityPerUnit,
                        @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)"
                , new
                {
                    ProductName = newProduct.ProductName,
                    SupplierID = newProduct.SupplierID,
                    CategoryID = newProduct.CategoryID,
                    QuantityPerUnit = newProduct.QuantityPerUnit,
                    UnitPrice = newProduct.UnitPrice,
                    UnitsInStock = newProduct.UnitsInStock,
                    UnitsOnOrder = newProduct.UnitsOnOrder,
                    ReorderLevel = newProduct.ReorderLevel,
                    Discontinued = newProduct.Discontinued
                });
        }
    }
}