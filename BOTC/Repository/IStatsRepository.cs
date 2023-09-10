using System;
using BOTC.Models.DTOs;
using BOTC.Models.Entities;

namespace BOTC.Repository
{
	public interface IStatsRepository
	{
		Task<IEnumerable<StatsDTO>> GetStatsByRole();
	}
}

