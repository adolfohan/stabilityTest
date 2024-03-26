﻿using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;
using StabilityTest.Utilities;

namespace StabilityTest.Pages;

public class ProviderPage : BasePage
{
    private readonly By _loginBtn = By.XPath("//i[@class='fa fa-sign-in']");
    private readonly By _logo = By.XPath("//img[@class='avatar']");

    public ProviderPage(IWebDriver? driver) : base(driver)
    {
    }

    public void ClickOnLoginButton()
    {
        try
        {
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(_loginBtn)).Click();
            Driver!.SwitchTo().Window(Driver.WindowHandles.Last());
        }
        catch (NoSuchElementException)
        {
            throw new ElementNotFoundException("Login button is not present in this page.");
        }
        catch (WebDriverTimeoutException)
        {
            throw new ElementNotFoundException("Login button is not present in this page.");
        }
    }

    public void VerifyLogo()
    {
        var logo = FluentWait.Until(ExpectedConditions.ElementIsVisible(_logo));
        if (!logo.Displayed) return;
        DrawBorder(logo);
    }
}