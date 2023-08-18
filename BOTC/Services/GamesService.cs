using System;
using BOTC.Repository;
using BOTC.Models;

namespace BOTC.Services
{
	public class GamesService : IGamesService
	{
        private readonly IGamesRepository _gamesRepository;

        public GamesService(IGamesRepository gamesRepository)
		{
            _gamesRepository = gamesRepository;
        }

        public async Task<IEnumerable<Game>> GetGames()
        {
            return await _gamesRepository.GetGames();
        }

        public async Task<Game> GetGameById(int gameId)
        {
            return await _gamesRepository.GetGameById(gameId);
        }

        public async Task AddGame(Game game)
        {
            await _gamesRepository.AddGame(game);
        }

        public async Task DeleteGame (int gameId)
        {
            await _gamesRepository.DeleteGame(gameId);
        }

        public async Task EditGame (Game game, int gameId)
        {
            await _gamesRepository.EditGame(game, gameId);
        }
    }
}

