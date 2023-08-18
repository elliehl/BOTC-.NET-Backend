using System;
using BOTC.Models;
namespace BOTC.Repository
{
	public interface IGamesRepository
	{
        Task<IEnumerable<Game>> GetGames();
        Task<Game> GetGameById(int id);
        Task AddGame(Game game);
        Task DeleteGame(int id);
        Task EditGame(Game game, int gameId);
    }
}

