using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;

namespace StabilityTest.Pages;

public class CmsTicketShopB2BPage : BasePage
{
    private readonly By _taquillaB2BTitle = By.XPath("//a[text()='Taquilla B2B']");

    public CmsTicketShopB2BPage(IWebDriver? driver) : base(driver)
    {
    }
    
    public void VerifyTicketShopB2BTitle()
    {
        var taquillaTitle = FluentWait.Until(ExpectedConditions.ElementIsVisible(_taquillaB2BTitle));
        var text = taquillaTitle.Text;
        DrawBorder(taquillaTitle);
        
        Assert.That(text, Is.EqualTo("Taquilla B2B"));
    }
}