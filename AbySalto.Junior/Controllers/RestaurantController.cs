using AbySalto.Junior.Models;
using AbySalto.Junior.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Junior.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class RestaurantController : Controller
    {
        private readonly OrderService orderService;
        public RestaurantController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        private static OrderReadDto ToReadDto(Order order) => new OrderReadDto
        {
            Id = order.Id,
            CustomerName = order.CustomerName,
            Status = order.Status,
            OrderTime = order.OrderTime,
            PaymentMethod = order.PaymentMethod,
            DeliveryAddress = order.DeliveryAddress,
            ContactNumber = order.ContactNumber,
            Note = order.Note,
            Items = order.Items.Select(item => new OrderItemDto
            {
                Name = item.Name,
                Quantity = item.Quantity,
                Price = item.Price
            }).ToList(),
            TotalAmount = order.TotalAmount,
            Currency = order.Currency
        };

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderCreateDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = new Order
            {
                CustomerName = dto.CustomerName,
                PaymentMethod = dto.PaymentMethod,
                DeliveryAddress = dto.DeliveryAddress,
                ContactNumber = dto.ContactNumber,
                Note = dto.Note,
                Currency = dto.Currency,
                Status = StatusEnum.Pending,
                Items = dto.Items.Select(item => new OrderItem
                {
                    Name = item.Name,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };

            var created = await orderService.AddOrderAsync(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = created.Id }, ToReadDto(created));
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await orderService.GetOrdersAsync();
            return Ok(orders.Select(ToReadDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(ToReadDto(order));
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] StatusEnum newStatus)
        {
            var result = await orderService.UpdateOrderStatusAsync(id, newStatus);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("sorted")]
        public async Task<IActionResult> GetOrdersSorted([FromQuery] bool descending = false)
        {
            var orders = await orderService.GetOrdersSortedByTotalAsync(descending);
            return Ok(orders.Select(ToReadDto));
        }
    }
}
