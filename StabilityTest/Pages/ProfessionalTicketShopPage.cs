using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;

namespace StabilityTest.Pages;

public class ProfessionalTicketShopPage : BasePage
{
    private readonly By _taquillaProfesionalTitle = By.XPath("//div[@class='card-header']");

    public ProfessionalTicketShopPage(IWebDriver? driver) : base(driver)
    {
    }

    public void VerifyOnlineTicketShopTitle()
    {
        var taquillaProfesional = FluentWait.Until(ExpectedConditions.ElementIsVisible(_taquillaProfesionalTitle));
        DrawBorder(taquillaProfesional);

        var expectedTexts = new[] { "Crear nueva sesión", "Create new session" }.Select(s => s.ToLowerInvariant())
            .ToList();
        Assert.That(expectedTexts, Does.Contain(taquillaProfesional.Text.ToLowerInvariant()));
    }
}