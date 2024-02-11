using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public interface IGameRepository
{
	Task<Game> AddAsync(CreateGameDto game);
	Task DeleteAsync(int id);
	Task<IEnumerable<Game>> GetAllAsync();
	Task<Game?> GetByIdAsync(int id);
	Task<Game> UpdateAsync(Game game);
}