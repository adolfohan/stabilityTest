using NUnit.Framework;
using StabilityTest.Base;

namespace StabilityTest.Tests;

public class CmsTicketShopB2BTests : BaseTest
{
    [TestCaseSource(nameof(TestUrls))]
    public void CmsTaquillaB2BTest(string url)
    {
        ExecuteSteps(
            ("Starting CMS TicketShop B2B Test", () => { }),
            ("Given I am on the login page", () => LoginPage!.NavigateTo(url)),
            ("Login", () => LoginSteps(url)),
            ("And I click on the microchip button", () => SalesPage!.ClickOnMicrochip()),
            ("And I click on the CMS TicketShop B2B button", () => SalesPage!.ClickOnCmsTicketShopB2B()),
            ("Then I should see the Online TicketShop title", () => CmsTicketShopB2BPage!.VerifyTicketShopB2BTitle())
            );
    }
}