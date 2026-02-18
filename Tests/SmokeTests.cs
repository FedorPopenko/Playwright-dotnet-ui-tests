using UiTestsPlaywright.Pages;

namespace UiTestsPlaywright.Tests;


public class SmokeTests : BaseTest
{
    [Test]
    public async Task OpenLoginPage()
    {
        var loginPage = new LoginPage(Page);
        await loginPage.OpenLoginPageAsync();

        string title = await Page.TitleAsync();

        Assert.That(title, Is.Not.Null.And.Not.Empty);
    }
}
