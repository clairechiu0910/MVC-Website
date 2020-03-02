using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using aspnetmvc2_ska.Models;
using Microsoft.Ajax.Utilities;

namespace aspnetmvc2_ska.Repositories
{
    public class SuppliersRepo : DataAccessLayer
    {
        public List<Suppliers> GetSuppliersList()
        {
            return Query<Suppliers>(
                @"SELECT [SupplierID], [CompanyName]
                    FROM [Suppliers]
                    ORDER BY [SupplierID]").ToList();
        }
    }
}