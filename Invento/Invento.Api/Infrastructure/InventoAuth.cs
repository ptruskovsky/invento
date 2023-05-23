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
                "Get" => transformedHttpTerm = "query",
                "Post" => transformedHttpTerm = "create",
                "Put" => transformedHttpTerm = "update",
                "Delete" => transformedHttpTerm = "delete",
                _ => transformedHttpTerm = ""
            };

            var manageAllRole = $"{controllerName}s-manage-all".ToLower();
            var restrctedRole = $"{controllerName}-{transformedHttpTerm}".ToLower();

            if (roles.Contains(manageAllRole)) 
            {
                context.HttpContext.Items["owner"] = null;
                return;
            }

            if (roles.Contains(restrctedRole)) 
            {
                context.HttpContext.Items["owner"] = user.Identity?.Name;
            }
            else {
                context.Result = new UnauthorizedObjectResult(string.Empty);
                return;
            }
        }
    }
}
