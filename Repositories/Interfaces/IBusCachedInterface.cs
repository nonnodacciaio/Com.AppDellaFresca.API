using Com.AppDellaFresca.Bus.Model.Games;

namespace Com.AppDellaFresca.API.Repositories.Interfaces
{
    public interface IBusCachedInterface
    {
        IEnumerable<IGame> GetAllGames();
        void DeleteGame(IGame tratta);
        IGame UpdateGame(IGame game);
        IGame AddGame(IAddGameRequest game);
    }
}
