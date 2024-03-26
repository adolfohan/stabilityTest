using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;
using StabilityTest.Utilities;

namespace StabilityTest.Pages;

public class TicketShopB2BPage : BasePage
{
    private readonly By _taquillaB2BLogo = By.XPath("//a[@class='navbar-brand sv-header__logo mr-auto' and @href='/']");

    public TicketShopB2BPage(IWebDriver? driver) : base(driver)
    {
    }

    public void VerifyLogo()
    {
        try
        {
            var logo = FluentWait.Until(ExpectedConditions.ElementIsVisible(_taquillaB2BLogo));
            if (!logo.Displayed) return;
            DrawBorder(logo);
        }
        catch (NoSuchElementException)
        {
            throw new ElementNotFoundException("Taquilla B2B logo is not present in this page.");
        }
        catch (WebDriverTimeoutException)
        {
            throw new ElementNotFoundException("Taquilla B2B logo is not present in this page.");
        }
    }
}