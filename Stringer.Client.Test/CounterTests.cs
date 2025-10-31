using Microsoft.AspNetCore.Components.Web;

namespace Stringer.Client.Test;

public class CounterTests : TestBase
{
    [Fact]
    public async Task Increment_And_Decrement_Success()
    {
        var ali = await NewTestPack("ali");
        var aliSes = await ali.Api.Auth.GetSession();
        ali.Ctx.JSInterop.Mode = JSRuntimeMode.Loose;
        ali.Ctx.JSInterop.SetupVoid("fcmInit");
        var aliUi = ali.Ctx.Render<Stringer.Client.Shared.Pages.Counter>(ps =>
            ps.Add(p => p.Session, aliSes).Add(p => p.User, aliSes.Id)
        );
        var aliIncBtn = aliUi.Find(".increment");
        await aliIncBtn.ClickAsync(new MouseEventArgs());
        aliUi.WaitForState(() => aliUi.Find(".val").TextContent == "1", TimeSpan.FromSeconds(1));
        var aliDecBtn = aliUi.Find(".decrement");
        await aliDecBtn.ClickAsync(new MouseEventArgs());
        aliUi.WaitForState(() => aliUi.Find(".val").TextContent == "0", TimeSpan.FromSeconds(1));
        await ali.Ctx.DisposeComponentsAsync();
    }
}
