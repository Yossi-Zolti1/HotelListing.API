using HotelListing.API.Core.Exeptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace HotelListing.API.Core.Middleware
{
    public class ExeptionMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<ExeptionMiddleware> _logger;

        public ExeptionMiddleware(RequestDelegate request, ILogger<ExeptionMiddleware> logger)
        {
            _request = request;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {context.Request.Path}");
                await HandleExeptionAsync(context, ex);
            }
        }

        private Task HandleExeptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var errorDetails = new ErrorDetails
            {
                ErrorType = "Failure",
                ErrorMessage = ex.Message,
            };
            switch (ex)
            {
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    errorDetails.ErrorType = "Not Found";
                    break;
                default:
                    break;
            }
            var response = JsonConvert.SerializeObject(errorDetails);
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(response);
        }
    }
    public class ErrorDetails
    {
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
    }
}
