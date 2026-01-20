using MiApi.Models;

namespace MiApi.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post?> GetPostByIdAsync(int id);
        Task<Post> CreatePostAsync(Post post);
        Task<bool> UpdatePostAsync(int id, Post post);
        Task<bool> DeletePostAsync(int id);
    }
}
