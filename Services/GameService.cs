using Com.AppDellaFresca.API.Models;
using Com.AppDellaFresca.API.Repositories.Interfaces;
using Com.AppDellaFresca.API.Services.Interfaces;

namespace Com.AppDellaFresca.API.Services;

public class GameService(IGameRepository repository) : IGameService
{
    public Game AddGame(GameParams game)
    {
        return repository.AddGame(game);
    }

    public void DeleteGame(int id)
    {
        repository.DeleteGame(id);
    }

    public IEnumerable<Game> GetAllGames()
    {
        return repository.GetAllGames();
    }

    public Game GetGame(int id)
    {
        return repository.GetGame(id);
    }

    public Game UpdateGame(Game game)
    {
        return repository.UpdateGame(game);
    }
}
