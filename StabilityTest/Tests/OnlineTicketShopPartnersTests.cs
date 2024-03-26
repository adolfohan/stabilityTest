using NUnit.Framework;
using StabilityTest.Base;

namespace StabilityTest.Tests;

public class OnlineTicketShopPartnersTests : BaseTest
{
    [TestCaseSource(nameof(TestUrls))]
    public void TaquillaOnlineColaboradoresTest(string url)
    {
        ExecuteSteps(
            ("Starting Online TicketShop Partners Test", () => { }),
            ("Given I am on the Terranatura login page", () => LoginPage!.NavigateTo(url)),
            ("Login", () => LoginSteps(url)),
            ("And I click on the sales button", () => SalesPage!.ClickOnSalesButton()),
            ("And I click on the Online TicketShop partners button", () => SalesPage!.ClickOnOnlineTicketShopPartner()),
            ("Then I should see the Online TicketShop title", () => OnlineTicketShopPartnerPage!.VerifyOnlineTicketShopTitle())
            );
    }
}