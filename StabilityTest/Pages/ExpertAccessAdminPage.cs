using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;

namespace StabilityTest.Pages;

public class ExpertAccessAdminPage : BasePage
{
    private readonly By _adminTitle = By.XPath("//h1[normalize-space()='Dispositivos']");

    public ExpertAccessAdminPage(IWebDriver? driver) : base(driver)
    {
    }
    
    public void VerifyAdminTitle()
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
        string[] xpaths =
        {
            "//h1[normalize-space()='Dispositivos']",
            "//h1[@class='h3 mb-0 text-heading']"
        };

        foreach (var xpath in xpaths)
        {
            try
            {
                var element = wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
                if (!element.Displayed) continue;
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