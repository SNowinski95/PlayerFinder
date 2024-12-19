using MongoDB.Bson.Serialization.Attributes;

namespace GameAPI.Models;

public class GameCreate
{
    public string Name { get; set; } = null!;
    public int Teams { get; set; }
    public int MaxPlayersInTeam { get; set; }

    public Game GameMap()
    {
        return new Game
        {
            Name = Name,
            Teams = Teams,
            MaxPlayersInTeam = MaxPlayersInTeam
        };
    }
}