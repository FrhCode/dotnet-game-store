using GameStore.Api.Repositories;

namespace GameStore.Api.Data;

public static class DataExtension
{
	public static IServiceCollection AddRepositories(
		this IServiceCollection services,
		IConfiguration configuration
	)
	{
		var connString = configuration.GetConnectionString("DefaultConnection");

		services.AddNpgsql<GameStoreDbContext>(connString);

		services.AddScoped<IGameRepository, EFGameRepository>();

		return services;
	}

}