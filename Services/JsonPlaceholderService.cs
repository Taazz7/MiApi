using System.Text.Json;

namespace MiApi.Services
{

    public class JsonPlaceholderService : IJsonPlaceholderService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<JsonPlaceholderService> _logger;
        private readonly JsonSerializerOptions _jsonOptions;

        public JsonPlaceholderService(
            HttpClient httpClient, 
            ILogger<JsonPlaceholderService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("posts");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonSerializer.Deserialize<List<Post>>(content, _jsonOptions);

                return posts ?? new List<Post>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener posts de JSONPlaceholder");
                throw;
            }
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"posts/{id}");
                
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Post>(content, _jsonOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener post {PostId} de JSONPlaceholder", id);
                throw;
            }
        }

        public async Task<List<Comment>> GetCommentsAsync(int postId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"posts/{postId}/comments");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var comments = JsonSerializer.Deserialize<List<Comment>>(content, _jsonOptions);

                return comments ?? new List<Comment>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener comentarios del post {PostId}", postId);
                throw;
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("users");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var users = JsonSerializer.Deserialize<List<User>>(content, _jsonOptions);

                return users ?? new List<User>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener usuarios de JSONPlaceholder");
                throw;
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"users/{id}");
                
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<User>(content, _jsonOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener usuario {UserId} de JSONPlaceholder", id);
                throw;
            }
        }
    }

    // Modelos para JSONPlaceholder


}