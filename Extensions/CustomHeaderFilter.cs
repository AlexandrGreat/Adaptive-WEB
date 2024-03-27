using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LR6.Extensions
{
    public class CustomHeaderFilter:IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            var apiDesc = context.ApiDescription;
            if (apiDesc.IsDeprecated())
            { 
                operation.Deprecated = true;
            }
        }
    }
}
