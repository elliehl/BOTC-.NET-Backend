using AutoMapper;
using BOTC.Models.DTOs;
using BOTC.Models.Entities;

namespace BOTC.Mappers
{
    public class AutoMapper: Profile
	{
		public AutoMapper()
		{
			CreateMap<AddGameDTO, GameDTO>();
			CreateMap<GameEntity, AddGameDTO>();
            CreateMap<GameEntity, AddGameDTO>();
        }
    }
}

