using System;
using BOTC.Repository;
using BOTC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BOTC.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]

    public class StatsController: ControllerBase
	{
        private readonly IStatsService _statsService;

        public StatsController(IStatsService statsService)
		{
            _statsService = statsService;
		}

        [HttpGet]
        public async Task<IActionResult> GetStatsByRole()
        {
            var roleStats = await _statsService.GetStatsByRole();
            return Ok(roleStats);
        }
    }
}

