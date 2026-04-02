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
        private ILocator ContinueShoppingButton => _page.Locator("[data-test = 'continue-shopping']");
        private ILocator YourCart => _page.Locator(".title:has-text('Your Cart')");

        public async Task ClickCheckoutButtonAsync()
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

        public async Task<InventoryPage> ClickContinueShoppingButtonAsync()
        {
            await ContinueShoppingButton.ClickAsync();
            return new InventoryPage(_page);
        }

        public async Task<bool> IsCartPageVisibleAsync()
        {
            return await YourCart.IsVisibleAsync();
        }
    }
}
