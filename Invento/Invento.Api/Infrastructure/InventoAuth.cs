using Invento.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace Invento.Api.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class InventoAuth : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            var realmRoles = user.Claims.Where(x => x.Type == "realm_access")?.FirstOrDefault()?.Value;
            var deserializationResult = JsonSerializer.Deserialize<RealmRole>(realmRoles ?? string.Empty);

            if (deserializationResult == null)
            {
                context.Result = new UnauthorizedObjectResult(string.Empty);
                return;
            }

            var roles = deserializationResult.Roles;
            var actionName = context.RouteData.Values["action"];
            var controllerName = context.RouteData.Values["controller"];
            var transformedHttpTerm = string.Empty;

            _ = actionName switch
            {
                "POST" => transformedHttpTerm = "query",
                "GET" => transformedHttpTerm = "create",
                "PUT" => transformedHttpTerm = "update",
                "DELETE" => transformedHttpTerm = "delete",
                _ => transformedHttpTerm = ""
            };

          
            var requiredGetRoles = new[] { $"{controllerName}-{transformedHttpTerm}", $"{controllerName}-manage-all" };
            if (!roles.Any(x => requiredGetRoles.Contains(x)))
            {
                context.Result = new UnauthorizedObjectResult(string.Empty);
                return;
            }
        }
    }
}
