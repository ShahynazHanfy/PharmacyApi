using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PharmacyApi.Authentication;
using PharmacyApi.ViewModel;
using PharmacyApi.ViewModels;

namespace PharmacyApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
           
            
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);


                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    roles = userRoles,
                    expiration = token.ValidTo,
                    user.pharmacyLoggedInID,
                    
                });
            }
            return Unauthorized();
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserVM model)
        {
            var userExists = await userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            model.UserName = model.UserName.Replace(' ', '_');
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                pharmacyLoggedInID=model.pharmacyLoggedInID,
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            if (model.Role == "Admin")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (model.Role == "SuperAdmin")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.SuperAdmin));
                await userManager.AddToRoleAsync(user, UserRoles.SuperAdmin);
            }
            else if (model.Role == "User")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                await userManager.AddToRoleAsync(user, UserRoles.User);
            }
            else if (model.Role == "Clerk")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.Clerk))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Clerk));
                await userManager.AddToRoleAsync(user, UserRoles.Clerk);
            }
            else if (model.Role == "DataEntry")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.DataEntry))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.DataEntry));
                await userManager.AddToRoleAsync(user, UserRoles.DataEntry);
            }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
        [HttpPost]
        [Route("changPassword")]
        public async Task<IActionResult> ChangPassword(ChangePassword model)
        {
            var user = await userManager.FindByNameAsync(model.userName);
            //user != null && await userManager.CheckPasswordAsync(user, model.Password)
            await userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
            return Ok();
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
    }
}

