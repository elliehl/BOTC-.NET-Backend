using BOTC.Models.DTOs;
using BOTC.Models.Entities;
namespace BOTC.Repository
{
    public interface IGamesRepository
	{
        Task<IEnumerable<GameEntity>> GetGames();
        Task<GameEntity> GetGameById(int id);
        Task<int> AddGame(GameDTO game);
        Task DeleteGame(int id);
        Task EditGame(GameDTO game, int gameId);
        Task<int> GetRoleId(string startingRole);
    }
}

