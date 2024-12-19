namespace Common.Command;

public static class ResultHelper
{
    public static async Task<Result> WrapQueryAsync(this Task query)
    {
        try
        {
            await query;
            return Result.Success();
        }
        catch (Exception e)
        {
            return Result.Failure(e.Message);
        }
    }
    public static async Task<Result<T>> WrapQueryAsync<T>(this Task<T> query, string id)
    {
        try
        {
            var result = await query;
            return result == null ? Result<T>.NotFound(id) : Result<T>.Success(result);
        }
        catch (Exception e)
        {
            return Result<T>.Failure(e.Message);
        }
    }
    public static async Task<Result<T>> WrapQueryAsync<T>(this Task<T> query)
    {
        try
        {
            var result = await query;
            return Result<T>.Success(result);
        }
        catch (Exception e)
        {
            return Result<T>.Failure(e.Message);
        }
    }
}