using Microsoft.Playwright;

namespace UiTestsPlaywright.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        private ILocator Username => _page.Locator("#user-name");
        private ILocator Password => _page.Locator("#password");
        private ILocator LoginButton => _page.Locator("#login-button");
        private ILocator ErrorMessageUsername => _page.Locator("[data-test='error']:has-text('Username is required')");
        private ILocator ErrorMessagePassword => _page.Locator("[data-test='error']:has-text('Password is required')");
        private ILocator ErrorMessageUsernameAndPassword => _page.Locator("[data-test='error']:has-text('Username and password do not match')");
        private ILocator MainPage => _page.Locator(".app_logo:has-text('Swag Labs')");

        private static string LoginPageUrl { get; } = "https://www.saucedemo.com/";

        public async Task OpenLoginPageAsync()
        {
            await _page.GotoAsync(LoginPageUrl);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        public async Task EnterUsernameAsync(string username)
        {
            await Username.FillAsync(username);
        }

        public async Task EnterPasswordAsync(string password)
        {
            await Password.FillAsync(password);
        }

        public async Task ClickLoginButtonAsync()
        {
            await LoginButton.ClickAsync();
        }

        public async Task LoginAsync(string username, string password)
        {
            await EnterUsernameAsync(username);
            await EnterPasswordAsync(password);
            await ClickLoginButtonAsync();
        }

        public async Task<bool> IsUsernameErrorVisibleAsync()
        {
            return await ErrorMessageUsername.IsVisibleAsync();
        }

        public async Task<bool> IsPasswordErrorVisibleAsync()
        {
            return await ErrorMessagePassword.IsVisibleAsync();
        }

        public async Task<bool> IsUsernameAndPasswordErrorVisible()
        {
            return await ErrorMessageUsernameAndPassword.IsVisibleAsync();
        }

        public async Task<bool> IsMainPageVisibleAsync()
        {
            return await MainPage.IsVisibleAsync();
        }
    }
}
