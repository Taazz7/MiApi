using MiApi.Services;

public interface IJsonPlaceholderService
    {
        Task<List<Post>> GetPostsAsync();
        Task<Post?> GetPostByIdAsync(int id);
        Task<List<Comment>> GetCommentsAsync(int postId);
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
    }
