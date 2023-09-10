using System;
using BOTC.Repository;
using BOTC.Models;
using BOTC.Models.DTOs;
using AutoMapper;
using BOTC.Models.Entities;

namespace BOTC.Services
{
	public class GamesService : IGamesService
	{
        private readonly IGamesRepository _gamesRepository;
        private readonly IMapper _mapper;


        public GamesService(IGamesRepository gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AddGameDTO>> GetGames()
        {
            var x = await _gamesRepository.GetGames();
            var mapped = x.Select(_mapper.Map<AddGameDTO>);
            return mapped;
        }

        public async Task<AddGameDTO> GetGameById(int gameId)
        {
            var x = await _gamesRepository.GetGameById(gameId);
            var mapped = _mapper.Map<AddGameDTO>(x);
            return mapped;
        }

        public async Task<int> AddGame(AddGameDTO game)
        {
            var startingRoleId = await _gamesRepository.GetRoleId(game.Starting_Role);
            var finalRoleId = await _gamesRepository.GetRoleId(game.Final_Role);

            var gameToSave = _mapper.Map<GameDTO>(game);
            gameToSave.Starting_Role_Id = startingRoleId;
            gameToSave.Final_Role_Id = finalRoleId;

            return await _gamesRepository.AddGame(gameToSave);
        }

        public async Task DeleteGame (int gameId)
        {
            await _gamesRepository.DeleteGame(gameId);
        }

        public async Task EditGame(AddGameDTO game, int gameId)
        {
            var startingRoleId = await _gamesRepository.GetRoleId(game.Starting_Role);
            var finalRoleId = await _gamesRepository.GetRoleId(game.Final_Role);

            var gameToSave = _mapper.Map<GameDTO>(game);
            gameToSave.Starting_Role_Id = startingRoleId;
            gameToSave.Final_Role_Id = finalRoleId;
            await _gamesRepository.EditGame(gameToSave, gameId);
        }
    }
}

