using NUnit.Framework;
using StabilityTest.Base;

namespace StabilityTest.Tests;

public class AdminOfflineTicketShopTests : BaseTest
{
    [TestCaseSource(nameof(TestUrls))]
    public void AdminOfflineTicketShopTest(string url)
    {
        ExecuteSteps(
            ("Starting Admin Offline TicketShop Test", () => { }),
            ("Given I am on the login page", () => LoginPage!.NavigateTo(url)),
            ("Login", () => LoginSteps(url)),
            ("And I click on the microchip button", () => SalesPage!.ClickOnMicrochip()),
            ("And I click on the Admin Offline TicketShop button", () => SalesPage!.ClickOnAdminOfflineTicketShop()),
            ("Then I should see the Online TicketShop title", () => AdminOfflineTicketShopPage!.VerifyAdminTitle())
            );
    }
}