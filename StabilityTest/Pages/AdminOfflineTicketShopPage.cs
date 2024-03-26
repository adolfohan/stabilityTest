using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;

namespace StabilityTest.Pages;

public class AdminOfflineTicketShopPage : BasePage
{
    private readonly By _adminTitle = By.XPath("//h1[@class='h3 mb-0 text-heading']");

    public AdminOfflineTicketShopPage(IWebDriver? driver) : base(driver)
    {
    }
    
    public void VerifyAdminTitle()
    {
        var adminTitle = FluentWait.Until(ExpectedConditions.ElementIsVisible(_adminTitle));
        var text = adminTitle.Text;
        DrawBorder(adminTitle);
        
        Assert.That(text, Is.EqualTo("Informe de sesiones de usuario"));
    }
}