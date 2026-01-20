using MiApi.Models;

namespace MiApi.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post?> GetPostAsync(int id);
    }
}
