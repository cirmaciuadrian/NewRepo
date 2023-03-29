namespace BACDE10.WEBAPI.Middlewares;

public class ExceptionHandler
{
    private readonly RequestDelegate next;

    //private readonly ILogger<ExceptionHandler> logger;

    public ExceptionHandler(RequestDelegate next/*, ILogger<ExceptionHandler> logger*/)
    {
        this.next = next;
        //this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception)
        {
            //todo handle
            //await HandleException(context, exception);
            throw;
        }
    }

    //private async Task HandleException(HttpContext context, Exception exception)
    //{
    //    if (exception is ServiceException)
    //    {
    //        logger.LogError(exception, "Service exception.");
    //        await ((ServiceException)exception).WriteAsync(context, exceptionOptions.CurrentValue.UseSlim);
    //        return;
    //    }

    //    logger.LogCritical(exception, "Unhandled exception.");
    //    context.Response.StatusCode = 500;
    //    if (exceptionOptions.CurrentValue.UseSlim)
    //    {
    //        context.Response.ContentType = null;
    //        return;
    //    }

    //    context.Response.ContentType = "text/text";
    //    await context.Response.WriteAsync(exception.ToString());
    //}
}
