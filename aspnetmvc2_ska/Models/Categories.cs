using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace aspnetmvc2_ska.Models
{
    public class Categories
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
