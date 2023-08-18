using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace lafise.test.Api.Versioning
{
    /// <summary>
    /// Class to override method that returns exception when request Api Versioning is not valid
    /// </summary>
    /// <see href="https://github.com/dotnet/aspnet-api-versioning/issues/233"/>
    public class ApiVersioningErrorResponseProvider : DefaultErrorResponseProvider
    {
        /// <summary>
        /// This method creates the object response
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IActionResult CreateResponse(ErrorResponseContext context)
        {
            var errorResponse = new
            {
                Type = context.ErrorCode,
                Title = context.Message,
                Status = 400
            };

            var response = new ObjectResult(errorResponse)
            {
                StatusCode = context.StatusCode
            };

            return response;
        }
    }
}
