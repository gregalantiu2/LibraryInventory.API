using System.Security.Claims;

namespace LibraryInventory.API.Middleware
{
    public class UserContextMiddleware
    {
        private readonly RequestDelegate _next;

        public UserContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.User?.Identity?.IsAuthenticated == true)
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    //todo: Add logging in the future
                    throw new InvalidOperationException("User ID claim not found.");
                }
                context.Items["UserId"] = userId;
            }
            else
            {
                //todo: Add logging in the future
                throw new UnauthorizedAccessException("User is not authenticated.");
            }
            await _next(context);
        }
    }
}
