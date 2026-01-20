using MiApi.Models;
using System.Net.Http.Json;

namespace MiApi.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly HttpClient _http;

        public PostRepository(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<Post>>(
                "https://jsonplaceholder.typicode.com/posts"
            ) ?? Enumerable.Empty<Post>();
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Post>(
                $"https://jsonplaceholder.typicode.com/posts/{id}"
            );
        }
    }
}
