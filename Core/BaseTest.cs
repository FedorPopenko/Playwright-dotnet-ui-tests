using Microsoft.Playwright;
using UiTestsPlaywright.Pages;
using UiTestsPlaywright.Pages.CheckoutPage;

namespace UiTestsPlaywright.Core
{
    public class BaseTest
    {
        protected IPlaywright Playwright;
        protected IBrowser Browser;
        protected IPage Page;

        [SetUp]
        public async Task Setup()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            Page = await Browser.NewPageAsync();
        }

        protected async Task LoginAsStandardUserAsync()
        {
            var loginPage = new LoginPage(Page);
            var username = TestData.StandardUser;
            var password = TestData.Password;

            await loginPage.OpenLoginPageAsync();
            await loginPage.LoginAsync(username, password);
        }

        protected async Task OrderAsStandartUserAsync()
        {
            var inventoryPage = new InventoryPage(Page);
            var product = TestData.Backpack;

            await inventoryPage.AddProductToCartAsync(product.Slug);
            await inventoryPage.GoToCartAsync();

            var cartPage = new CartPage(Page);
            await cartPage.ClickCheckoutButtonAsync();
        }

        protected async Task CheckoutAsStandartUserAsync()
        {
            var checkoutStepOne = new CheckoutStepOnePage(Page);
            var firstName = TestData.FirstName;
            var lastName = TestData.LastName;
            var postalCode = TestData.PostalCode;

            await checkoutStepOne.FillUserInformationAsync(firstName, lastName, postalCode);
            await checkoutStepOne.ClickContinueButtonAsync();

            var checkoutStepTwo = new CheckoutStepTwoPage(Page);
            await checkoutStepTwo.ClickFinishButton();
        }

        [TearDown]
        public async Task TearDown()
        {
            await Browser.CloseAsync();
            Playwright.Dispose();
        }
    }
}