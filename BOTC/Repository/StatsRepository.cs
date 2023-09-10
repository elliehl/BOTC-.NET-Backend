using System;
using BOTC.Data;
using BOTC.Models.DTOs;
using BOTC.Models.Entities;
using Dapper;

namespace BOTC.Repository
{
	public class StatsRepository : IStatsRepository
	{
        private readonly IContext _context;

        public StatsRepository(IContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StatsDTO>> GetStatsByRole()
        {
            IEnumerable<StatsDTO> statsByRole = new List<StatsDTO>();

            try
            {
                using var connection = _context.GetConnection();
                var query = "SELECT r.name AS starting_role, " +
                            "COUNT(g.id) AS games, " +
                            "sum(case when game_won = 1 then 1 else 0 end) AS wins " +
                            "FROM games g " +
                            "JOIN roles r ON r.id = g.starting_role_id " +
                            "GROUP BY starting_role";
                statsByRole = await connection.QueryAsync<StatsDTO>(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return statsByRole;
        }
    }
}

