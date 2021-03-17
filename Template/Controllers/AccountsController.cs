using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.JWT;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly JwtHandler jwtHandler;

        public AccountsController(IUserService userService, JwtHandler jwtHandler)
        {
            this.userService = userService;
            this.jwtHandler = jwtHandler;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserAuthRequestViewModel request)
        {
            UserViewModel user = userService.FindByEmail(request.Email);
            if (user == null || !userService.CheckPassword(user, request.Password))
                return Unauthorized(new UserAuthResponseViewModel { ErrorMessage = "Invalid Authentication" });
            var signingCredentials = jwtHandler.GetSigningCredentials();
            var claims = jwtHandler.GetClaims(user);
            var tokenOptions = jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new UserAuthResponseViewModel { IsAuthSuccessful = true, Token = token });
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserRegisterRequestViewModel request)
        {
            if (request == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            UserRegisterResponseViewModel response = userService.Register(request);

            if (response.IsSuccessfulRegistration)
                return StatusCode(201, response);
            else
                return BadRequest(response);

            
        }
    }
}
