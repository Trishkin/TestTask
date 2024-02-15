using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<Order> GetOrder()
        {
            var result = _applicationDbContext.Orders.OrderByDescending(x => x.Quantity * x.Price).FirstOrDefaultAsync();
            return result;
        }

        public Task<List<Order>> GetOrders()
        {
            var result = _applicationDbContext.Orders.Where(x => x.Quantity > 10).ToListAsync();
            return result;
        }
    }
}
