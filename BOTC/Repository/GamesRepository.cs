using System;
using Dapper;
using BOTC.Models;
using BOTC.Data;

namespace BOTC.Repository
{
	public class GamesRepository: IGamesRepository
	{
        private readonly IContext _context;

        public GamesRepository(IContext context)
		{
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetGames()
        {
            IEnumerable<Game> games = new List<Game>();

            try
            {
                using var connection = _context.GetConnection();
                var query = "SELECT * FROM games";
                games = await connection.QueryAsync<Game>(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return games;
        }
   
        public async Task<Game> GetGameById(int gameId)
        {
            Game game = new Game();
            var parameters = new { Id = gameId };
            var query = "SELECT * FROM games WHERE id = @Id";

            try
            {
                using var connection = _context.GetConnection();
                game = await connection.QueryFirstAsync<Game>(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return game;
        }

        public async Task AddGame(Game game)
        {
            var parameters = new { Date = game.Date, Game_Won = game.Game_Won, Is_Evil = game.Is_Evil, Comments = game.Comments,
                                   Starting_Role_Id = game.Starting_Role_Id, Final_Role_Id = game.Final_Role_Id};

            var query = "INSERT INTO games (date, game_won, is_evil, comments, starting_role_id, final_role_id) " +
                        "VALUES (@Date, @Game_Won, @Is_Evil, @Comments, @Starting_Role_Id, @Final_Role_Id)";

            try
            {
                using var connection = _context.GetConnection();
                await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task DeleteGame(int gameId)
        {
            var parameters = new { Id = gameId };
            var query = "DELETE FROM games WHERE id = @Id";

            try
            {
                using var connection = _context.GetConnection();
                await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task EditGame(Game game, int gameId)
        {
            var parameters = new
            {
                Date = game.Date,
                Game_Won = game.Game_Won,
                Is_Evil = game.Is_Evil,
                Comments = game.Comments,
                Starting_Role_Id = game.Starting_Role_Id,
                Final_Role_Id = game.Final_Role_Id,
                Id = gameId
            };

            var query = "UPDATE games " +
                        "SET date = @Date, game_won = @Game_Won, is_evil = @Is_Evil, comments = @Comments, " +
                        "starting_role_id = @Starting_Role_Id, final_role_id = @Final_Role_Id WHERE id = @Id";
            try
            {
                using var connection = _context.GetConnection();
                await connection.ExecuteAsync(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

    }
}

