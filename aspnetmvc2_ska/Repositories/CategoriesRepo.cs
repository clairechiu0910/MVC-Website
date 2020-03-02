using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using aspnetmvc2_ska.Models;
using Microsoft.Ajax.Utilities;

namespace aspnetmvc2_ska.Repositories
{
    public class CategoriesRepo : DataAccessLayer
    {
        public List<Categories> GetCategoriesList()
        {
            return Query<Categories>(
                @"SELECT [CategoryID], [CategoryName], [Description]
                     FROM [Categories]
                     ORDER BY [CategoryID]").ToList();
        }
    }
}