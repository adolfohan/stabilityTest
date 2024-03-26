using NUnit.Framework;
using StabilityTest.Base;

namespace StabilityTest.Tests;

public class ExpertAccessAdminTests : BaseTest
{
    [TestCaseSource(nameof(TestUrls))]
    public void ExpertAccessAdminTest(string url)
    {
        ExecuteSteps(
            ("Starting Expert Access Admin Test", () => { }),
            ("Given I am on the login page", () => LoginPage!.NavigateTo(url)),
            ("Login", () => LoginSteps(url)),
            ("And I click on the microchip button", () => SalesPage!.ClickOnMicrochip()),
            ("And I click on the Expert Access Admin button", () => SalesPage!.ClickOnExpertAccessAdmin()),
            ("Then I should see the title", () => ExpertAccessAdminPage!.VerifyAdminTitle())
            );
    }
}