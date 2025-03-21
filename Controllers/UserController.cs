using AttendenceP.Models;
using AutoMapper;
using Core;
using Core.Dtos;
using Core.entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    // GET: api/<UsersController>
    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        var users = await _userService.GetListAsync();
        var listDto = _mapper.Map<IEnumerable<UserDto>>(users);
        return Ok(listDto);
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var user =  await _userService.GetByIdAsync(id);
        var userDto = _mapper.Map<UserDto>(user);
        return Ok(userDto);
    }

    // POST api/<UsersController>
    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] UserPostModel user)
    {
        var userToAdd = new User { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Password = user.Password, Role = user.Role};
        var newUser =await _userService.AddAsync(userToAdd);
        return Ok(newUser);
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> PutAsync(int id, [FromBody] UserPostModel user)
    {
        var userToUpdate = new User { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Password = user.Password, Role = user.Role };
        var updatedUser = await _userService.UpdateAsync(userToUpdate);
        return Ok(updatedUser);
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
       await _userService.DeleteAsync(id);
        return Ok();
    }
}
