using System.ComponentModel.DataAnnotations;

namespace InternshipTest.MVC.Models
{
    public class Sale
    {
        [Required]
        public string SalesOrder { get; set; }
        [Required]
        public string SalesOrderItem { get; set; }
        [Required]
        public string WorkOrder { get; set; }
        [Required]
        public string ProductID { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,5})?$")]
        public decimal OrderQuantity { get; set; }
        [Required]
        public string OrderStatus { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
    }
}
