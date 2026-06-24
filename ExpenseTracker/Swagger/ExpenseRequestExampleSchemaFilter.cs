using ExpenseTracker.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ExpenseTracker.Swagger
{
    /// <summary>
    /// Provides a default example payload for expense creation in Swagger UI.
    /// </summary>
    public class ExpenseRequestExampleSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type != typeof(CreateExpenseRequest))
            {
                return;
            }

            schema.Example = new OpenApiObject
            {
                ["title"] = new OpenApiString("Lunch"),
                ["amount"] = new OpenApiDouble(250),
                ["category"] = new OpenApiString("Food")
            };
        }
    }
}
