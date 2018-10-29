using System;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Mervi.API.Infrastructure.Swagger
{
    internal class AddExampleObjects : ISchemaFilter
    {
        /// <summary>
        ///     Apply
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="context"></param>
        public void Apply(Schema schema, SchemaFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}