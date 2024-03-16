using Com.AppDellaFresca.Bus.Model.Games;

namespace Com.AppDellaFresca.API.Models;

public class PlayerData : IPlayerData
{
    public int PlayerId { get; set; }
    public double BetAmount { get; set; }
}
