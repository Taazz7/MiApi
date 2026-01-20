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
        public Task<User> CreateUserAsync(User user) => _repo.CreateUserAsync(user);
        public Task<bool> UpdateUserAsync(int id, User user) => _repo.UpdateUserAsync(id, user);
        public Task<bool> DeleteUserAsync(int id) => _repo.DeleteUserAsync(id);

    }
}
