// Generated Code File, Do Not Edit.
// This file is generated with Common.Cli.
// see https://github.com/0xor1/common/blob/main/Common.Cli/Api.cs
// executed with arguments: api <abs_file_path_to>/Stringer.Api

using Common.Shared;
using Common.Shared.Auth;
using Stringer.Api.Counter;


namespace Stringer.Api;

public interface IApi : Common.Shared.Auth.IApi
{
    public ICounterApi Counter { get; }
    
}

public class Api : IApi
{
    public Api(IRpcClient client)
    {
        App = new AppApi(client);
        Auth = new AuthApi(client);
        Counter = new CounterApi(client);
        
    }

    public IAppApi App { get; }
    public IAuthApi Auth { get; }
    public ICounterApi Counter { get; }
    
}