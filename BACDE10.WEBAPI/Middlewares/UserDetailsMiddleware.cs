using BACDE10.BusinessLogic.Common;
using BACDE10.BusinessLogic.Interfaces.Services;

namespace BACDE10.WEBAPI.Middlewares;

public class UserDetailsMiddleware
{
    private readonly RequestDelegate next;

    public UserDetailsMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, IUserDetailsProvider provider)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        //todo de luat din calimul de security
        if (!string.IsNullOrEmpty(context.Request.Headers[Constants.HeaderNames.UserId]) &&
            Guid.TryParse(context.Request.Headers[Constants.HeaderNames.UserId], out Guid userId))
        {
            provider.SetUserId(userId);
        }
        else
        {
            provider.SetUserId(Guid.Empty);
        }

        await next(context);
    }
}
