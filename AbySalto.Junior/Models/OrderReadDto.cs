namespace AbySalto.Junior.Models
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public StatusEnum Status { get; set; }
        public DateTime OrderTime { get; set; }
        public PaymentEnum PaymentMethod { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string? Note { get; set; }
        public List<OrderItemDto> Items { get; set; } = [];
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; } = "EUR";
    }
}
