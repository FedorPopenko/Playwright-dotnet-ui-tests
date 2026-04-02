using Microsoft.Playwright;

namespace UiTestsPlaywright.Pages.CheckoutPage
{
    public class CheckoutStepOnePage
    {
        private readonly IPage _page;

        public CheckoutStepOnePage(IPage page)
        {
            _page = page;
        }

        private ILocator FirstNameField => _page.Locator("#first-name");
        private ILocator LastNameField => _page.Locator("#last-name");
        private ILocator ZipPostalCodeField => _page.Locator("#postal-code");
        private ILocator ContinueButton => _page.Locator("[data-test='continue']");
        private ILocator CancelButton => _page.Locator("[data-test='cancel']");
        private ILocator ErrorMessage => _page.Locator("[data-test='error']");
        private ILocator YourInformation => _page.Locator(".title:has-text('Checkout: Your Information')");

        public async Task FillUserInformationAsync(string firstName, string lastName, string zipPostalCode)
        {
            await FirstNameField.FillAsync(firstName);
            await LastNameField.FillAsync(lastName);
            await ZipPostalCodeField.FillAsync(zipPostalCode);
        }

        public async Task ClickContinueButtonAsync()
        {
            await ContinueButton.ClickAsync();
        }

        public async Task<CartPage> ClickCancelButtonAsync()
        {
            await CancelButton.ClickAsync();
            return new CartPage(_page);
        }

        public async Task<string> GetErrroMessageAsync()
        {
            return await ErrorMessage.InnerTextAsync();
        }

        public async Task<bool> IsCheckoutStepOnePageVisibleAsync()
        {
            return await YourInformation.IsVisibleAsync();
        }
    }
}
