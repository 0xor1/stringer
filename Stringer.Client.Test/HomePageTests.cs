namespace Stringer.Client.Test;

public class HomePageTests : TestBase
{
    [Fact]
    public async Task PageWrapper_Success()
    {
        var ali = await NewTestPack("ali");
        ali.Ctx.Render<Stringer.Client.Pages.HomePage>();
        await ali.Ctx.DisposeComponentsAsync();
    }
}
