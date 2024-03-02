using FluentValidation;

namespace CleanArchitecture.WebAPI.Middleware;

public sealed class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next) //invoke ile uygulamada araya girilir.
    {
		try
		{
			await next(context);
		}
		catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        if (ex.GetType() == typeof(ValidationException))
        {
            return context.Response.WriteAsync(new ValidationErrorDetails
            {
                Errors = ((ValidationException)ex).Errors.Select(s => s.PropertyName),
                StatusCode = 403
            }.ToString());
        }

        return context.Response.WriteAsync(new ErrorResult
        {
            Message = ex.Message,
            StatusCode = context.Response.StatusCode
        }.ToString());
    }
}
