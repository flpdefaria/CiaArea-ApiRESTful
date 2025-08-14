using System.Net;
using System.Text.Json;
using FluentValidation;

namespace CiaAerea.Middlewares;

public class ValidationExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    
    public ValidationExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.Conflict;
            var result = JsonSerializer.Serialize(new { errors = ex.Errors.Select(error => error.ErrorMessage)});
            await response.WriteAsync(result);
        }
    }
}