using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayerAPI.Models;

public class Player
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")] 
    public string Name { get; set; }

    public PlayerDto PlayerMap()
    {
        return new PlayerDto
        {
            Id = Id,
            Name = Name
        };
    }



}
