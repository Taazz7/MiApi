using MiApi.Models;
using MiApi.Repositories;

namespace MiApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return _repo.GetUsersAsync();
        }

        public Task<User?> GetUserAsync(int id)
        {
            return _repo.GetUserByIdAsync(id);
        }
    }
}
