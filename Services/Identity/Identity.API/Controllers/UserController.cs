using Identity.DTOs;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IIdentityService service;

        public UserController(IConfiguration config, IIdentityService service)
        {
            this.config = config;
            this.service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> PostAsync(RegisterUserDto account)
        {
            var result = await service.RegisterAdminAsync(account);

            return Ok();
        }
    }
}