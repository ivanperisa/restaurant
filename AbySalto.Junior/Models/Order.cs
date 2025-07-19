using System.ComponentModel.DataAnnotations;

namespace AbySalto.Junior.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        public StatusEnum Status { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }
        [Required]
        public PaymentEnum PaymentMethod { get; set; }
        [Required]
        public string DeliveryAddress { get; set; } = string.Empty;
        [Required]
        public string ContactNumber { get; set; } = string.Empty;
        public string? Note { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public string Currency { get; set; } = "EUR";
    }
}
