using MongoDB.Bson.Serialization.Attributes;

namespace PlayerAPI.Models;

public class PlayerDto
{
    public string Id { get; set; }

    public string Name { get; set; }
}