using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Utilities;

namespace StabilityTest.Base;

public class BasePage
{
    protected readonly IWebDriver? Driver;
    protected readonly DefaultWait<IWebDriver?> FluentWait;
    protected readonly Random Random = new();

    protected BasePage(IWebDriver? driver)
    {
        Driver = driver;

        FluentWait = new DefaultWait<IWebDriver?>(driver)
        {
            Timeout = TimeSpan.FromSeconds(20),
            PollingInterval = TimeSpan.FromSeconds(2)
        };
        FluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        FluentWait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
    }

    protected static void ClearAndSetInputValue(IWebElement inputField, string value)
    {
        inputField.Clear();
        inputField.SendKeys(value);
    }

    protected void ScrollIntoView(IWebElement? element)
    {
        var js = (IJavaScriptExecutor)Driver!;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", element); //{behavior: 'auto', block: 'center'}
    }

    protected void ScrollToBottom()
    {
        ((IJavaScriptExecutor)Driver!).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
    }

    protected void CheckValidity(IWebElement element)
    {
        var js = (IJavaScriptExecutor)Driver!;
        var isInvalid = (bool)(js.ExecuteScript("return arguments[0].checkValidity();", element) ??
                               throw new InvalidOperationException());

        Assert.That(isInvalid, Is.False, "The input text is invalid");
    }

    protected void DrawBorder(IWebElement element)
    {
        var js = (IJavaScriptExecutor)Driver!;
        js.ExecuteScript("arguments[0].style.border='2px solid red'", element);
    }

    protected void ClickByJs(IWebElement element)
    {
        var js = (IJavaScriptExecutor)Driver!;
        js.ExecuteScript("arguments[0].click();", element);
    }

    protected void CheckPageStateComplete()
    {
        FluentWait.Until(driver =>
            ((IJavaScriptExecutor)driver!).ExecuteScript("return document.readyState").Equals("complete"));
    }
    
    protected void ClickOnElementAndSwitchWindow(By elementLocator, string errorMessage)
    {
        try
        {
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(elementLocator)).Click();
            Driver!.SwitchTo().Window(Driver.WindowHandles.Last());
        }
        catch (Exception)
        {
            throw new ElementNotFoundException(errorMessage);
        }
    }
    
    protected void ClickOnElement(By elementLocator, string errorMessage)
    {
        try
        {
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(elementLocator)).Click();
        }
        catch (Exception)
        {
            throw new ElementNotFoundException(errorMessage);
        }
    }
}