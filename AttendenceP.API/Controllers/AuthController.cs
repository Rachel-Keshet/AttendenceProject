using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AttendenceP.Models;
using Microsoft.AspNetCore.Authorization;
using Data;
using Microsoft.Extensions.Logging;

namespace AttendenceP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration configuration, DataContext context, ILogger<AuthController> logger)
        {
            _configuration = configuration;
            _context = context;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            _logger.LogInformation("Login attempt for user: {UserName}", loginModel.UserName);

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.FirstName == loginModel.UserName && u.Password == loginModel.Password);

            if (user == null)
            {
                _logger.LogWarning("Invalid login attempt for user: {UserName}", loginModel.UserName);
                return Unauthorized(new { message = "Invalid username or password" });
            }

            _logger.LogInformation("User {UserName} logged in successfully.", user.FirstName);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = _configuration.GetValue<string>("JWT:Key");
            if (string.IsNullOrEmpty(key))
            {
                _logger.LogError("JWT Key is not configured properly.");
                return StatusCode(500, "JWT Key is not configured properly.");
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWT:Issuer"),
                audience: _configuration.GetValue<string>("JWT:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            _logger.LogInformation("JWT token generated successfully for user: {UserName}", user.FirstName);

            return Ok(new { Token = tokenString });
        }

        [AllowAnonymous]
        [HttpGet("secure-data")]
        public IActionResult GetSecureData()
        {
            _logger.LogInformation("Access to secure data requested.");
            return Ok("This is secure data.");
        }
    }
}
