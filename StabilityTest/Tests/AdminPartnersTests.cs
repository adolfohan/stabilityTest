using NUnit.Framework;
using StabilityTest.Base;

namespace StabilityTest.Tests;

public class AdminPartnersTests : BaseTest
{
    [TestCaseSource(nameof(TestUrls))]
    public void AdminPartnerTest(string url) =>
        ExecuteSteps(
            ("Starting Admin Partner Test", () => { }),
            ("Given I am on the login page", () => LoginPage!.NavigateTo(url)),
            ("Login", () => LoginSteps(url)),
            ("And I click on the sales button", () => SalesPage!.ClickOnSalesButton()),
            ("And I click on the Online TicketShop Partners button",
                () => SalesPage!.ClickOnOnlineTicketShopPartner()),
            ("And I should see the Online TicketShop title",
                () => OnlineTicketShopPartnerPage!.VerifyOnlineTicketShopTitle()),
            ("And I click on the first partner", () => OnlineTicketShopPartnerPage!.ClickOnTheFirstPartner()),
            ("And I click on the login button", () => PartnerPage!.ClickOnLoginButton()),
            ("Then I should see the Partner title", () => PartnerPage!.VerifyLogo())
        );
}