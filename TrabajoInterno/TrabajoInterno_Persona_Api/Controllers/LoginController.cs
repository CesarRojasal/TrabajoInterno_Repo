using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrabajoInterno_Abstraccion;
using TrabajoInterno_Entities;

namespace TrabajoInterno_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService userService;
        public readonly IMapper _mapper;
        private readonly IConfiguration configuration;
        public LoginController(IMapper mapper, IUserService userService, IConfiguration configuration)
        {
            _mapper = mapper;
            this.userService = userService;
            this.configuration = configuration;
        }

        [HttpPost]
        public IResult Login(UserLogin user)
        {
            if (!string.IsNullOrEmpty(user.Username) &&
                !string.IsNullOrEmpty(user.Password))
            {
                var loggedInUser = userService?.Get(user);
                if (loggedInUser is null) return Results.NotFound("User not found");

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loggedInUser.Username),
                    new Claim(ClaimTypes.Email, loggedInUser.EmailAddress),
                    new Claim(ClaimTypes.GivenName, loggedInUser.GivenName),
                    new Claim(ClaimTypes.Surname, loggedInUser.Surname),
                    new Claim(ClaimTypes.Role, loggedInUser.Role)
                };

                var token = new JwtSecurityToken
                (
                    issuer:  configuration["Jwt:Issuer"],
                    audience: configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                        SecurityAlgorithms.HmacSha256)
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);


                return Results.Ok(tokenString);
            }
            return Results.BadRequest("Invalid user credentials");
        }
    }
}