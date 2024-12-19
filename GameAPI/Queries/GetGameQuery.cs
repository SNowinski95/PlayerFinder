using System;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Command;
using Common.Database;
using Common.Query;
using GameAPI.Models;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GameAPI.Queries;
public sealed record GetGameQuery(ObjectId Id) : IQuery<Game>;

public sealed class GetGameQueryHander : IQueryHandler<GetGameQuery, Game>
{
    private readonly IMongoCollection<Game> _collection;

    public GetGameQueryHander(IOptions<DatabaseConfig> databaseConfig)
    {
        databaseConfig = databaseConfig ?? throw new ArgumentNullException(nameof(databaseConfig));
        var mongoClient = new MongoClient(
            databaseConfig.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseConfig.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<Game>(
            databaseConfig.Value.CollectionName);
    }
    

    public async Task<Result<Game>> Handle(GetGameQuery request, CancellationToken cancellationToken)
    {
        return await _collection.Find(n => n.Id == request.Id).SingleOrDefaultAsync(cancellationToken).WrapQueryAsync(request.Id.ToString());
    }
}
