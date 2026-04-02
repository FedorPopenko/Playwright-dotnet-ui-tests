using Microsoft.Playwright;

namespace UiTestsPlaywright.Pages.CheckoutPage
{
    public class CheckoutCompletePage
    {
        private readonly IPage _page;

        public CheckoutCompletePage(IPage page)
        {
            _page = page;
        }

        private ILocator CompleteHeader => _page.Locator(".complete-header");
        private ILocator BackHomeButton => _page.Locator("[data-test='back-to-products']");

        public async Task<bool> IsOrderCompleteAsunc()
        {
            return await CompleteHeader.IsVisibleAsync();
        }

        public async Task<InventoryPage> ClickBackHomeButtonAsync()
        {
            await BackHomeButton.ClickAsync();
            return new InventoryPage(_page);
        }
    }
}
