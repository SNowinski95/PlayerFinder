using Common;
using Common.Command;
using Common.Database;
using Common.Query;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PlayerAPI.Models;

namespace PlayerAPI.Queries;

public sealed record GetPlayerQuery(Guid Id) : IQuery<PlayerDto>;
public class GetPlayerQueryHander : IQueryHandler<GetPlayerQuery, PlayerDto>
{
    private readonly IMongoCollection<Player> _collection;

    public GetPlayerQueryHander(IOptions<DatabaseConfig> databaseConfig)
    {
        databaseConfig = databaseConfig ?? throw new ArgumentNullException(nameof(databaseConfig));
        var mongoClient = new MongoClient(
        databaseConfig.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(
            databaseConfig.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<Player>(
            databaseConfig.Value.CollectionName);
    }
    public async Task<Result<PlayerDto>> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
    {
        var res= await _collection.Find(n => n.Id == request.Id.ToString()).SingleOrDefaultAsync(cancellationToken).WrapQueryAsync(request.Id);
        var dto = res.Value.PlayerMap();
        if(res.RequestResult == RequestResult.Failure)
        {
            return Result<PlayerDto>.Failure(res.Message);
        }
        return Result<PlayerDto>.Success(dto);

    }
}