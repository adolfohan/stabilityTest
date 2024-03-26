using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;

namespace StabilityTest.Pages;

public class SalesPage : BasePage
{
    private readonly By _salesBtnElement = By.XPath("//i[@class='fa fa-ticket']");

    private readonly By _partnersOnlineTicketShop =
        By.XPath("//a[@href='/Partners/Partner/PartnerListForCreateSale']");

    private readonly By _professionalTicketShop =
        By.XPath("//a[@href='/Purchases/Sale/ProfessionalShopSale']");

    private readonly By _ticketShopB2B = By.XPath("//a[@href='/Purchases/Sale/B2BShopSale']");
    private readonly By _microchip = By.XPath("//i[@class='fa fa-microchip']");
    private readonly By _adminOfflineTicketShop = By.XPath("//a[contains(text(), 'Admin taquillas')]");
    private readonly By _cmsTicketShopB2B = By.XPath("//a[normalize-space()='CMS Taquilla B2B']");
    private readonly By _cmsPublicTicketShop = By.XPath("//a[normalize-space()='CMS Taquilla pública']");
    private readonly By _expertAccessAdmin = By.XPath("//a[normalize-space()='Expert Access Admin']");
    private readonly By _productBtnElement = By.XPath("//i[@class='fa fa-institution']");

    private readonly By _ticketsAndOffers =
        By.XPath("//a[@href='/Provider/Provider?IsActive=True&InternalProviderType=TicketsAndOffers']");

    public SalesPage(IWebDriver? driver) : base(driver)
    {
    }

    public void ClickOnSalesButton()
    {
        FluentWait.Until(ExpectedConditions.ElementToBeClickable(_salesBtnElement)).Click();
    }

    public void ClickOnOnlineTicketShopPartner()
    {
        try
        {
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(_partnersOnlineTicketShop)).Click();
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Online Ticket Shop Partner element is not present.");
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Online Ticket Shop Partner element is not present.");
        }
    }

    public void ClickOnProfessionalTicketShop()
    {
        try
        {
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(_professionalTicketShop)).Click();
            Driver!.SwitchTo().Window(Driver.WindowHandles.Last());
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Professional Ticket Shop element is not present.");
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Professional Ticket Shop element is not present.");
        }
    }

    public void ClickOnTicketShopB2B()
    {
        try
        {
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(_ticketShopB2B)).Click();
            Driver!.SwitchTo().Window(Driver.WindowHandles.Last());
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("B2B button is not present in this page.");
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("B2B button is not present in this page.");
        }
    }

    public void ClickOnMicrochip()
    {
        try
        {
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(_microchip)).Click();
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Microchip element is not present in this page.");
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Microchip element is not present in this page.");
        }
    }

    public void ClickOnAdminOfflineTicketShop()
    {
        try
        {
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(_adminOfflineTicketShop)).Click();
            Driver!.SwitchTo().Window(Driver.WindowHandles.Last());
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Admin Offline TicketShop is not present in this page.");
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Admin Offline TicketShop is not present in this page.");
        }
    }

    public void ClickOnCmsTicketShopB2B()
    {
        try
        {
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(_cmsTicketShopB2B)).Click();
            Driver!.SwitchTo().Window(Driver.WindowHandles.Last());
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("CMS Ticket Shop B2B is not present in this page.");
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("CMS Ticket Shop B2B is not present in this page.");
        }
    }

    public void ClickOnCmsPublicTicketShop()
    {
        try
        {
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(_cmsPublicTicketShop)).Click();
            Driver!.SwitchTo().Window(Driver.WindowHandles.Last());
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("CMS Public Ticket Shop is not present in this page.");
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("CMS Public Ticket Shop is not present in this page.");
        }
    }

    public void ClickOnExpertAccessAdmin()
    {
        try
        {
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(_expertAccessAdmin)).Click();
            Driver!.SwitchTo().Window(Driver.WindowHandles.Last());
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Expert Access Admin is not present in this page.");
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Expert Access Admin is not present in this page.");
        }
    }

    public void ClickOnProductButton()
    {
        FluentWait.Until(ExpectedConditions.ElementToBeClickable(_productBtnElement)).Click();
    }

    public void ClickOnTicketsAndOffers()
    {
        FluentWait.Until(ExpectedConditions.ElementToBeClickable(_ticketsAndOffers)).Click();
    }
}