using Microsoft.Playwright;
using UiTestsPlaywright.Pages;

namespace UiTestsPlaywright.Tests;

public class BaseTest
{
    protected IPlaywright Playwright;
    protected IBrowser Browser;
    protected IPage Page;

    [SetUp]
    public async Task Setup()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        Page = await Browser.NewPageAsync();
    }

    protected async Task LoginAsStandardUserAsync()
    {
        var loginPage = new LoginPage(Page);
        await loginPage.OpenLoginPageAsync();
        await loginPage.LoginAsync("standard_user", "secret_sauce");
    }

    [TearDown]
    public async Task TearDown()
    {
        await Browser.CloseAsync();
        Playwright.Dispose();
    }
}
