using Mervi.Services.Interfaces;
using System.Collections.Generic;

namespace Mervi.Services.Mappers
{
    public abstract class Mapper<T, G> : IMapper<T, G>
    {
        public abstract G ToDto(T entity);
        public abstract T ToEntity(G dto);

        public IEnumerable<G> ToDtos(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                yield return ToDto(entity);
            }
        }

        public IEnumerable<T> ToEntities(IEnumerable<G> dtos)
        {
            foreach (var dto in dtos)
            {
                yield return ToEntity(dto);
            }
        }
    }
}
