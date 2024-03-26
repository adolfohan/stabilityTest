using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;

namespace StabilityTest.Pages;

public class CmsPublicTicketShopPage : BasePage
{
    private readonly By _taquillaB2BTitle = By.XPath("//a[text()='Taquilla pública']");
    private readonly By _partnerHubsIcon = By.XPath("//i[@class='fas fa-users b-bar-icon']");
    private readonly By _partnerHubsLink = By.XPath("//a[@href='/partnerhubsettings']");

    public CmsPublicTicketShopPage(IWebDriver? driver) : base(driver)
    {
    }

    public void VerifyPublicTicketShopTitle()
    {
        var taquillaTitle = FluentWait.Until(ExpectedConditions.ElementIsVisible(_taquillaB2BTitle));
        var text = taquillaTitle.Text;
        DrawBorder(taquillaTitle);

        Assert.That(text, Is.EqualTo("Taquilla pública"));
    }

    public void ClickOnPartnerHubsIcon()
    {
        FluentWait.Until(ExpectedConditions.ElementToBeClickable(_partnerHubsIcon)).Click();
    }

    public void ClickOnPartnerHubsLink()
    {
        FluentWait.Until(ExpectedConditions.ElementToBeClickable(_partnerHubsLink)).Click();
    }

    public void ClickOnPublicTicketShopLink()
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
        string[] xpaths =
        {
            "//th[text()='TicketShop Dns']/following::a[contains(@href, '.com') and not(contains(@href, 'experticket'))]",
            "//th[text()='TicketShop Dns']/following::a[contains(@href, '.com')]",
            "//th[text()='TicketShop Dns']/following::a[contains(@href, 'islamagica.es')]"
        };

        foreach (var xpath in xpaths)
        {
            try
            {
                var element = wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
                element.Click();
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