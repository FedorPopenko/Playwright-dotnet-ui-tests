using Microsoft.Playwright;

namespace UiTestsPlaywright.Pages.CheckoutPage
{
    public class CheckoutStepTwoPage
    {
        private readonly IPage _page;
        public CheckoutStepTwoPage(IPage page)
        {
            _page = page;
        }

        private ILocator FinishButton => _page.Locator("[data-test='finish']");
        private ILocator CancelButton => _page.Locator("[data-test='cancel']");
        private ILocator CartItems => _page.Locator(".cart_item");

        public async Task ClickFinishButton()
        {
            await FinishButton.ClickAsync();
        }

        public async Task<InventoryPage> ClickCancelButton()
        {
            await CancelButton.ClickAsync();
            return new InventoryPage(_page);
        }

        public async Task<int> GetItemsCountAsync()
        {
            return await CartItems.CountAsync();
        }
    }
}
