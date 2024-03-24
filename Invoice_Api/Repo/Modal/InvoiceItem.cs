using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Invoice_Api.Repo.Modal
{
    public class InvoiceItem
    {

       
        [ForeignKey("Invoice")]
        [Key , Column(Order = 0)]
       // [JsonIgnore]
        public string ? InvoiceNo { get; set; }  = string.Empty;

        [JsonIgnore]
        public virtual  Invoice ? Invoice { get; set; }

        [Required]
        [Key , Column(Order = 1)]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Item Code must be 6 digits")]
        public string ItemCode { get; set; }
        [Required]
        public int ItemQty { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ItemUnitPrice { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ItemDiscount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ItemAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ItemAmountPaid { get; set; }

    }
}
