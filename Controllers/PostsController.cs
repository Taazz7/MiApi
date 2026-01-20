using Microsoft.AspNetCore.Mvc;
using MiApi.Services;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IJsonPlaceholderService _jsonPlaceholderService;
        private readonly ILogger<PostsController> _logger;

        public PostsController(
            IJsonPlaceholderService jsonPlaceholderService,
            ILogger<PostsController> logger)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los posts de JSONPlaceholder
        /// </summary>
        /// <returns>Lista de posts</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            try
            {
                var posts = await _jsonPlaceholderService.GetPostsAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener posts");
                return StatusCode(500, "Error al obtener los posts");
            }
        }

        /// <summary>
        /// Obtiene un post específico por ID
        /// </summary>
        /// <param name="id">ID del post</param>
        /// <returns>Post encontrado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            try
            {
                var post = await _jsonPlaceholderService.GetPostByIdAsync(id);
                
                if (post == null)
                {
                    return NotFound($"Post con ID {id} no encontrado");
                }

                return Ok(post);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener post {PostId}", id);
                return StatusCode(500, "Error al obtener el post");
            }
        }

        /// <summary>
        /// Obtiene los comentarios de un post específico
        /// </summary>
        /// <param name="id">ID del post</param>
        /// <returns>Lista de comentarios del post</returns>
        [HttpGet("{id}/comments")]
        [ProducesResponseType(typeof(List<Comment>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Comment>>> GetPostComments(int id)
        {
            try
            {
                var comments = await _jsonPlaceholderService.GetCommentsAsync(id);
                return Ok(comments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener comentarios del post {PostId}", id);
                return StatusCode(500, "Error al obtener los comentarios");
            }
        }
    }
}