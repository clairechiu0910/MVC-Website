using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace aspnetmvc2_ska.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(30, ErrorMessage = "{0} can't not longer than {1} words.")]
        public string ProductName { get; set; }

        [Display(Name = "Supplier Id")]
        [Range(1, 29, ErrorMessage = "{0} must in range [{1}, {2}]")]
        public int SupplierID { get; set; }

        [Display(Name = "Category Id")]
        [Range(1, 8, ErrorMessage = "{0} must in range [{1}, {2}]")]
        public int CategoryID { get; set; }

        public  string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        [Display(Name = "Units In Stock")]
        [Required(ErrorMessage = "{0} can't be empty.")]
        public short UnitsInStock { get; set; }

        public short UnitsOnOrder { get; set; }

        public short ReorderLevel { get; set; }

        [Display(Name = "Discontinued")]
        [Required(ErrorMessage = "{0} can't be empty.")]
        public bool Discontinued { get; set; }
    }
}