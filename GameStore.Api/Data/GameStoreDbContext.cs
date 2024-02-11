using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreDbContext : DbContext
{
	public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
	{
		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
	}

	public DbSet<Game> Games => Set<Game>();
}