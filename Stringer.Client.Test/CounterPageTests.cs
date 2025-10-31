namespace Stringer.Client.Test;

public class CounterPageTests : TestBase
{
    [Fact]
    public async Task PageWrapper_Success()
    {
        var ali = await NewTestPack("ali");
        ali.Ctx.Render<Stringer.Client.Pages.CounterPage>();
        await ali.Ctx.DisposeComponentsAsync();
    }
}
