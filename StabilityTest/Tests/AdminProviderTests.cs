using NUnit.Framework;
using StabilityTest.Base;

namespace StabilityTest.Tests;

public class AdminProviderTests : BaseTest
{
    [TestCaseSource(nameof(TestUrls))]
    public void AdminProviderTest(string url) =>
        ExecuteSteps(
            ("Starting Admin Provider Test", () => { }),
            ("Given I am on the login page", () => LoginPage!.NavigateTo(url)),
            ("Login", () => LoginSteps(url)),
            ("And I click on the sales button", () => SalesPage!.ClickOnSalesButton()),
            ("And I click on the Product button",
                () => SalesPage!.ClickOnProductButton()),
            ("And I click on the Entradas y Ofertas button",
                () => SalesPage!.ClickOnTicketsAndOffers()),
            ("And I should see the Online TicketShop title",
                () => ProductPage!.ClickOnTheFirstProvider()),
            ("And I click on the login button", () => ProviderPage!.ClickOnLoginButton()),
            ("Then I should see the Provider title", () => ProviderPage!.VerifyLogo())
        );
}