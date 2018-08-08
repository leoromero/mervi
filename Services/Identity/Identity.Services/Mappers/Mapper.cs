using Identity.Services.Interfaces;
using System.Collections.Generic;

namespace Identity.Services.Mappers
{
    public abstract class Mapper<Entity, Dto> : IMapper<Entity, Dto>
    {
        public abstract Dto ToDto(Entity entity);
        public abstract Entity ToEntity(Dto dto);

        public IEnumerable<Dto> ToDtos(IEnumerable<Entity> entities)
        {
            foreach (var entity in entities)
            {
                yield return ToDto(entity);
            }
        }

        public IEnumerable<Entity> ToEntities(IEnumerable<Dto> dtos)
        {
            foreach (var dto in dtos)
            {
                yield return ToEntity(dto);
            }
        }
    }
}
