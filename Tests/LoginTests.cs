using UiTestsPlaywright.Core;
using UiTestsPlaywright.Pages;

namespace UiTestsPlaywright.Tests
{
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
            var username = TestData.StandardUser;
            var password = TestData.Password;

            await _loginPage.LoginAsync(username, password);

            var inventoryPage = new InventoryPage(Page);

            Assert.That(await inventoryPage.IsInventoryPageVisibleAsync(), Is.True);
        }

        [Test]
        public async Task Login_Should_Show_Error_When_Username_Is_Empty()
        {
            var password = TestData.Password;

            await _loginPage.EnterPasswordAsync(password);
            await _loginPage.ClickLoginButtonAsync();

            Assert.That(await _loginPage.IsUsernameErrorVisibleAsync(), Is.True);
        }

        [Test]
        public async Task Login_Should_Show_Error_When_Password_Is_Empty()
        {
            var username = TestData.StandardUser;

            await _loginPage.EnterUsernameAsync(username);
            await _loginPage.ClickLoginButtonAsync();

            Assert.That(await _loginPage.IsPasswordErrorVisibleAsync(), Is.True);
        }

        [Test]
        public async Task Login_Should_Show_Error_When_Credentials_Are_Invalid()
        {
            var username = TestData.WrongUser;
            var password = TestData.WrongPassword;

            await _loginPage.LoginAsync(username, password);

            Assert.That(await _loginPage.IsUsernameAndPasswordErrorVisible(), Is.True);
        }
    }
}
