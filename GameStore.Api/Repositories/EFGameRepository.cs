using AutoMapper;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Repositories;

public class EFGameRepository : IGameRepository
{
	private readonly GameStoreDbContext _dbContext;
	private readonly IMapper _mapper;

	public EFGameRepository(GameStoreDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}

	public async Task<Game> AddAsync(CreateGameDto game)
	{
		Game newGame = _mapper.Map<Game>(game);

		await _dbContext.Games.AddAsync(newGame);
		await _dbContext.SaveChangesAsync();
		return newGame;
	}

	public async Task DeleteAsync(int id)
	{
		var game = await _dbContext.Games.FindAsync(id);
		if (game is not null)
		{
			_dbContext.Games.Remove(game);
			await _dbContext.SaveChangesAsync();
		}
	}

	public async Task<IEnumerable<Game>> GetAllAsync()
	{
		return await _dbContext.Games.AsNoTracking().ToListAsync();
	}

	public async Task<Game?> GetByIdAsync(int id)
	{
		return await _dbContext.Games.FindAsync(id);
	}

	public async Task<Game> UpdateAsync(Game game)
	{
		_dbContext.Games.Update(game);
		await _dbContext.SaveChangesAsync();
		return game;
	}
}

