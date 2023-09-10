using System;
using AutoMapper;
using BOTC.Models.DTOs;
using BOTC.Repository;

namespace BOTC.Services
{
	public class StatsService : IStatsService
	{
        private readonly IStatsRepository _statsRepository;

        public StatsService(IStatsRepository statsRepository)
        {
            _statsRepository = statsRepository;
        }

        public async Task<IEnumerable<StatsDTO>> GetStatsByRole()
        {
            return await _statsRepository.GetStatsByRole();
        }
    }
}

