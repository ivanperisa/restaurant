using System.ComponentModel.DataAnnotations;

namespace AbySalto.Junior.Models
{
    public class OrderCreateDto
    {
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        public PaymentEnum PaymentMethod { get; set; }
        [Required]
        public string DeliveryAddress { get; set; } = string.Empty;
        [Required]
        public string ContactNumber { get; set; } = string.Empty;
        public string? Note { get; set; }
        [Required]
        [MinLength(1)]
        public List<OrderItemDto> Items { get; set; } = [];
        [Required]
        public string Currency { get; set; } = "EUR";
    }
}
