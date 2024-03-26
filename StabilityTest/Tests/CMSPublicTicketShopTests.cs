using NUnit.Framework;
using StabilityTest.Base;

namespace StabilityTest.Tests;

public class CmsPublicTicketShopTests : BaseTest
{
    [TestCaseSource(nameof(TestUrls))]
    public void CmsTaquillaPublicaTest(string url)
    {
        ExecuteSteps(
            ("Starting CMS Public TicketShop Test", () => { }),
            ("Given I am on the login page", () => LoginPage!.NavigateTo(url)),
            ("Login", () => LoginSteps(url)),
            ("And I click on the microchip button", () => SalesPage!.ClickOnMicrochip()),
            ("And I click on the CMS Public TicketShop button", () => SalesPage!.ClickOnCmsPublicTicketShop()),
            ("Then I should see the Online TicketShop title", () => CmsPublicTicketShopPage!.VerifyPublicTicketShopTitle())
            );
    }
}