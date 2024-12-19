using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Command;
using Common.Database;
using Common.Query;
using GameAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GameAPI.Queries;

public sealed record GetGamesQuery : IQuery<List<GameDto>>;

public class GetGamesQueryHander : IQueryHandler<GetGamesQuery, List<GameDto>>
{
    private readonly IMongoCollection<Game> _collection;

    public GetGamesQueryHander(IOptions<DatabaseConfig> databaseConfig)
    {
        databaseConfig = databaseConfig ?? throw new ArgumentNullException(nameof(databaseConfig));
        var mongoClient = new MongoClient(
            databaseConfig.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseConfig.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<Game>(
            databaseConfig.Value.CollectionName);
    }

    public async Task<Result<List<GameDto>>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
    {

        return await GetGames().WrapQueryAsync();
    }
    private async Task<List<GameDto>> GetGames()
    {
        var games = await _collection.Find(n => true).ToListAsync();
        return games.Select(n => new GameDto
        {
            Id = n.Id.ToString(),
            Name = n.Name,
            Teams = n.Teams,
            MaxPlayersInTeam = n.MaxPlayersInTeam
        }).ToList();
    }
}