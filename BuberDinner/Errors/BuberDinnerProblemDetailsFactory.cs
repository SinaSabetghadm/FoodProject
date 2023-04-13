using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;

namespace BuberDinner.Errors
{
    public class BuberDinnerProblemDetailsFactory : ProblemDetailsFactory
    {
        private readonly ApiBehaviorOptions _options;
        public BuberDinnerProblemDetailsFactory(ApiBehaviorOptions options)
        {
            _options = options;
        }
    
        public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            statusCode ??= 500;

            var problemDetails = new ProblemDetails
            {
                Detail = detail,
                Title = title,
                Type = type,
                Instance = instance

            };

            ApplyProblemDetailsDefault(httpContext,problemDetails,statusCode);
            return problemDetails;
        }

        public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            throw new NotImplementedException();
        }

        private void ApplyProblemDetailsDefault(HttpContext httpContext,ProblemDetails problemDetails,int? statusCode )
        {
            problemDetails.Status??= statusCode;
            if (_options.ClientErrorMapping.TryGetValue((int)statusCode,out var clientErrorData))
            {
                problemDetails.Title ??= clientErrorData.Title;
                problemDetails.Type ??= clientErrorData.Link;

            }
            var traceid = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
            if (traceid!=null)
            {
                problemDetails.Extensions["traceId"] = traceid;
            }
            problemDetails.Extensions.Add("customerProperty", "customValue");
        }

       
        
    }
}
