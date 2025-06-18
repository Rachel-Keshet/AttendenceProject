using AttendenceP.Models;
using AutoMapper;
using Core;
using Core.Dtos;
using Core.entities;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserService userService, IMapper mapper, ILogger<UsersController> logger)
    {
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
    }

    // GET: api/<UsersController>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> GetAsync()
    {
        try
        {
            _logger.LogInformation("GET request for all users by Admin.");
            var users = await _userService.GetListAsync();
            var listDto = _mapper.Map<IEnumerable<UserDto>>(users);
            _logger.LogInformation("Successfully retrieved all users.");
            return Ok(listDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving users.");
            return StatusCode(500, "Internal server error.");
        }
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> GetAsync(int id)
    {
        try
        {
            _logger.LogInformation("GET request for user with ID: {Id} by Admin.", id);
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning("User with ID: {Id} not found.", id);
                return NotFound();
            }
            var userDto = _mapper.Map<UserDto>(user);
            _logger.LogInformation("Successfully retrieved user with ID: {Id}.", id);
            return Ok(userDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving user with ID: {Id}.", id);
            return StatusCode(500, "Internal server error.");
        }
    }

    // POST api/<UsersController>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> PostAsync([FromBody] UserPostModel user)
    {
        try
        {
            _logger.LogInformation("POST request to add a new user.");
            var userToAdd = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
            var newUser = await _userService.AddAsync(userToAdd);
            _logger.LogInformation("Successfully added new user with ID: {Id}.", newUser.Id);
            return Ok(newUser);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding a new user.");
            return StatusCode(500, "Internal server error.");
        }
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> PutAsync(int id, [FromBody] UserPostModel user)
    {
        try
        {
            _logger.LogInformation("PUT request to update user with ID: {Id}.", id);
            var userToUpdate = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
            var updatedUser = await _userService.UpdateAsync(userToUpdate);
            _logger.LogInformation("Successfully updated user with ID: {Id}.", updatedUser.Id);
            return Ok(updatedUser);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating user with ID: {Id}.", id);
            return StatusCode(500, "Internal server error.");
        }
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        try
        {
            _logger.LogInformation("DELETE request to remove user with ID: {Id}.", id);
            await _userService.DeleteAsync(id);
            _logger.LogInformation("Successfully deleted user with ID: {Id}.", id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting user with ID: {Id}.", id);
            return StatusCode(500, "Internal server error.");
        }
    }
}
