using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VEMS.API.Models.Auth;
using VEMS.API.Models.Identity;

namespace VEMS.API.Controllers.V1
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration, RoleManager<ApplicationRole> roleManager)
        {
            this._userManager = userManager;
            this.configuration = configuration;
            this._roleManager = roleManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register model)
        {
            var result = new RegisterResponse();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = ModelState.Values.ToList()[0].Errors[0].ErrorMessage;
                    return StatusCode(422, result);
                }

                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    Fullname = model.Fullname
                };

                var createResult = await _userManager.CreateAsync(user, model.Password);

                //If the role exists, assign the role to the user
                var userRole = await _roleManager.RoleExistsAsync(model.Role);
                if (userRole)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                }
                else
                {
                    result.Success = false;
                    result.Message = "Assigned role not found";
                    return NotFound(result);
                }

                if (createResult.Succeeded)
                {
                    result.Success = true;
                    result.Message = "User sucessfully registered";
                }
                else
                {
                    result.Success = false;
                    result.Message = "Error creating the user";
                    return StatusCode(409, result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                return StatusCode(500, result);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login model)
        {
            var result = new LoginResponse();
            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = ModelState.Values.ToList()[0].Errors[0].ErrorMessage;
                    return StatusCode(422, result);
                }

                var user = await _userManager.FindByNameAsync(model.Username);

                if (user == null)
                {
                    result.Message = "User not found";
                    return NotFound(result);
                }

                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    //get the user role
                    var userRoles = await _userManager.GetRolesAsync(user);

                    var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(ClaimTypes.Role, userRoles[0])
                    };

                    var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

                    var token = new JwtSecurityToken(
                        issuer: configuration["Jwt:Issuer"],
                        audience: configuration["Jwt:Audience"],
                        expires: DateTime.Now.AddMinutes(90),
                        claims: claims,
                        signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256)
                        );


                    result.Token = new JwtSecurityTokenHandler().WriteToken(token);
                    result.RefreshToken = "";
                    result.ExpireDate = token.ValidTo;

                    return Ok(result);
                }
                else
                {
                    result.Message = "Username or Password are incorrect...";
                    return Unauthorized(result);
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return StatusCode(500, result);
            }
        }
    }
}