using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;

namespace StabilityTest.Pages;

public class PublicTicketShopPage : BasePage
{
    private readonly By _navBar = By.XPath("//nav[@class='navbar sv-header__navbar']");
    private readonly By _navBarTravelParks = By.XPath("//a[@class='navbar-brand']//img");

    public PublicTicketShopPage(IWebDriver? driver) : base(driver)
    {
    }

    public void VerifyNavBar()
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
        string[] xpaths =
        {
            "//nav[@class='navbar sv-header__navbar']",
            "//a[@class='navbar-brand']//img"
        };

        foreach (var xpath in xpaths)
        {
            try
            {
                var element = wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
                DrawBorder(element);
                break;
            }
            catch (NoSuchElementException)
            {
            }
            catch (WebDriverTimeoutException)
            {
            }
        }
    }
}