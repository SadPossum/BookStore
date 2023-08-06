namespace BookStore.Api.Middleware;

using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using BookStore.Api.Models;
using FluentValidation;

// Middleware class to handle global exception handling for the API.
public class GlobalExceptionHandlingMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> logger;
    private readonly RequestDelegate next;
    private readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true,
        AllowTrailingCommas = true,
    };

    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger, RequestDelegate next)
    {
        this.logger = logger;
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context is null || this.next is null)
        {
            return;
        }

        try
        {
            await this.next(context).ConfigureAwait(false);
        }
        catch (KeyNotFoundException exception)
        {
            this.logger.LogError("Exception was thrown: {Exception}", exception);
            await this.HandleExceptionAsync(context, new()
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = exception.Message
            }).ConfigureAwait(false);
        }
        catch (ArgumentException exception)
        {
            this.logger.LogError("Exception was thrown: {Exception}", exception);
            await this.HandleExceptionAsync(context, new()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = exception.Message
            }).ConfigureAwait(false);
        }
        catch (ValidationException exception)
        {
            this.logger.LogError("Exception was thrown: {Exception}", exception);
            await this.HandleExceptionAsync(context, new()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Validation failed",
                Errors = exception.Errors.Select(a => a.ErrorMessage)
            }).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            this.logger.LogError("Exception was thrown: {Exception}", exception);
            await this.HandleExceptionAsync(context, new()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = "Internal server error"
            }).ConfigureAwait(false);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, ErrorResponse response)
    {
        var jsonResponse = JsonSerializer.Serialize(response, this.jsonSerializerOptions);
        this.logger.LogDebug("LogError response: {JsonResponse}", jsonResponse);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)response.StatusCode;

        await context.Response.WriteAsync(jsonResponse).ConfigureAwait(false);
    }
}





