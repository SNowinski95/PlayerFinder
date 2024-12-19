using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GameAPI.Models;

public record Game
{
    [BsonElement("_id")]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; } = null!;
    [BsonElement("Teams")]
    public int Teams { get; set; }
    [BsonElement("MaxPLayersInTeam")]
    public int MaxPlayersInTeam { get; set; }
}

