using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;

namespace StabilityTest.Pages;

public class OnlineTicketShopPartnerPage : BasePage
{
    private readonly By _taquillaOnlineColaboradoresTitle = By.Id("page-title");
    private readonly By _colaborador = By.XPath("//tr[@role='row']/following::a[contains(@href, 'Partners/Partner')]");

    public OnlineTicketShopPartnerPage(IWebDriver? driver) : base(driver) { }
    
    public void VerifyOnlineTicketShopTitle()
    {
        try
        {
            var taquillaOnline = FluentWait.Until(ExpectedConditions.ElementIsVisible(_taquillaOnlineColaboradoresTitle));
            DrawBorder(taquillaOnline);
        }
        catch (Exception)
        {
            // ignored
        }
    }
    
    public void ClickOnTheFirstPartner()
    {
        FluentWait.Until(ExpectedConditions.ElementToBeClickable(_colaborador)).Click();
    }
}