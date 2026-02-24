using Microsoft.Playwright;

namespace UiTestsPlaywright.Pages
{
    public class CartPage
    {
        private readonly IPage _page;
        public CartPage(IPage page)
        {
            _page = page;
        }

        private ILocator CheckoutButton => _page.Locator("[data-test = 'checkout']");
        private ILocator RemoveFromCartButton(string productSlug) => _page.Locator($"#remove-{productSlug}");
        private ILocator ProductTitle(string productName) => _page.Locator($".inventory_item_name:has-text('{productName}')");

        public async Task ClickCheckoutAsync()
        {
            await CheckoutButton.ClickAsync();
        }

        public async Task RemoveProductFromCartAsync(string productSlug)
        {
            await RemoveFromCartButton(productSlug).ClickAsync();
        }

        public async Task<bool> IsProductInCartAsync(string productName)
        {
            return await ProductTitle(productName).IsVisibleAsync();
        }
    }
}
