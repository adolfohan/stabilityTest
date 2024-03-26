using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;

namespace StabilityTest.Pages;

public class ProductPage : BasePage
{
    private readonly By _provider = By.XPath("//tr[@role='row']/following::a[contains(@href, 'Provider/Provider')]");

    public ProductPage(IWebDriver? driver) : base(driver)
    {
    }
    
    public void ClickOnTheFirstProvider()
    {
        FluentWait.Until(ExpectedConditions.ElementToBeClickable(_provider)).Click();
    }
}