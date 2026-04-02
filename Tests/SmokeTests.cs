using UiTestsPlaywright.Core;
using UiTestsPlaywright.Pages;
using UiTestsPlaywright.Pages.CheckoutPage;

namespace UiTestsPlaywright.Tests;

[Category("Smoke")]
public class SmokeTests : BaseTest
{
    [Test]
    public async Task App_Should_Open_Login_Page()
    {
        var loginPage = new LoginPage(Page);
        await loginPage.OpenLoginPageAsync();

        string title = await Page.TitleAsync();

        Assert.That(title, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task User_Can_Login()
    {
        var inventoryPage = new InventoryPage(Page);

        await LoginAsStandardUserAsync();

        Assert.That(await inventoryPage.IsInventoryPageVisibleAsync(), Is.True);
    }

    [Test]
    public async Task User_Can_Add_Product_To_Cart()
    {
        var inventoryPage = new InventoryPage(Page);
        var product = TestData.Onesie;

        await LoginAsStandardUserAsync();
        await inventoryPage.AddProductToCartAsync(product.Slug);

        Assert.That(await inventoryPage.GetCartItemCountAsync(), Is.EqualTo(1));
    }

    [Test]
    public async Task User_Can_Open_Cart()
    {
        var inventoryPage = new InventoryPage(Page);
        var cartPage = new CartPage(Page);

        await LoginAsStandardUserAsync();
        await inventoryPage.GoToCartAsync();

        Assert.That(await cartPage.IsCartPageVisibleAsync(), Is.True);
    }

    [Test]
    public async Task User_Can_Start_Checkout()
    {
        var checkoutStepOnePage = new CheckoutStepOnePage(Page);

        await LoginAsStandardUserAsync();
        await OrderAsStandartUserAsync();

        Assert.That(await checkoutStepOnePage.IsCheckoutStepOnePageVisibleAsync(), Is.True);
    }
}
