using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;

namespace StabilityTest.Pages;

public class PartnerPage : BasePage
{
    private readonly By _loginBtn = By.XPath("//i[@class='fa fa-sign-in']");
    private readonly By _logo = By.XPath("//img[@class='avatar']");

    public PartnerPage(IWebDriver? driver) : base(driver)
    {
    }

    public void ClickOnLoginButton()
    {
        ClickOnElement(_loginBtn,"Login button element is not present.");
    }
    
    public void VerifyLogo()
    {
        var logo = FluentWait.Until(ExpectedConditions.ElementIsVisible(_logo));
        if (!logo.Displayed) return;
        DrawBorder(logo);
    }
}