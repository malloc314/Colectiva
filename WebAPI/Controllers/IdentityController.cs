using Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Wrappers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public IdentityController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterModel register)
        {
            var userExists = await _userManager.FindByNameAsync(register.Username);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Succeeded = false,
                    Message = "User already exists!"
                });
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.Username
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response<bool>
                {
                    Succeeded = false,
                    Message = "User creation failed! Please check user details and try agian.",
                    Errors = result.Errors.Select(x => x.Description)
                });
            }

            return Ok(new Response { Succeeded = true, Message = "User created successfully!" });
        }
    }
}
