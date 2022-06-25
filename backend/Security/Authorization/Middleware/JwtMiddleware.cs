using backend.Security.Authorization.Handlers.Interfaces;
using backend.Security.Authorization.Settings;
using backend.Security.Domain.Services;
using Microsoft.Extensions.Options;

namespace backend.Security.Authorization.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IUserService userService, IJwtHandler handler)
    {
        var token = context.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split(" ").Last();
        var claimsToken = handler.ValidateToken(token);
        var userId = claimsToken.Id;
        var userType = claimsToken.Type;
        if (userId != null)
        {
            // Attach user to context on successful JWT validation
            if (userType != null && userType == "BUSINESS")
            {
                context.Items["User"] = await userService.GetByIdAsync(userId);    
            }
        }

        await _next(context);
    }
}