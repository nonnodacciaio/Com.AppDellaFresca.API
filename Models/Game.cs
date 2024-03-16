namespace Com.AppDellaFresca.API.Models;

public class Game
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int[] PlayersIds { get; set; }
    public double? Result { get; set; }
}
