
using AutoMapper;
using GameStore.Api.Authorization;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers;

[Route("api/v2/games")]
public class V2GamesController : ControllerBase
{
	private readonly IGameRepository _gameRepository;
	private readonly IMapper _mapper;

	public V2GamesController(IGameRepository gameRepository, IMapper mapper)
	{
		_gameRepository = gameRepository;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<List<Game>>> GetGames()
	{
		var games = await _gameRepository.GetAllAsync();

		List<V2GameDto> gameDtos = _mapper.Map<List<V2GameDto>>(games);

		return Ok(gameDtos);
	}

	// GET /api/games/1
	// user have to login to see this page
	[HttpGet("{id}")]
	// [Authorize(Roles = "Admin")] Role based authorization
	[Authorize(policy: Policies.Game_Read)] // Policy based authorizationf
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<Game>> GetGame(int id)
	{
		var game = await _gameRepository.GetByIdAsync(id);
		if (game is null)
		{
			return NotFound();
		}

		var gameDto = _mapper.Map<V2GameDto>(game);

		return Ok(gameDto);
	}

	// POST /api/games
	[HttpPost]
	[Authorize]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<Game>> AddGame([FromBody] CreateGameDto game)
	{
		var newGame = await _gameRepository.AddAsync(game);
		return CreatedAtAction(nameof(GetGame), new { id = newGame.Id }, newGame);
	}

}