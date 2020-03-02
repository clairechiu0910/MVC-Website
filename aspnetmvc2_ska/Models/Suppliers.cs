using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace aspnetmvc2_ska.Models
{
    public class Suppliers
    {
        [Display(Name = "SupplierID")]
        [Required(ErrorMessage = "{0} is required.")]
        public int SupplierID { get; set; }

        [Display(Name = "CompanyName")]
        [Required(ErrorMessage = "{0} is required.")]
        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }
    }
}
