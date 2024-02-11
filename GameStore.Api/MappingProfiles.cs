using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<CreateGameDto, Game>();
	}
}