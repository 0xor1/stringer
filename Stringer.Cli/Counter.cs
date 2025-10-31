using Stringer.Api;

namespace Stringer.Cli;

public class Counter
{
    private readonly IApi _api;

    public Counter(IApi api)
    {
        _api = api;
    }

    /// <summary>
    /// Increment your counter
    /// </summary>
    public async Task Increment(CancellationToken ctkn = default) =>
        Io.WriteYml(await _api.Counter.Increment(ctkn));

    /// <summary>
    /// Decrement your counter
    /// </summary>
    public async Task Decrement(CancellationToken ctkn = default) =>
        Io.WriteYml(await _api.Counter.Decrement(ctkn));

    /// <summary>
    /// Get a users counter, defaults to yours
    /// </summary>
    /// <param name="user">-u, The user id to get the counter for</param>
    public async Task Get(string? user = null, CancellationToken ctkn = default) =>
        Io.WriteYml(await _api.Counter.Get(new() { User = user }, ctkn));
}
