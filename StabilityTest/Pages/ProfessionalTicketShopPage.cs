using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;

namespace StabilityTest.Pages;

public class ProfessionalTicketShopPage : BasePage
{
    private readonly By _taquillaProfesionalTitle = By.XPath("//div[@class='card-header']");   
    public ProfessionalTicketShopPage(IWebDriver? driver) : base(driver) { }

    public void VerifyOnlineTicketShopTitle()
    {
        var taquillaProfesional = FluentWait.Until(ExpectedConditions.ElementIsVisible(_taquillaProfesionalTitle));
        var text = taquillaProfesional.Text;
        DrawBorder(taquillaProfesional);
        
        Assert.That(new List<string>
        {
            "Crear nueva sesión",
            "Create new session",
        }, Does.Contain(text), $"The message was not found in the list of possible messages.");
        
    }
}