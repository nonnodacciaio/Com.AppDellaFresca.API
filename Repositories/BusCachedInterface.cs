using Com.AppDellaFresca.API.Repositories.Interfaces;
using Com.AppDellaFresca.Bus.Model.Games;
using MassTransit;

namespace Com.AppDellaFresca.API.Repositories;

public class BusCachedInterface(IRequestClient<IGetGamesRequest> getGamesClient, IRequestClient<IAddGameRequest> addGameClient, ILogger<IBusCachedInterface> logger) : IBusCachedInterface
{
    List<IGame> games;

    private Mutex mutex = new();

    public IGame AddGame(IAddGameRequest game)
    {
        return addGameClient.GetResponse<IAddGameResponse>(game).Result.Message;
    }

    public void DeleteGame(IGame tratta)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IGame> GetAllGames()
    {
        mutex.WaitOne();
        try
        {
            games ??= GetGamesFromBus().ToList();
        }
        finally
        {
            mutex.ReleaseMutex();
        }

        return games;
    }

    public IGame UpdateGame(IGame game)
    {
        throw new NotImplementedException();
    }

    private IEnumerable<IGame> GetGamesFromBus()
    {
        logger.LogTrace("Getting games from bus");

        try
        {
            var response = getGamesClient.GetResponse<IGetGamesResponse>(new { }).Result.Message;
            return response.Games;
        }
        catch (Exception ex)
        {
            var errorMsg = "Error getting games from bus";
            logger.LogError(ex, errorMsg);
            throw new RequestException(errorMsg, ex);
        }
    }
}
