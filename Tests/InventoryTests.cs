using UiTestsPlaywright.Pages;

namespace UiTestsPlaywright.Tests;

[TestFixture]
public class InventoryTests : BaseTest
{
    private LoginPage _loginPage;
    private InventoryPage _inventoryPage;

    [SetUp]
    public async Task SetupPage()
    {
        _loginPage = new LoginPage(Page);
        _inventoryPage = new InventoryPage(Page);

        await _loginPage.OpenLoginPageAsync();
        await _loginPage.LoginAsync("standard_user", "secret_sauce");
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
        await _inventoryPage.RemoveProductFromCartAsync("sauce-labs-backpack");

        Assert.That(await _inventoryPage.GetCartItemCountAsync(), Is.EqualTo(0));
    }

    [Test]
    public async Task Product_Should_Be_Visible_On_Inventory_Page()
    {
        Assert.That(await _inventoryPage.IsProductVisibleAsync("Sauce Labs Backpack"), Is.True);
    }

    [Test]
    public async Task Add_Multiple_Products_Should_Update_Cart_Count()
    {
        await _inventoryPage.AddProductToCartAsync("sauce-labs-backpack");
        await _inventoryPage.AddProductToCartAsync("sauce-labs-bike-light");

        Assert.That(await _inventoryPage.GetCartItemCountAsync(), Is.EqualTo(2));
    }
}
