namespace GameStore.Api.Dtos;

public class V2GameDto
{
	public int Id { get; set; }

	public required string Name { get; set; }

	public required string Gendre { get; set; }

	public DateTime ReleaseDate { get; set; }

	public decimal Price { get; set; }

	public decimal RetailPrice { get; set; }

	public required string Image { get; set; }
}