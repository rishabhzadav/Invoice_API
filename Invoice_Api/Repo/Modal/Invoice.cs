using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Invoice_Api.Repo.Modal
{
    public class Invoice
    {
        [Key]
        [StringLength(21)]
       // [JsonIgnore]
        public string ?  InvoiceNo { get; set; }  

        [Required]
        public DateTime InvoiceDateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string InvoiceCustomerName { get; set; }

        [Required]
        [StringLength(10)]
        public string InvoiceCustomerMno { get; set; }

        [Required]
        [RegularExpression("^(CASH|UPI|CARD|OTHER)$", ErrorMessage = "Payment Mode must be CASH, UPI, CARD, or OTHER")]
        public string PaymentMode { get; set; }

        public virtual List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}

