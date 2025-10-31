// Generated Code File, Do Not Edit.
// This file is generated with Common.Cli.
// see https://github.com/0xor1/common/blob/main/Common.Cli/Api.cs
// executed with arguments: api <abs_file_path_to>/Stringer.Api

#nullable enable

using Common.Shared;
using MessagePack;


namespace Stringer.Api.Counter;

public interface ICounterApi
{
    public Task<Counter> Get(Get arg, CancellationToken ctkn = default);
    public Task<Counter> Increment(CancellationToken ctkn = default);
    public Task<Counter> Decrement(CancellationToken ctkn = default);
    
}

public class CounterApi : ICounterApi
{
    private readonly IRpcClient _client;

    public CounterApi(IRpcClient client)
    {
        _client = client;
    }

    public Task<Counter> Get(Get arg, CancellationToken ctkn = default) =>
        _client.Do(CounterRpcs.Get, arg, ctkn);
    
    public Task<Counter> Increment(CancellationToken ctkn = default) =>
        _client.Do(CounterRpcs.Increment, Nothing.Inst, ctkn);
    
    public Task<Counter> Decrement(CancellationToken ctkn = default) =>
        _client.Do(CounterRpcs.Decrement, Nothing.Inst, ctkn);
    
    
}

public static class CounterRpcs
{
    public static readonly Rpc<Get, Counter> Get = new("/counter/get");
    public static readonly Rpc<Nothing, Counter> Increment = new("/counter/increment");
    public static readonly Rpc<Nothing, Counter> Decrement = new("/counter/decrement");
    
}



[MessagePackObject]
public record Counter
{
    public Counter(
        string user,
        uint value
        
    )
    {
        User = user;
        Value = value;
        
    }
    
    [Key(0)]
    public string User { get; set; }
    [Key(1)]
    public uint Value { get; set; }
    
}



[MessagePackObject]
public record Get
{
    public Get(
        string? user = null
        
    )
    {
        User = user;
        
    }
    
    [Key(0)]
    public string? User { get; set; } = null;
    
}



