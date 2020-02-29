using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using aspnetmvc2_ska.Models;
using Microsoft.Ajax.Utilities;

namespace aspnetmvc2_ska.Repositories   
{
    public class NorthwindRepo : DataAccessLayer
    {
        public List<Product> GetProductsList()
        {
            return Query<Product>(
                @"SELECT [ProductID], [ProductName], [SupplierID], [CategoryID]
                        ,[QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder]
                        ,[ReorderLevel], [Discontinued]
                    FROM [Products]").ToList();
        }

        public void InsertNewProduct(Product newProduct)
        {
            const string sql = "INSERT INTO[Products]( [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit]"
                               + ", [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued])"
                               + "VALUES ("
                               + "@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit,"
                               + "@UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";
            var pram = new
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
            };
            Execute(sql, pram);
        }
    }
}