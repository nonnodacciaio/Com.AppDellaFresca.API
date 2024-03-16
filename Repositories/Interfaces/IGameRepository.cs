using Com.AppDellaFresca.API.Models;

namespace Com.AppDellaFresca.API.Repositories.Interfaces;

public interface IGameRepository
{
    Game AddGame(GameParams game);
    void DeleteGame(int id);
    IEnumerable<Game> GetAllGames();
    Game GetGame(int id);
    Game UpdateGame(Game game);
}
