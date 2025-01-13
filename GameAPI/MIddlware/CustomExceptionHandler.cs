using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace GameAPI.MIddlware;
public class CustomException(HttpStatusCode statusCode, string message) : Exception(message)
{
    public HttpStatusCode StatusCode { get; set; } = statusCode;
    public string Title { get; set; }
}
public class CustomExceptionHandler: IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;
    private readonly ILogger _logger;

#pragma warning disable IDE0290 // Use primary constructor
    public CustomExceptionHandler(IProblemDetailsService problemDetailsService, ILogger logger)
#pragma warning restore IDE0290 // Use primary constructor
    {
        _problemDetailsService = problemDetailsService ?? throw new ArgumentNullException(nameof(problemDetailsService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.Error(exception, "Exception handle by middleware");
        if (exception is not CustomException customException) return true;
        var problemDetails = new ProblemDetails
        {
            Title = customException.Title,
            Status = (int)customException.StatusCode,
            Detail = customException.Message,
            Type = customException.StatusCode.ToString()
        };
        return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext {HttpContext = httpContext, ProblemDetails = problemDetails, Exception = exception});

    }
}