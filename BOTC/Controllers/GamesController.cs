using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOTC.Services;
using BOTC.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gamesService;
        private readonly IMapper _mapper;

        public GamesController(IGamesService gamesService, IMapper mapper)
        {
            _gamesService = gamesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var games = await _gamesService.GetGames();
            return Ok(games);
        }

        [HttpGet("/{gameId}")]
        public async Task<IActionResult> GetGameById([FromRoute] int gameId)
        {
            var game = await _gamesService.GetGameById(gameId);
            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] Game game)
        {
            await _gamesService.AddGame(game);
            return Ok("Game successfully added");
        }

        [HttpDelete("/{gameId}")]
        public async Task<IActionResult> DeleteGame([FromRoute] int gameId)
        {
            await _gamesService.DeleteGame(gameId);
            return Ok("Game successfully deleted");
        }

        [HttpPut("/{gameId}")]
        public async Task<IActionResult> EditGame([FromBody] Game game, [FromRoute] int gameId)
        {
            await _gamesService.EditGame(game, gameId);
            return Ok("Game successfully edited");
        }
    }

}

