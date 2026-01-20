using MiApi.Models;

namespace MiApi.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post?> GetPostAsync(int id);
        Task<Post> CreatePostAsync(Post post);
        Task<bool> UpdatePostAsync(int id, Post post);
        Task<bool> DeletePostAsync(int id);
    }
}
