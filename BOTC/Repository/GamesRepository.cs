using System;
using Dapper;
using BOTC.Models.Entities;
using BOTC.Data;
using BOTC.Models.DTOs;

namespace BOTC.Repository
{
	public class GamesRepository: IGamesRepository
	{
        private readonly IContext _context;

        public GamesRepository(IContext context)
		{
            _context = context;
        }

        public async Task<IEnumerable<GameEntity>> GetGames()
        {
            IEnumerable<GameEntity> games = new List<GameEntity>();

            try
            {
                using var connection =  _context.GetConnection();
                var query = "SELECT g.id, date, game_won, is_evil, comments, r.name AS starting_role, r1.name as final_role, t.name as                                                                                       type " +
                  "FROM games g " +
                  "JOIN roles r ON r.id = g.starting_role_id " +
                  "JOIN roles r1 ON r1.id = g.final_role_id " +
                  "JOIN types t ON t.id = r.type_id";
                games = await connection.QueryAsync<GameEntity>(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return games;
        }

        public async Task<GameEntity> GetGameById(int gameId)
        {
            GameEntity game = new GameEntity();
            var parameters = new { Id = gameId };
            var query = "SELECT g.id, date, game_won, is_evil, comments, r.name AS starting_role, r1.name as final_role, t.name as                                                                                       type " +
                  "FROM games g " +
                  "JOIN roles r ON r.id = g.starting_role_id " +
                  "JOIN roles r1 ON r1.id = g.final_role_id " +
                  "JOIN types t ON t.id = r.type_id " +
                  "WHERE g.id = @Id ";

            try
            {
                using var connection = _context.GetConnection();
                game = await connection.QueryFirstAsync<GameEntity>(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return game;
        }

        public async Task<int> AddGame(GameDTO game)
        {
            var parameters = new { Date = game.Date, Game_Won = game.Game_Won, Is_Evil = game.Is_Evil, Comments = game.Comments,
                                   Starting_Role_Id = game.Starting_Role_Id, Final_Role_Id = game.Final_Role_Id};

            var query = "INSERT INTO games (date, game_won, is_evil, comments, starting_role_id, final_role_id) " +
                        "VALUES (@Date, @Game_Won, @Is_Evil, @Comments, @Starting_Role_Id, @Final_Role_Id); " +
                        "SELECT LAST_INSERT_ID()";

            try
            {
                using var connection = _context.GetConnection();
                return await connection.ExecuteScalarAsync<int>(query, parameters);
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

        public async Task EditGame(GameDTO game, int gameId)
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

        public async Task<int> GetRoleId(string role)
        {
            var parameters = new
            {
                Role = role
            };

            var query = "SELECT id FROM roles WHERE name = @Role";

            try
            {
                using var connection = _context.GetConnection();
                int Id = await connection.QuerySingleAsync<int>(query, parameters);
                return Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            } 
        }
    }
}