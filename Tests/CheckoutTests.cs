using UiTestsPlaywright.Core;
using UiTestsPlaywright.Pages.CheckoutPage;

namespace UiTestsPlaywright.Tests
{
    [TestFixture]
    public class CheckoutTests : BaseTest
    {
        private CheckoutStepOnePage _checkoutStepOnePage;
        private CheckoutStepTwoPage _checkoutStepTwoPage;
        private CheckoutCompletePage _checkoutCompletePage;

        [SetUp]
        public async Task SetupPage()
        {
            _checkoutCompletePage = new CheckoutCompletePage(Page);
            _checkoutStepOnePage = new CheckoutStepOnePage(Page);
            _checkoutStepTwoPage = new CheckoutStepTwoPage(Page);

            await LoginAsStandardUserAsync();
            await OrderAsStandartUserAsync();
        }

        [Test]
        public async Task Checkout_Should_Show_Error_When_FirstName_Is_Empty()
        {
            var lastName = TestData.LastName;
            var postalCode = TestData.PostalCode;
            var error = TestData.ErrorFirstName;

            await _checkoutStepOnePage.FillUserInformationAsync("", lastName, postalCode);
            await _checkoutStepOnePage.ClickContinueButtonAsync();

            Assert.That(await _checkoutStepOnePage.GetErrroMessageAsync(), Is.EqualTo(error));
        }

        [Test]
        public async Task Checkout_Should_Show_Error_When_LastName_Is_Empty()
        {
            var firstName = TestData.FirstName;
            var postalCode = TestData.PostalCode;
            var error = TestData.ErrorLastName;

            await _checkoutStepOnePage.FillUserInformationAsync(firstName, "", postalCode);
            await _checkoutStepOnePage.ClickContinueButtonAsync();

            Assert.That(await _checkoutStepOnePage.GetErrroMessageAsync(), Is.EqualTo(error));
        }

        [Test]
        public async Task Checkout_Should_Show_Error_When_ZipPostalCode_Is_Empty()
        {
            var firstName = TestData.FirstName;
            var lastName = TestData.LastName;
            var error = TestData.ErrorPostalCode;

            await _checkoutStepOnePage.FillUserInformationAsync(firstName, lastName, "");
            await _checkoutStepOnePage.ClickContinueButtonAsync();

            Assert.That(await _checkoutStepOnePage.GetErrroMessageAsync(), Is.EqualTo(error));
        }

        [Test]
        public async Task Checkout_Should_Proceed_To_Overview_When_Data_Is_Valid()
        {
            var firstName = TestData.FirstName;
            var lastName = TestData.LastName;
            var postalCode = TestData.PostalCode;

            await _checkoutStepOnePage.FillUserInformationAsync(firstName, lastName, postalCode);
            await _checkoutStepOnePage.ClickContinueButtonAsync();

            Assert.That(await _checkoutStepTwoPage.GetItemsCountAsync(), Is.EqualTo(1));
        }

        [Test]
        public async Task Checkout_Should_Proceed_To_Cart_When_Cancel_Button_Is_Click()
        {
            var cartPage = await _checkoutStepOnePage.ClickCancelButtonAsync();

            Assert.That(await cartPage.IsCartPageVisibleAsync(), Is.True);
        }

        [Test]
        public async Task Checkout_Should_Proceed_To_Inventory_When_Data_Is_Valid_And_Click_Cancel_Button()
        {
            var firstName = TestData.FirstName;
            var lastName = TestData.LastName;
            var postalCode = TestData.PostalCode;

            await _checkoutStepOnePage.FillUserInformationAsync(firstName, lastName, postalCode);
            await _checkoutStepOnePage.ClickContinueButtonAsync();

            var inventoryPage = await _checkoutStepTwoPage.ClickCancelButton();

            Assert.That(await inventoryPage.IsInventoryPageVisibleAsync(), Is.True);
        }

        [Test]
        public async Task Checkout_Should_Proceed_To_Complete_When_Data_Is_Valid_And_Click_Finish_Button()
        {
            var firstName = TestData.FirstName;
            var lastName = TestData.LastName;
            var postalCode = TestData.PostalCode;

            await _checkoutStepOnePage.FillUserInformationAsync(firstName, lastName, postalCode);
            await _checkoutStepOnePage.ClickContinueButtonAsync();

            await _checkoutStepTwoPage.ClickFinishButton();

            Assert.That(await _checkoutCompletePage.IsOrderCompleteAsunc(), Is.True);
        }

        [Test]
        public async Task Checkout_Should_Proceed_To_Inventory_When_Data_Is_Valid_And_Click_BackHome_Button()
        {
            var firstName = TestData.FirstName;
            var lastName = TestData.LastName;
            var postalCode = TestData.PostalCode;

            await _checkoutStepOnePage.FillUserInformationAsync(firstName, lastName, postalCode);
            await _checkoutStepOnePage.ClickContinueButtonAsync();
            await _checkoutStepTwoPage.ClickFinishButton();

            var inventoryPage = await _checkoutCompletePage.ClickBackHomeButtonAsync();

            Assert.That(await inventoryPage.IsInventoryPageVisibleAsync(), Is.True);
        }
    }
}


