using Com.AppDellaFresca.Bus.Model.Games;

namespace Com.AppDellaFresca.API.Models;

public class GameParams : IAddGameRequest
{
    public DateTime Date { get; set; }
    public IPlayerData[] PlayerData { get; set; }
}
