using Com.AppDellaFresca.API.Controllers.Helpers;
using Com.AppDellaFresca.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Com.AppDellaFresca.API.Controllers;

[Produces("application/json")]
[Route("api/v1/[controller]/[action]")]
public class GameController(ILogger<GameController> logger, GameHelper helper) : Controller
{
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Game[]), 200)]
    public IActionResult Get()
    {
        logger.LogInformation("Getting all games");
        return new JsonResult(helper.GetAllGames());
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Game), 200)]
    public IActionResult Get(int id)
    {
        logger.LogInformation("Getting game with id {0}", id);
        return new JsonResult(helper.GetGame(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] GameParams game)
    {
        logger.LogInformation("Creating new game");
        helper.CreateGame(game);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put([FromBody] Game game)
    {
        logger.LogInformation($"Updating game with id {game.Id}");
        helper.UpdateGame(game);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        logger.LogInformation($"Deleting game with id {id}");
        helper.DeleteGame(id);
        return NoContent();
    }
}
