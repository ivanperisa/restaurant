using System.ComponentModel.DataAnnotations;

namespace AbySalto.Junior.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
