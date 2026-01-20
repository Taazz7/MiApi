using MiApi.Models;
using MiApi.Repositories;

namespace MiApi.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repo;

        public PostService(IPostRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return _repo.GetPostsAsync();
        }

        public Task<Post?> GetPostAsync(int id)
        {
            return _repo.GetPostByIdAsync(id);
        }
    }
}
