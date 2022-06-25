using backend.Register.Domain.Models;
using backend.Security.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace backend.Security.Authorization.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeClientAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // If action is decorated with [AllowAnonymous] attribute
        
        var allowAnonymous = context.ActionDescriptor
            .EndpointMetadata
            .OfType<AllowAnonymousAttribute>().Any();
        
        // Then skip authorization process

        if (allowAnonymous)
            return;
        
        // Authorization process
        var userClient = (Client)context.HttpContext.Items["UserClient"];
        if (userClient == null)
            context.Result = new JsonResult(new { message = "Unauthorized" })
                { StatusCode = StatusCodes.Status401Unauthorized };
    }
}