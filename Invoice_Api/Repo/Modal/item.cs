using System.ComponentModel.DataAnnotations;

namespace Invoice_Api.Repo.Modal
{
    public class item
    {
        [Key]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Item Code must be 6 digits")]
        public string ItemCode { get; set; }

        [Required]
        [StringLength(20)]
        public string ItemName { get; set; }

        [Required]
        [RegularExpression("^[ABC]$", ErrorMessage = "Item Category must be A, B, or C")]
        public string ItemCategory { get; set; }
        
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Item Unit Price must be a positive number")]
        public decimal ItemUnitPrice { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Item Discount must be between 0 and 100")]
        public int ItemDiscountInPercentage { get; set; }
    }
}
