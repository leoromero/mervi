using System.Collections.Generic;

namespace Identity.Services.Interfaces
{
    public interface IMapper<Entity, Dto>
    {
        Dto ToDto(Entity entity);
        Entity ToEntity(Dto dto);
        IEnumerable<Dto> ToDtos(IEnumerable<Entity> entities);
        IEnumerable<Entity> ToEntities(IEnumerable<Dto> dtos);
    }
}
