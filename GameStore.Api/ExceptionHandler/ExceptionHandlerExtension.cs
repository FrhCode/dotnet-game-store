using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api;

public static class ExceptionHandlerExtension
{

	public static void ConfigureExceptionHandler(this IApplicationBuilder app)
	{
		app.Run(async context =>
		{
			var logger = context.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger("ExceptionHandler");

			var exceptionDetails = context.Features.Get<IExceptionHandlerFeature>();
			var exception = exceptionDetails?.Error;

			logger.LogError(exception, "Could not process a request on machine {Machine}. TraceId: {TraceId}",
							Environment.MachineName,
							Activity.Current?.TraceId);

			var problemDetails = new ProblemDetails
			{
				Title = "We made a mistake but we're working on it!",
				Status = StatusCodes.Status500InternalServerError,
				Extensions =
		{
			{"traceId", Activity.Current?.TraceId.ToString()},
		}
			};

			var environment = context.RequestServices.GetRequiredService<IWebHostEnvironment>();

			if (environment.IsDevelopment())
			{
				problemDetails.Detail = exception?.ToString();
			}

			await Results.Problem(problemDetails).ExecuteAsync(context);
		});
	}

}
