using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Junior.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext dbContext;
        public OrderService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            order.TotalAmount = 0;
            foreach (var item in order.Items)
            {
                order.TotalAmount += item.Quantity * item.Price;
            }

            order.OrderTime = DateTime.Now;
            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await dbContext.Orders
                .Include(order => order.Items)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await dbContext.Orders
                .Include(order => order.Items)
                .FirstOrDefaultAsync(order => order.Id == id);
        }

        public async Task<bool> UpdateOrderStatusAsync(int id, StatusEnum newStatus)
        {
            var order = await dbContext.Orders.FindAsync(id);
            
            if (order == null)
            {
                return false;
            }

            order.Status = newStatus;
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Order>> GetOrdersSortedByTotalAsync(bool descending = false)
        {
            var query = dbContext.Orders
                .Include(order => order.Items)
                .AsQueryable();

            if (descending)
            {
                query = query.OrderByDescending(order => order.TotalAmount);
            }
            else
            {
                query = query.OrderBy(order => order.TotalAmount);
            }

            return await query.ToListAsync();
        }
    }
}