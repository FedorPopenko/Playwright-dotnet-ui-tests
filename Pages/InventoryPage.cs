using Microsoft.Playwright;

namespace UiTestsPlaywright.Pages
{
    public class InventoryPage
    {
        private readonly IPage _page;

        public InventoryPage(IPage page)
        {
            _page = page;
        }

        private ILocator AddToCartButton(string productSlug) => _page.Locator($"#add-to-cart-{productSlug}");
        private ILocator RemoveFromInventoryButton(string productSlug) => _page.Locator($"#remove-{productSlug}");
        private ILocator CartBadge => _page.Locator(".shopping_cart_badge");
        private ILocator CartLink => _page.Locator("[data-test='shopping-cart-link']");

        public async Task AddProductToCartAsync(string productSlug)
        {
            await AddToCartButton(productSlug).ClickAsync();
        }

        public async Task RemoveProductFromInventoryAsync(string productSlug)
        {
            await RemoveFromInventoryButton(productSlug).ClickAsync();
        }

        public async Task<int> GetCartItemCountAsync()
        {
            if (await CartBadge.IsVisibleAsync())
            {
                var text = await CartBadge.InnerTextAsync();
                return int.Parse(text);
            }
            return 0;
        }

        public async Task GoToCartAsync()
        {
            await CartLink.ClickAsync();
        }
    }
}
