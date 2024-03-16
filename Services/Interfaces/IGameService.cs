using Com.AppDellaFresca.API.Models;

namespace Com.AppDellaFresca.API.Services.Interfaces;

public interface IGameService
{
    IEnumerable<Game> GetAllGames();
    Game GetGame(int id);
    Game AddGame(GameParams game);
    Game UpdateGame(Game game);
    void DeleteGame(int id);
}
