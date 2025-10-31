using Common.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Stringer.Client.Test;

public class MainLayoutTest : TestBase
{
    [Fact]
    public async Task Load_Success()
    {
        var ali = await NewTestPack("ali");
        ali.Ctx.Render<Stringer.Client.Shared.MainLayout.MainLayout>();
        var auth = ali.Ctx.Services.GetRequiredService<IAuthService>();
        await auth.SignOut();
        await ali.Ctx.DisposeComponentsAsync();
    }

    [Fact]
    public async Task CollapseIfNarrow_Success()
    {
        var ali = await NewTestPack("ali");
        var aliUi = ali.Ctx.Render<Stringer.Client.Shared.MainLayout.MainLayout>();
        ali.Ctx.JSInterop.Mode = JSRuntimeMode.Loose;
        ali.Ctx.JSInterop.Setup<decimal>("getWidth").SetResult(23);
        aliUi.Find(".goto-home").Click();
        await ali.Ctx.DisposeComponentsAsync();
    }
}
