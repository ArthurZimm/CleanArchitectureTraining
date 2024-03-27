using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTOs;
using Todo.Application.Interfaces;

namespace Todo.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController :  Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }
        [HttpGet("User/{id}")]
        public async Task<IActionResult> GetUsersById([FromRoute]int id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO user)
        {
            var result = _userService.Add(user);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserDTO user)
        {
            var result = _userService.Update(user);
            return Ok(result);
        }
        [HttpDelete("User/Delete/{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var result = _userService.Delete(id);
            return Ok(result);
        }
    }
}
