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
            => _repo.GetPostsAsync();

        public Task<Post?> GetPostAsync(int id)
            => _repo.GetPostByIdAsync(id);

        public Task<Post> CreatePostAsync(Post post)
            => _repo.CreatePostAsync(post);

        public Task<bool> UpdatePostAsync(int id, Post post)
            => _repo.UpdatePostAsync(id, post);

        public Task<bool> DeletePostAsync(int id)
            => _repo.DeletePostAsync(id);
    }
}
