using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Api.Dtos;

public class CreateGameDto
{
	[DefaultValue("Resident Evil 4")]
	public required string Name { get; set; }

	[DefaultValue("Horror")]
	public required string Gendre { get; set; }

	[DefaultValue("2005-01-11")]
	public DateTime ReleaseDate { get; set; }

	[DefaultValue(19.99)]
	public decimal Price { get; set; }

	[DefaultValue("https://placehold.co/100")]
	public required string Image { get; set; }
}