using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Entities;

public class Game
{
	public int Id { get; set; }

	public required string Name { get; set; }

	public required string Gendre { get; set; }

	public DateTime ReleaseDate { get; set; }

	public decimal Price { get; set; }

	public required string Image { get; set; }
}