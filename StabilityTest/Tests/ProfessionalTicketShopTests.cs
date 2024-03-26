using NUnit.Framework;
using StabilityTest.Base;

namespace StabilityTest.Tests;

public class ProfessionalTicketShopTests : BaseTest
{
    [TestCaseSource(nameof(TestUrls))]
    public void TaquillaProfesionalTest(string url)
    {
        ExecuteSteps(
            ("Starting Taquilla Profesional Test", () => { }),
            ("Given I am on the login page", () => LoginPage!.NavigateTo(url)),
            ("Login", () => LoginSteps(url)),
            ("And I click on the sales button", () => SalesPage!.ClickOnSalesButton()),
            ("And I click on the Professional TicketShop button", () => SalesPage!.ClickOnProfessionalTicketShop()),
            ("Then I should see the Online TicketShop title", () => ProfessionalTicketShopPage!.VerifyOnlineTicketShopTitle())
            );
    }
}