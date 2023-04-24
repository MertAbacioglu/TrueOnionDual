using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.IO;
using System.Net;
using System.Text.Json;
using TrueOnion.APPLICATION.Wrappers;
using TrueOnion.PERSISTINCE.Exceptions;

namespace TrueOnion.PERSISTINCE.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (SqlException sqlException)
            {
                await HandleSqlExceptionAsync(context, sqlException);
            }
            catch (Exception exceptionObj)
            {
                await HandleExceptionAsync(context, exceptionObj);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int code;
            string result = exception.Message;

            code = exception switch
            {
                ValidationException validationException => (int)HttpStatusCode.BadRequest,
                BadRequestException badRequestException => (int)HttpStatusCode.BadRequest,
                DeleteFailureException deleteFailureException => (int)HttpStatusCode.BadRequest,
                NotFoundException _ => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            result = exception switch
            {
                ValidationException validationException => JsonSerializer.Serialize(validationException.Failures),
                BadRequestException badRequestException => badRequestException.Message,
                DeleteFailureException deleteFailureException => deleteFailureException.Message,
                _ => exception.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(JsonSerializer.Serialize(new { StatusCode = code, ErrorMessage = exception.Message }));
        }
        private Task HandleSqlExceptionAsync(HttpContext context, SqlException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonSerializer.Serialize(new { StatusCode = context.Response.StatusCode, ErrorMessage = "An error occurred while processing your request. Please try again later." }));
        }
    }
}