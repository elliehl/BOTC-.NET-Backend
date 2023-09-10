using System;
using BOTC.Models.DTOs;

namespace BOTC.Services
{
	public interface IStatsService
	{
        Task<IEnumerable<StatsDTO>> GetStatsByRole();
    }
}

