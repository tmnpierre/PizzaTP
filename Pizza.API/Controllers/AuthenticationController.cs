using Pizza.API.Data;
using Pizza.API.DTOs;
using Pizza.API.Helpers;
using Pizza.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ContactApiDTOAsync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly AppSettings _appSettings;

        public AuthenticationController(ApplicationDbContext applicationDbContext, IOptions<AppSettings> appSettings)
        {
            _applicationDbContext = applicationDbContext;
            _appSettings = appSettings.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            if (await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email) != null)
                return BadRequest("Email exist");

            user.Password = PasswordCrypter.Encrypt(user.Password, _appSettings.SecretKey);

            await _applicationDbContext.AddAsync(user);

            if (await _applicationDbContext.SaveChangesAsync() > 0) return Ok("User crée"); 
            return BadRequest("Probleme creation User");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO login)
        {
            login.Password = PasswordCrypter.Encrypt(login.Password, _appSettings.SecretKey!);

            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);

            if (user == null) return BadRequest("Invalid Authentication !");

            var role = user.IsAdmin ? Constants.RoleAdmin : Constants.RoleUser;

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, role),
                new Claim("Userid",user.Id.ToString())
            };

            SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.SecretKey!)), SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken(
               claims: claims, 
                issuer: _appSettings.ValidIssuer,
                audience: _appSettings.ValidAudience,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddHours(2));

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new
            {
                Token = token,
                Message = "Authentication Succefull !!",
                User = user
            });
        }
    }
}