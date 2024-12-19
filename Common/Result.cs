namespace Common;

public enum RequestResult 
{
    Success, Failure, NotFound
}
public class Result
{
    public RequestResult RequestResult { get; set; }
    public string Message { get; set; }
    
    public static Result Success() => new() { RequestResult = RequestResult.Success, Message = string.Empty };
    public static Result Failure(string message) => new() { RequestResult = RequestResult.Failure, Message = message };
    public static Result NotFound(string id) => new() { RequestResult = RequestResult.NotFound, Message = $"Entity with id {id} not found" };
}
public class Result<TValue> : Result
{
    public TValue Value { get; set; }
    public static Result<TValue> Success(TValue value) => new() { RequestResult = RequestResult.Success, Message = string.Empty, Value = value };
    public new static Result<TValue> Failure(string message) => new() { RequestResult = RequestResult.Failure, Message = message };
    public new static Result<TValue> NotFound(string id) => new() { RequestResult = RequestResult.NotFound, Message = $"Entity with id {id} not found" };
}