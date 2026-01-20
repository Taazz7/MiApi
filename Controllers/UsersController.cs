using Microsoft.AspNetCore.Mvc;
using MiApi.Services;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _service.GetUserAsync(id);
            return user is null ? NotFound() : Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User newUser)
        {
            var created = await _service.CreateUserAsync(newUser);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User updatedUser)
        {
            var result = await _service.UpdateUserAsync(id, updatedUser);
            return result ? NoContent() : NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteUserAsync(id);
            return result ? NoContent() : NotFound();
        }




    }
}
