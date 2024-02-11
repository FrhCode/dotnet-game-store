using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace GameStore.Api.Cors;

public static class CorsExtension
{
	public static void ConfigureCorsHandler(this CorsOptions app, ConfigurationManager configuration)
	{
		app.AddDefaultPolicy(options =>
		{
			var allowedOrigins = configuration.GetSection("AllowedOrigins").Get<string[]>() ?? throw new ArgumentNullException("AllowedOrigins is not configured");
			options.WithOrigins(allowedOrigins)
				.AllowAnyHeader()
				.AllowAnyMethod();
		});
	}

}