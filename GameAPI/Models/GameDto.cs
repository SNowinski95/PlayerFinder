using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GameAPI.Models;

public class GameDto
{
    public string Id { get; set; }

    public string Name { get; set; } = null!;
    public int Teams { get; set; }
    public int MaxPlayersInTeam { get; set; }
}