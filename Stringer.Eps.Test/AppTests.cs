using Common.Server.Test;
using Stringer.Db;
using S = Stringer.I18n.S;

namespace Stringer.Eps.Test;

public class AppTests : IDisposable
{
    private readonly RpcTestRig<StringerDb, Api.Api> Rig;

    public AppTests()
    {
        Rig = new RpcTestRig<StringerDb, Api.Api>(S.Inst, StringerEps.Eps, c => new Api.Api(c));
    }

    [Fact]
    public async void GetConfig_Success()
    {
        var (ali, _, _) = await Rig.NewApi("ali");
        var c = await ali.App.GetConfig();
        Assert.True(c.DemoMode);
        Assert.Equal("https://github.com/0xor1/stringer", c.RepoUrl);
    }

    public void Dispose()
    {
        Rig.Dispose();
    }
}
