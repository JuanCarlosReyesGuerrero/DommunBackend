using Common;
using DomainLayer.DTOs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DommunBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IUsuarioService usuarioService;
        private readonly IUserService userService;
    
        private readonly ApplicationDbContext _context;

        public TokenController(IConfiguration config, ApplicationDbContext context, IUsuarioService _usuarioService, IUserService userService)
        {
            _configuration = config;
            _context = context;
            this.usuarioService = _usuarioService;
            this.userService = userService;
        }

        [HttpPost]
        //public async Task<IActionResult> Post(UserInfo _userData)
        //{
        //    Result oRespuesta = new Result();

        //    if (_userData != null && _userData.Email != null && _userData.Password != null)
        //    {
        //        var user = await GetUser(_userData.Email, _userData.Password);

        //        //if (user != null)
        //        if (user.Id > 0)
        //        {
        //            //create claims details based on the user information
        //            var claims = new[] {
        //                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //                new Claim("Id", user.Id.ToString()),
        //                new Claim("DisplayName", user.DisplayName),
        //                new Claim("UserName", user.UserName),
        //                new Claim("Email", user.Email)
        //            };

        //            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //            var token = new JwtSecurityToken(
        //                _configuration["Jwt:Issuer"],
        //                _configuration["Jwt:Audience"],
        //                claims,
        //                expires: DateTime.UtcNow.AddMinutes(10),
        //                signingCredentials: signIn);

        //            var vToken = new JwtSecurityTokenHandler().WriteToken(token);

        //            //return Ok(new JwtSecurityTokenHandler().WriteToken(token));

        //            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = vToken });
        //        }
        //        else
        //        {
        //            //return BadRequest("Invalid credentials");
        //            return BadRequest(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        public async Task<IActionResult> PostIdentity(ApplicationUser _userData)
        {
            Result oRespuesta = new Result();

            if (_userData != null && _userData.Email != null && _userData.PasswordHash != null)
            {
                var user = await GetUserIdentity(_userData.Email, _userData.PasswordHash);

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

                    return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = vToken });
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

        //private async Task<UserInfo> GetUser(string email, string password)
        //{
        //    var vIdTemp = usuarioService.ValidarHashUsuario(email, password);

        //    UserInfo objTemp = new UserInfo();

        //    if (vIdTemp > 0)
        //        objTemp = usuarioService.GetUsuarioById(vIdTemp);

        //    return objTemp;
        //}

        private async Task<ApplicationUser> GetUserIdentity(string email, string password)
        {
             string vPass = password + email + Constants.pivotePass;
            //string vPass = password ;

            ApplicationUser objTemp = new ApplicationUser();
            List<ApplicationUser> objList = new List<ApplicationUser>();

            try
            {
                ApplicationUser authUser = new ApplicationUser();

                bool vTemp = false;
                              
                var hasher = new PasswordHasher<ApplicationUser>();
                var hash = hasher.HashPassword(authUser, vPass);

                objList = userService.FindByEmail(email).ToList();

                objTemp = objList.SingleOrDefault(s => s.Email == email);

                if (objTemp != null)
                {
                    if (objTemp.Email != null && objTemp.PasswordHash != null)
                    {
                        var verified = hasher.VerifyHashedPassword(authUser, objTemp.PasswordHash, vPass);

                        if (verified.ToString() == "Success")
                            vTemp = true;
                        else
                            objTemp = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objTemp;
        }
    }
}