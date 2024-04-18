using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using StabilityTest.Base;
using StabilityTest.Utilities;

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
        ClickOnElement(_partnersOnlineTicketShop, "Online Ticket Shop Partner element is not present.");
    }

    public void ClickOnProfessionalTicketShop()
    {
        ClickOnElementAndSwitchWindow(_professionalTicketShop, "Professional Ticket Shop element is not present.");
    }

    public void ClickOnTicketShopB2B()
    {
        ClickOnElementAndSwitchWindow(_ticketShopB2B, "B2B button is not present in this page.");
    }

    public void ClickOnMicrochip()
    {
        ClickOnElement(_microchip, "Microchip element is not present in this page.");
    }

    public void ClickOnAdminOfflineTicketShop()
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
        string[] xpaths =
        {
            "//a[normalize-space()='Admin Taquillas Físicas']",
            "//a[contains(text(), 'Admin taquillas')]"
        };

        foreach (var xpath in xpaths)
        {
            try
            {
                var element = wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
                element.Click();
                Driver!.SwitchTo().Window(Driver.WindowHandles.Last());
                return;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        throw new ElementNotFoundException("Admin Offline TicketShop is not present in this page.");
    }

    public void ClickOnCmsTicketShopB2B()
    {
        ClickOnElementAndSwitchWindow(_cmsTicketShopB2B, "CMS Ticket Shop B2B is not present in this page.");
    }

    public void ClickOnCmsPublicTicketShop()
    {
        ClickOnElementAndSwitchWindow(_cmsPublicTicketShop, "CMS Public Ticket Shop is not present in this page.");
    }

    public void ClickOnExpertAccessAdmin()
    {
        ClickOnElementAndSwitchWindow(_expertAccessAdmin, "Expert Access Admin is not present in this page.");
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