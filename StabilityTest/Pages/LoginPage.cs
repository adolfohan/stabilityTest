using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;

namespace StabilityTest.Pages;

public class LoginPage : BasePage
{
    private const string Username = "ahan";
    //private const string Password = "&9kYP3nKjSxEvYFp";
    private readonly By _usernameElement = By.Id("AdminUserName");
    private readonly By _passwordElement = By.Id("Password");
    private readonly By _loginButtonElement = By.XPath("//input[@type='submit']");

    public LoginPage(IWebDriver? driver) : base(driver) { }
    
    public void NavigateTo(string url)
    {
        Driver?.Navigate().GoToUrl(url);
        Driver?.Manage().Window.Maximize();
    }
    
    public void CompleteLoginData(string password)
    {
        FluentWait.Until(ExpectedConditions.ElementIsVisible(_usernameElement)).SendKeys(Username);
        FluentWait.Until(ExpectedConditions.ElementIsVisible(_passwordElement)).SendKeys(password);
    }
    
    public void ClickOnLoginButton()
    {
        FluentWait.Until(ExpectedConditions.ElementToBeClickable(_loginButtonElement)).Click();
    }
}