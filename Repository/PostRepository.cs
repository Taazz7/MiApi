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

        public async Task<Post> CreatePostAsync(Post post)
        {
            var response = await _http.PostAsJsonAsync(
                "https://jsonplaceholder.typicode.com/posts",
                post
            );

            return await response.Content.ReadFromJsonAsync<Post>() ?? post;
        }

        public async Task<bool> UpdatePostAsync(int id, Post post)
        {
            var response = await _http.PutAsJsonAsync(
                $"https://jsonplaceholder.typicode.com/posts/{id}",
                post
            );

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var response = await _http.DeleteAsync(
                $"https://jsonplaceholder.typicode.com/posts/{id}"
            );

            return response.IsSuccessStatusCode;
        }
    }
}
