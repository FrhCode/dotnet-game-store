using AutoMapper;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Profiles;

public class GameProfile : Profile
{

	public GameProfile()
	{
		CreateMap<Game, V1GameDto>();
		CreateMap<Game, V2GameDto>().ForMember(
			dest => dest.RetailPrice,
			opt => opt.MapFrom(src => src.Price * 0.7m)
		);
	}
}