using NUnit.Framework;
using StabilityTest.Base;

namespace StabilityTest.Tests;

public class PublicTicketShopTests : BaseTest
{
    [TestCaseSource(nameof(TestUrls))]
    public void TaquillaPublicaTest(string url)
    {
        ExecuteSteps(
            ("Starting CMS Publica TicketShop Test", () => { }),
            ("Given I am on the login page", () => LoginPage!.NavigateTo(url)),
            ("Login", () => LoginSteps(url)),
            ("And I click on the microchip button", () => SalesPage!.ClickOnMicrochip()),
            ("And I click on the CMS Public TicketShop button", () => SalesPage!.ClickOnCmsPublicTicketShop()),
            ("And I click on the Partner Hubs icon", () => CmsPublicTicketShopPage!.ClickOnPartnerHubsIcon()),
            ("And I click on the Partner Hubs link", () => CmsPublicTicketShopPage!.ClickOnPartnerHubsLink()),
            ("And I click on the Public TicketShop link", () => CmsPublicTicketShopPage!.ClickOnPublicTicketShopLink()),
            ("Then I should see the Public TicketShop nav bar", () => PublicTicketShopPage!.VerifyNavBar())
        );
    }
}