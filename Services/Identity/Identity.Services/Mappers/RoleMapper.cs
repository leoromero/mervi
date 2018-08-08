using Identity.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services.Mappers
{
    public class RoleMapper : Mapper<IdentityRole, RoleDto>
    {
        public override RoleDto ToDto(IdentityRole entity)
        {
            return new RoleDto
            {
                Name = entity.Name
            };
        }

        public override IdentityRole ToEntity(RoleDto dto)
        {
            return new IdentityRole
            {
                Name = dto.Name,
                NormalizedName = dto.NormalizedName
            };
        }
    }
}