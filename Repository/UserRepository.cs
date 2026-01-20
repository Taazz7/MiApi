using MiApi.Models;
using System.Net.Http.Json;

namespace MiApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _http;

        public UserRepository(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<User>>(
                "https://jsonplaceholder.typicode.com/users"
            ) ?? Enumerable.Empty<User>();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<User>(
                $"https://jsonplaceholder.typicode.com/users/{id}"
            );
        }
    }
}
