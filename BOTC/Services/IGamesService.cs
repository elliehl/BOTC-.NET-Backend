using BOTC.Models;
using BOTC.Models.DTOs;
using BOTC.Models.Entities;

namespace BOTC.Services
{
    public interface IGamesService
    {
        Task<IEnumerable<AddGameDTO>> GetGames();
        Task <AddGameDTO> GetGameById(int id);
        Task AddGame(AddGameDTO game);
        Task DeleteGame(int gameId);
        Task EditGame(AddGameDTO game, int gameId);
    }
}