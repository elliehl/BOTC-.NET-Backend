using BOTC.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BOTC.Models.DTOs;
using BOTC.Models;

namespace BOTC.Controllers
{
    [Route("api/[controller]/")]
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

        [HttpGet("{gameId}")]
        public async Task<IActionResult> GetGameById([FromRoute] int gameId)
        {
            var game = await _gamesService.GetGameById(gameId);
            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] AddGameDTO game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdGameId = await _gamesService.AddGame(game);
            var createdGame = _mapper.Map<AddGameResponse>(game);
            createdGame.Id = createdGameId;

            return CreatedAtAction("AddGame", createdGame);
        }

        [HttpDelete("/{gameId}")]
        public async Task<IActionResult> DeleteGame([FromRoute] int gameId)
        {
            await _gamesService.DeleteGame(gameId);
            return Ok("Game successfully deleted");
        }

        [HttpPut("/{gameId}")]
        public async Task<IActionResult> EditGame([FromBody] AddGameDTO game, [FromRoute] int gameId)
        {
            await _gamesService.EditGame(game, gameId);
            return Ok();
        }
    }

}

