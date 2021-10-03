using System.ComponentModel.DataAnnotations;

namespace BusinessEntityLayer.Model
{
    public class Customer
    {
        public int Id
        { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name
        { get; set; }
        public string Phone
        { get; set; }
        [Required(ErrorMessage = "VAT is required")]
        public string VAT
        { get; set; }
        public string Address
        { get; set; }
        public string City
        { get; set; }
        public decimal AnnualRevenue
        { get; set; }
        public decimal TotalAmount
        { get; set; }
        public int OrderCount
        { get; set; }

    }
}
