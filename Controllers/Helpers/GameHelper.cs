using Com.AppDellaFresca.API.Models;
using Com.AppDellaFresca.API.Services.Interfaces;

namespace Com.AppDellaFresca.API.Controllers.Helpers;

public class GameHelper(IGameService gameService)
{
    public IEnumerable<Game> GetAllGames()
    {
        return gameService.GetAllGames();
    }

    public Game GetGame(int id)
    {
        return gameService.GetGame(id);
    }

    public Game CreateGame(GameParams game)
    {
        return gameService.AddGame(game);
    }

    public Game UpdateGame(Game game)
    {
        return gameService.UpdateGame(game);
    }

    public void DeleteGame(int id)
    {
        gameService.DeleteGame(id);
    }
}
