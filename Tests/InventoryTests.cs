using UiTestsPlaywright.Core;
using UiTestsPlaywright.Pages;

namespace UiTestsPlaywright.Tests
{
    [TestFixture]
    public class InventoryTests : BaseTest
    {
        private InventoryPage _inventoryPage;

        [SetUp]
        public async Task SetupPage()
        {
            _inventoryPage = new InventoryPage(Page);
            await LoginAsStandardUserAsync();
        }

        [Test]
        public async Task Add_Product_To_Cart_Should_Update_Badge()
        {
            var product = TestData.Backpack;

            await _inventoryPage.AddProductToCartAsync(product.Slug);

            Assert.That(await _inventoryPage.GetCartItemCountAsync(), Is.EqualTo(1));
        }

        [Test]
        public async Task Remove_Product_From_Cart_Should_Update_Badge()
        {
            var product = TestData.Backpack;

            await _inventoryPage.AddProductToCartAsync(product.Slug);
            await _inventoryPage.RemoveProductFromInventoryAsync(product.Slug);

            Assert.That(await _inventoryPage.GetCartItemCountAsync(), Is.EqualTo(0));
        }

        [Test]
        public async Task Add_Multiple_Products_Should_Update_Cart_Count()
        {
            var product1 = TestData.Backpack;
            var product2 = TestData.BikeLight;

            await _inventoryPage.AddProductToCartAsync(product1.Slug);
            await _inventoryPage.AddProductToCartAsync(product2.Slug);

            Assert.That(await _inventoryPage.GetCartItemCountAsync(), Is.EqualTo(2));
        }
    }
}
