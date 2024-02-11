using Microsoft.AspNetCore.Authorization;

namespace GameStore.Api.Authorization;

public static class AuthorizeExtension
{
	public static void AuthorizationCallback(this AuthorizationOptions options)
	{
		options.AddPolicy(Policies.Game_Read, policy => policy.RequireClaim("scope", "Game_Read"));
	}

}