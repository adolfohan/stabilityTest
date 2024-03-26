using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;

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
            Console.WriteLine("Taquilla B2B logo is not present in this page.");
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Taquilla B2B logo is not present in this page.");
        }
    }
}