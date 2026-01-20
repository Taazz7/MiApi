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
        public async Task<User> CreateUserAsync(User user)
        {
            var response = await _http.PostAsJsonAsync("https://jsonplaceholder.typicode.com/users", user);
            return await response.Content.ReadFromJsonAsync<User>() ?? user;
        }

        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            var response = await _http.PutAsJsonAsync($"https://jsonplaceholder.typicode.com/users/{id}", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var response = await _http.DeleteAsync($"https://jsonplaceholder.typicode.com/users/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}
