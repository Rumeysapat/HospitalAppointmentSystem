using Hospital.Entities.Concrete;
using System.Threading.Tasks;

namespace Hospital.Services.Abstract
{
    public interface IUserService
    {
        Task<User?> GetUserByEmailAsync(string email);
         Task<bool> CreateUserAsync(User user);
    }
}
