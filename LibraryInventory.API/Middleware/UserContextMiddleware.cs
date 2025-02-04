using LibraryInventory.Data.Audit.Interfaces;
using System.Security.Claims;

namespace LibraryInventory.API.Middleware
{
    public class UserContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<UserContextMiddleware> _logger;

        public UserContextMiddleware(RequestDelegate next, ILogger<UserContextMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IUserContext userContextService)
        {
            if (context.User?.Identity?.IsAuthenticated == true)
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    _logger.LogError("User Id claim not found.");
                    throw new InvalidOperationException("User Id claim not found.");
                }
                userContextService.UserId = userId;
            }
            else
            {
                _logger.LogError("User was not authenticated.");
                throw new UnauthorizedAccessException("User is not authenticated.");
            }
            await _next(context);
        }
    }
}
