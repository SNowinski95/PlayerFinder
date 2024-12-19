using System;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Command;
using Common.Database;
using GameAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
namespace GameAPI.Commands;
public sealed record AddGameCommand(GameCreate Game) : ICommand;

public sealed class AddGameCommandHander : ICommandHandler<AddGameCommand>
{
    private readonly IMongoCollection<Game> _collection;

    public AddGameCommandHander(IOptions<DatabaseConfig> databaseConfig)
    {
        databaseConfig = databaseConfig ?? throw new ArgumentNullException(nameof(databaseConfig));
        var mongoClient = new MongoClient(
            databaseConfig.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseConfig.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<Game>(
            databaseConfig.Value.CollectionName);
    }

    public async Task<Result> Handle(AddGameCommand command, CancellationToken cancellationToken)
    {
        var game = command.Game.GameMap();
        game.Id = ObjectId.GenerateNewId();
        return await _collection.InsertOneAsync(game, cancellationToken: cancellationToken).WrapQueryAsync();
    }
}

