namespace AbySalto.Junior.Infrastructure.Database
{
    public interface IApplicationDbContext
    {
        Microsoft.EntityFrameworkCore.DbSet<AbySalto.Junior.Models.Order> Orders { get; set; }
        Microsoft.EntityFrameworkCore.DbSet<AbySalto.Junior.Models.OrderItem> OrderItems { get; set; }
    }
}
