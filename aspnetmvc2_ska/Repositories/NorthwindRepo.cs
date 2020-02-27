using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using aspnetmvc2_ska.Models;

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
    }
}