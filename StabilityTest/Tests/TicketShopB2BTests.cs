using NUnit.Framework;
using StabilityTest.Base;

namespace StabilityTest.Tests;

public class TicketShopB2BTests : BaseTest
{
    [TestCaseSource(nameof(TestUrls))]
    public void TaquillaB2BTest(string url)
    {
        ExecuteSteps(
            ("Starting TicketShop B2B Test", () => { }),
            ("Given I am on the login page", () => LoginPage!.NavigateTo(url)),
            ("Login", () => LoginSteps(url)),
            ("And I click on the sales button", () => SalesPage!.ClickOnSalesButton()),
            ("And I click on the TicketShop B2B button", () => SalesPage!.ClickOnTicketShopB2B()),
            ("Then I should see the Online TicketShop title", () => TaquillaB2B!.VerifyLogo())
            );
    }
}