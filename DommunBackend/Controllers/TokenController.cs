using DommunBackend.Data;
using DommunBackend.DomainLayer.DTOs;
using DommunBackend.DomainLayer.Models;
using DommunBackend.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DommunBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;       
        private readonly IUserService userService;

        private readonly ApplicationDbContext _context;

        public TokenController(IConfiguration config, ApplicationDbContext context, IUserService userService)
        {
            _configuration = config;
            _context = context;           
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> PostIdentity(ApplicationUser _userData)
        {
            Result oRespuesta = new Result();

            if (_userData != null && _userData.Email != null && _userData.PasswordHash != null)
            {
                var user = await userService.GetUserIdentity(_userData.Email, _userData.PasswordHash);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    var vToken = new JwtSecurityTokenHandler().WriteToken(token);

                    //return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                    return Ok(new AuthResponseDto
                    {
                        IsAuthSuccessful = true,
                        Token = vToken,
                        ExpiresIn = DateTime.UtcNow.AddMinutes(10).ToString(),
                        TokenType = "bearer"
                    });
                }
                else
                {
                    //return BadRequest("Invalid credentials");
                    return BadRequest(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
                }
            }
            else
            {
                return BadRequest();
            }
        }      
    }
}