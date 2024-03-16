using Com.AppDellaFresca.API.Models;
using Com.AppDellaFresca.API.Repositories.Interfaces;

namespace Com.AppDellaFresca.API.Repositories;

public class GameRepository(IBusCachedInterface bus, ILogger<GameRepository> logger) : IGameRepository
{
    public Game AddGame(GameParams game)
    {
        var response = bus.AddGame(game);
        return new()
        {
            Date = response.Date,
            Id = response.Id,
            PlayersIds = response.PlayersIds,
            Result = response.Result
        };
    }

    public void DeleteGame(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Game> GetAllGames()
    {
        throw new NotImplementedException();
    }

    public Game GetGame(int id)
    {
        throw new NotImplementedException();
    }

    public Game UpdateGame(Game game)
    {
        throw new NotImplementedException();
    }
}
