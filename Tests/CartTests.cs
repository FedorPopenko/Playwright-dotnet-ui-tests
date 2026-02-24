using UiTestsPlaywright.Pages;
using UiTestsPlaywright.Tests;

namespace UiTestsPlaywright;

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
        await _inventoryPage.AddProductToCartAsync("sauce-labs-backpack");
        await _inventoryPage.GoToCartAsync();

        Assert.That(await _cartPage.IsProductInCartAsync("Sauce Labs Backpack"), Is.True);
    }

    [Test]
    public async Task Multiple_Products_Should_Be_Visible_On_Cart_Page()
    {
        await _inventoryPage.AddProductToCartAsync("sauce-labs-backpack");
        await _inventoryPage.AddProductToCartAsync("sauce-labs-bike-light");
        await _inventoryPage.GoToCartAsync();

        Assert.That(await _cartPage.IsProductInCartAsync("Sauce Labs Backpack"), Is.True);
        Assert.That(await _cartPage.IsProductInCartAsync("Sauce Labs Bike Light"), Is.True);
    }

    [Test]
    public async Task Product_Should_Be_Removed_From_Cart()
    {
        await _inventoryPage.AddProductToCartAsync("sauce-labs-fleece-jacket");
        await _inventoryPage.GoToCartAsync();

        await _cartPage.RemoveProductFromCartAsync("sauce-labs-fleece-jacket");

        Assert.That(await _cartPage.IsProductInCartAsync("Sauce Labs Fleece Jacket"), Is.False);
    }
}
