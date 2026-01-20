using Microsoft.AspNetCore.Mvc;
using MiApi.Services;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IJsonPlaceholderService _jsonPlaceholderService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            IJsonPlaceholderService jsonPlaceholderService,
            ILogger<UsersController> logger)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los usuarios de JSONPlaceholder
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            try
            {
                var users = await _jsonPlaceholderService.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener usuarios");
                return StatusCode(500, "Error al obtener los usuarios");
            }
        }

        /// <summary>
        /// Obtiene un usuario específico por ID
        /// </summary>
        /// <param name="id">ID del usuario</param>
        /// <returns>Usuario encontrado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await _jsonPlaceholderService.GetUserByIdAsync(id);
                
                if (user == null)
                {
                    return NotFound($"Usuario con ID {id} no encontrado");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener usuario {UserId}", id);
                return StatusCode(500, "Error al obtener el usuario");
            }
        }
    }
}