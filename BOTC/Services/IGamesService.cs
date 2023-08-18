using BOTC.Models;

namespace BOTC.Services
{
    public interface IGamesService
    {
        Task<IEnumerable<Game>> GetGames();
        Task <Game> GetGameById(int id);
        Task AddGame(Game game);
        Task DeleteGame(int gameId);
        Task EditGame(Game game, int gameId);
    }
}