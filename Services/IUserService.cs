using System.Collections.Generic;
using System.Threading.Tasks;
using MovieEmailService.Models;

namespace MovieEmailService.Services
{
    public interface IUserService
    {
        public Task<User> GetUserByUsername(string email);
        public Task<IEnumerable<User>> GetUsersSubscribed();
        public Task<IEnumerable<User>> GetAllUsers();
    }
}