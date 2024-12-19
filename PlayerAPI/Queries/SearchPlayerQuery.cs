using Common;
using Common.Database;
using Common.Query;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PlayerAPI.Models;

namespace PlayerAPI.Queries;

public record SearchPlayerQuery(SearchPlayerDto Search) : IQuery<SearchPlayerDto>;
public class SearchPlayerQueryHandler : IQueryHandler<SearchPlayerQuery, SearchPlayerDto>
{
    private readonly IMongoCollection<Player> _collection;
    public SearchPlayerQueryHandler(IOptions<DatabaseConfig> databaseConfig)
    {
        databaseConfig = databaseConfig ?? throw new ArgumentNullException(nameof(databaseConfig));
        var mongoClient = new MongoClient(
            databaseConfig.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(
            databaseConfig.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<Player>(
            databaseConfig.Value.CollectionName);
    }
    public async Task<Result<SearchPlayerDto>> Handle(SearchPlayerQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}