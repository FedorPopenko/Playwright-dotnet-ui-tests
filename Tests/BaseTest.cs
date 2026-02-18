using Microsoft.Playwright;

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

    [TearDown]
    public async Task TearDown()
    {
        await Browser.CloseAsync();
        Playwright.Dispose();
    }
}
