using System.ComponentModel.DataAnnotations;

namespace AbySalto.Junior.Models
{
    public class OrderItemDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
