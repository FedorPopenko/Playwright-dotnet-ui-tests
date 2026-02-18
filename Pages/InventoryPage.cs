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
        private ILocator RemoveFromCartButton(string productSlug) => _page.Locator($"#remove-{productSlug}");
        private ILocator CartBadge => _page.Locator(".shopping_cart_badge");
        private ILocator ProductTitle(string productName) => _page.Locator($".inventory_item_name:has-text('{productName}')");

        public async Task AddProductToCartAsync(string productSlug)
        {
            await AddToCartButton(productSlug).ClickAsync();
        }

        public async Task RemoveProductFromCartAsync(string productSlug)
        {
            await RemoveFromCartButton(productSlug).ClickAsync();
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

        public async Task<bool> IsProductVisibleAsync(string productName)
        {
            return await ProductTitle(productName).IsVisibleAsync();
        }
    }
}
