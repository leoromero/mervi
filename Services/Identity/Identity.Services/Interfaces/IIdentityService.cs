using Identity.Domain;
using Identity.DTOs;
using Identity.DTOs.Response;
using System.Threading.Tasks;

namespace Identity.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<UserRegistrationResponse> RegisterConsumerAsync(RegisterUserDto user);
        Task<UserRegistrationResponse> RegisterSellerAsync(RegisterUserDto user);
        Task<UserRegistrationResponse> RegisterAdminAsync(RegisterUserDto user);
        Task<UserDto> AuthenticateAsync(LoginDto login);
    }
}