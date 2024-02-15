using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<User> GetUser()
        {
            var result = _applicationDbContext.Users.OrderByDescending(x => x.Orders.Count).FirstOrDefaultAsync();
            return result;
        }

        public Task<List<User>> GetUsers()
        {
            var result =  _applicationDbContext.Users.Where(x => x.Status >= Enums.UserStatus.Inactive).ToListAsync();

            return result;
        }
    }
}
