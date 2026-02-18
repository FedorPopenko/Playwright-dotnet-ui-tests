using UiTestsPlaywright.Pages;

namespace UiTestsPlaywright.Tests;

[TestFixture]
public class LoginTests : BaseTest
{
    private LoginPage _loginPage;
    [SetUp]
    public async Task PageSetup()
    {
        _loginPage = new LoginPage(Page);
        await _loginPage.OpenLoginPageAsync();
    }

    [Test]
    public async Task SuccessfulLoginTest()
    {
        await _loginPage.LoginAsync("standard_user", "secret_sauce");

        Assert.That(await _loginPage.IsMainPageVisibleAsync(), Is.True);
    }

    [Test]
    public async Task Login_Should_Show_Error_When_Username_Is_Empty()
    {
        await _loginPage.EnterPasswordAsync("secret_sauce");
        await _loginPage.ClickLoginButtonAsync();

        Assert.That(await _loginPage.IsUsernameErrorVisibleAsync(), Is.True);
    }

    [Test]
    public async Task Login_Should_Show_Error_When_Password_Is_Empty()
    {
        await _loginPage.EnterUsernameAsync("standard_user");
        await _loginPage.ClickLoginButtonAsync();

        Assert.That(await _loginPage.IsPasswordErrorVisibleAsync(), Is.True);
    }

    [Test]
    public async Task Login_Should_Show_Error_When_Credentials_Are_Invalid()
    {
        await _loginPage.LoginAsync("wrong_user", "wrong_password");

        Assert.That(await _loginPage.IsUsernameAndPasswordErrorVisible(), Is.True);
    }
}
