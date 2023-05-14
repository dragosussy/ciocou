using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace Middleware.ExceptionHandler
{
    public class CioccExceptionHandlerMiddleware : AbstractExceptionHandlerMiddleware
    {
        public CioccExceptionHandlerMiddleware(RequestDelegate next) : base(next)
        {
        }

        public override (HttpStatusCode code, string message) GetResponse(Exception exception)
        {
            return exception switch
            {
                KeyNotFoundException
                or FileNotFoundException => (HttpStatusCode.NotFound, JsonConvert.SerializeObject(GetResponseBody(exception))),

                UnauthorizedAccessException => (HttpStatusCode.Unauthorized, JsonConvert.SerializeObject(GetResponseBody(exception))),
                
                ArgumentException
                or InvalidOperationException => (HttpStatusCode.BadRequest, JsonConvert.SerializeObject(GetResponseBody(exception))),
                
                _ => (HttpStatusCode.InternalServerError, JsonConvert.SerializeObject(GetResponseBody(exception))),

            };
        }

        private IDictionary<string, string> GetResponseBody(Exception exception)
        {
            var response = new Dictionary<string, string>();
            response.Add("message", exception.Message);
            return response;
        }
    }
}
