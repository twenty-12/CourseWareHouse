using CourseWarehouse.Data.Dto;
using CourseWarehouse.Data.Entities;
using CourseWarehouse.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseWareHouse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CabinetController : ControllerBase
    {
        private readonly IUserService _userService;

        public CabinetController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUserInfo([FromRoute] int userId)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(userId);
                return Ok(user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"User with id {userId} not found");
            }
        }
        
        [HttpPost("{userId}")]
        public async Task<IActionResult> Upsert(int userId, [FromBody] UserDto dto)
        {
            if (dto == null)
            {
                return BadRequest("User data cannot be null");
            }

            try
            {
                await _userService.UpsertAsync(userId, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating user: {ex.Message}");
            }
        }
    }
}