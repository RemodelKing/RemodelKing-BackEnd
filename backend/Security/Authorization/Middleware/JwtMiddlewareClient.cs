using backend.Security.Authorization.Handlers.Interfaces;
using backend.Security.Authorization.Settings;
using backend.Security.Domain.Services;
using Microsoft.Extensions.Options;

namespace backend.Security.Authorization.Middleware;

public class JwtMiddlewareClient
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddlewareClient(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }
    
    public async Task Invoke(HttpContext context, IUserClientService userClientService, IJwtHandler handler)
    {
        var token = context.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split(" ").Last();
        var claimsToken = handler.ValidateToken(token);
        var userId = claimsToken.Id;
        var userType = claimsToken.Type;
        if (userId != null)
        {
            if (userType != null && userType == "CLIENT")
            {
                context.Items["UserClient"] = await userClientService.GetByIdAsync(userId);    
            }
            
        }
        await _next(context);
    }
}