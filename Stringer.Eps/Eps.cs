using Common.Server;
using Common.Server.Auth;
using Stringer.Db;

namespace Stringer.Eps;

public static class StringerEps
{
    private static IReadOnlyList<IEp>? _eps;
    public static IReadOnlyList<IEp> Eps
    {
        get
        {
            if (_eps == null)
            {
                var eps =
                    (List<IEp>)
                        new CommonEps<StringerDb>(
                            5,
                            true,
                            5,
                            CounterEps.OnAuthActivation,
                            CounterEps.OnAuthDelete,
                            CounterEps.AuthValidateFcmTopic
                        ).Eps;
                eps.AddRange(CounterEps.Eps);
                _eps = eps;
            }

            return _eps;
        }
    }
}
