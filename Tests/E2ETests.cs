using UiTestsPlaywright.Core;
using UiTestsPlaywright.Pages.CheckoutPage;

namespace UiTestsPlaywright.Tests
{
    [TestFixture]
    public class E2ETests : BaseTest
    {
        [Test]
        public async Task User_Can_Complete_Order_End_To_End()
        {
            var checkoutCompletePage = new CheckoutCompletePage(Page);

            await LoginAsStandardUserAsync();

            await OrderAsStandartUserAsync();

            await CheckoutAsStandartUserAsync();

            Assert.That(await checkoutCompletePage.IsOrderCompleteAsunc(), Is.True);
        }
    }
}

