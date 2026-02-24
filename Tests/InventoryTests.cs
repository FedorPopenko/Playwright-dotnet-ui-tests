using UiTestsPlaywright.Pages;

namespace UiTestsPlaywright.Tests;

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
        await _inventoryPage.AddProductToCartAsync("sauce-labs-backpack");

        Assert.That(await _inventoryPage.GetCartItemCountAsync(), Is.EqualTo(1));
    }

    [Test]
    public async Task Remove_Product_From_Cart_Should_Update_Badge()
    {
        await _inventoryPage.AddProductToCartAsync("sauce-labs-backpack");
        await _inventoryPage.RemoveProductFromInventoryAsync("sauce-labs-backpack");

        Assert.That(await _inventoryPage.GetCartItemCountAsync(), Is.EqualTo(0));
    }

    [Test]
    public async Task Add_Multiple_Products_Should_Update_Cart_Count()
    {
        await _inventoryPage.AddProductToCartAsync("sauce-labs-backpack");
        await _inventoryPage.AddProductToCartAsync("sauce-labs-bike-light");

        Assert.That(await _inventoryPage.GetCartItemCountAsync(), Is.EqualTo(2));
    }
}
