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
using ZstdSharp;

namespace GameAPI.Commands;

public sealed record RemoveGameCommand(string GameId) : ICommand;
public sealed class RemoveGameCommandHander : ICommandHandler<RemoveGameCommand>
{
    private readonly IMongoCollection<Game> _collection;

    public RemoveGameCommandHander(IOptions<DatabaseConfig> databaseConfig)
    {
        databaseConfig = databaseConfig ?? throw new ArgumentNullException(nameof(databaseConfig));
        var mongoClient = new MongoClient(
            databaseConfig.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseConfig.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<Game>(
            databaseConfig.Value.CollectionName);
    }

    public async Task<Result> Handle(RemoveGameCommand command, CancellationToken cancellationToken)
    {
        var filter  = Builders<Game>.Filter.Eq(n => n.Id, ObjectId.Parse(command.GameId));
        return await _collection.DeleteOneAsync(filter, cancellationToken: cancellationToken).WrapQueryAsync();
    }
}