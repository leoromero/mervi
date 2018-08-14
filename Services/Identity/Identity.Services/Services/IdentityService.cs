using Identity.Domain;
using Identity.DTOs;
using Identity.DTOs.Response;
using Identity.Infrastructure;
using Identity.Services.Interfaces;
using Mervi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository repository;
        private readonly UserManager<User> userManager;
        private readonly IMapper<User, UserDto> mapper;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityService(IIdentityRepository repository, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper<User, UserDto> mapper)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.mapper = mapper;
            this.roleManager = roleManager;
        }

        public async Task<UserDto> AuthenticateAsync(LoginDto login)
        {
            var user = await userManager.FindByNameAsync(login.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, login.Password))
            {
                return mapper.ToDto(user);
            }

            return null;
        }

        public async Task<UserRegistrationResponse> RegisterAdminAsync(RegisterUserDto newUser)
        {
            return await RegisterUser(newUser, "Admin");
        }

        public async Task<UserRegistrationResponse> RegisterConsumerAsync(RegisterUserDto newUser)
        {
            return await RegisterUser(newUser, "Consumer");
        }

        public async Task<UserRegistrationResponse> RegisterSellerAsync(RegisterUserDto newUser)
        {
            return await RegisterUser(newUser, "Seller");
        }

        private async Task<UserRegistrationResponse> RegisterUser(RegisterUserDto newUser, string role)
        {
            var result = new UserRegistrationResponse();
            var user = await GetNewUserAsync(newUser, role);
            var createResult = await userManager.CreateAsync(user, newUser.Password);

            if (!createResult.Succeeded)
                result.AddErrors(createResult.Errors.Select(x => x.Description).ToList());

            return result;
        }

        private async Task<User> GetNewUserAsync(RegisterUserDto user, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            var newUser = new User
            {
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                FullName = user.FullName,
                UserName = user.UserName,
                Roles = new List<IdentityRole>() { role }
            };

            return newUser;
        }
    }
}
