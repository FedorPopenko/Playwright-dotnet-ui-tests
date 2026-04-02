using UiTestsPlaywright.Core;
using UiTestsPlaywright.Pages;

namespace UiTestsPlaywright.Tests
{
    [TestFixture]
    public class CartTests : BaseTest
    {
        private InventoryPage _inventoryPage;
        private CartPage _cartPage;

        [SetUp]
        public async Task SetupPage()
        {
            _inventoryPage = new InventoryPage(Page);
            _cartPage = new CartPage(Page);
            await LoginAsStandardUserAsync();
        }

        [Test]
        public async Task Product_Should_Be_Visible_On_Cart_Page()
        {
            var product = TestData.Backpack;

            await _inventoryPage.AddProductToCartAsync(product.Slug);
            await _inventoryPage.GoToCartAsync();

            Assert.That(await _cartPage.IsProductInCartAsync(product.Name), Is.True);
        }

        [Test]
        public async Task Multiple_Products_Should_Be_Visible_On_Cart_Page()
        {
            var product1 = TestData.Backpack;
            var product2 = TestData.BikeLight;

            await _inventoryPage.AddProductToCartAsync(product1.Slug);
            await _inventoryPage.AddProductToCartAsync(product2.Slug);
            await _inventoryPage.GoToCartAsync();

            Assert.That(await _cartPage.IsProductInCartAsync(product1.Name), Is.True);
            Assert.That(await _cartPage.IsProductInCartAsync(product2.Name), Is.True);
        }

        [Test]
        public async Task Product_Should_Be_Removed_From_Cart()
        {
            var product = TestData.FleeceJacket;

            await _inventoryPage.AddProductToCartAsync(product.Slug);
            await _inventoryPage.GoToCartAsync();

            await _cartPage.RemoveProductFromCartAsync(product.Slug);

            Assert.That(await _cartPage.IsProductInCartAsync(product.Name), Is.False);
        }

        [Test]
        public async Task Cart_Should_Proceed_To_Inventory_When_Click_ContinueShopping_Button()
        {
            var product = TestData.FleeceJacket;

            await _inventoryPage.AddProductToCartAsync(product.Slug);
            await _inventoryPage.GoToCartAsync();

            await _cartPage.ClickContinueShoppingButtonAsync();

            Assert.That(await _inventoryPage.IsInventoryPageVisibleAsync(), Is.True);
        }
    }
}
