using Common.Client;
using Common.Server.Test;
using Radzen;
using Stringer.Api;
using Stringer.Db;
using Stringer.Eps;
using S = Stringer.I18n.S;

namespace Stringer.Client.Test;

public class TestBase : IDisposable
{
    protected readonly RpcTestRig<StringerDb, Api.Api> RpcTestRig;
    protected readonly List<TestPack> TestPacks = new();

    public TestBase()
    {
        RpcTestRig = new RpcTestRig<StringerDb, Api.Api>(
            S.Inst,
            StringerEps.Eps,
            c => new Api.Api(c)
        );
    }

    protected async Task<TestPack> NewTestPack(string name)
    {
        var (api, email, pwd) = await RpcTestRig.NewApi(name);
        var ctx = new BunitContext();
        var l = new Localizer(S.Inst);
        var ns = new NotificationService();
        Common.Client.Client.Setup(ctx.Services, l, S.Inst, ns, (IApi)api);
        var tp = new TestPack(api, ctx, email, pwd);
        TestPacks.Add(tp);
        return tp;
    }

    public void Dispose()
    {
        RpcTestRig.Dispose();
        TestPacks.ForEach(x => x.Ctx.Dispose());
    }
}

public record TestPack(IApi Api, BunitContext Ctx, string Email, string Pwd);
