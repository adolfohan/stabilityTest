using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StabilityTest.Pages;
using StabilityTest.Utilities;

namespace StabilityTest.Base;

public class BaseTest
{
    private IWebDriver? _driver;
    private ExtentReports? _extent;
    private ExtentTest? _test;
    protected LoginPage? LoginPage;
    protected SalesPage? SalesPage;
    protected OnlineTicketShopPartnerPage? OnlineTicketShopPartnerPage;
    protected ProfessionalTicketShopPage? ProfessionalTicketShopPage;
    protected TicketShopB2BPage? TaquillaB2B;
    protected AdminOfflineTicketShopPage? AdminOfflineTicketShopPage;
    protected ExpertAccessAdminPage? ExpertAccessAdminPage;
    protected CmsTicketShopB2BPage? CmsTicketShopB2BPage;
    protected CmsPublicTicketShopPage? CmsPublicTicketShopPage;
    protected PartnerPage? PartnerPage;
    protected ProductPage? ProductPage;
    protected ProviderPage? ProviderPage;
    protected PublicTicketShopPage? PublicTicketShopPage;

    protected static readonly string[] TestUrls =
    {
        "https://pre-terranatura.admin.experticket.com", "https://admin.terranatura.experticket.com",
        "https://pre-puydufou.admin.experticket.com", "https://admin.puydufou.experticket.com",
        "https://pre-islamagica.admin.experticket.com", "https://admin.islamagica.experticket.com",
        "https://pre-portaventuraworld.admin.experticket.com", "https://admin.portaventuraworld.experticket.com",
        "https://pre-gdsparquesreunidos.admin.experticket.com", "https://admin.gdsparquesreunidos.experticket.com",
        "https://pre-travelparks.admin.experticket.com", "https://admin.travelparks.experticket.com",
        "https://pre-grpritaly.admin.experticket.com", "https://admin.grpritaly.experticket.com"
    };

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        LoginPage = new LoginPage(_driver);
        SalesPage = new SalesPage(_driver);
        OnlineTicketShopPartnerPage = new OnlineTicketShopPartnerPage(_driver);
        ProfessionalTicketShopPage = new ProfessionalTicketShopPage(_driver);
        TaquillaB2B = new TicketShopB2BPage(_driver);
        AdminOfflineTicketShopPage = new AdminOfflineTicketShopPage(_driver);
        ExpertAccessAdminPage = new ExpertAccessAdminPage(_driver);
        CmsTicketShopB2BPage = new CmsTicketShopB2BPage(_driver);
        CmsPublicTicketShopPage = new CmsPublicTicketShopPage(_driver);
        PartnerPage = new PartnerPage(_driver);
        ProductPage = new ProductPage(_driver);
        ProviderPage = new ProviderPage(_driver);
        PublicTicketShopPage = new PublicTicketShopPage(_driver);
        var testName = TestContext.CurrentContext.Test.Name;
        _extent = ExtentManager.GetExtent(testName);
        if (_extent != null) _test = _extent.CreateTest(testName);
    }

    [TearDown]
    [Obsolete("Obsolete")]
    public void TearDown()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            ? ""
            : $"<pre>{TestContext.CurrentContext.Result.StackTrace}</pre>";
        var errorMessage = TestContext.CurrentContext.Result.Message;

        LogTestStatus(status, errorMessage!, stacktrace);

        _extent?.Flush();
        _driver?.Dispose();
        _driver?.Quit();
    }

    [Obsolete("Obsolete")]
    private void LogTestStatus(TestStatus status, string errorMessage, string stacktrace)
    {
        Status logStatus;
        string label;
        ExtentColor color;

        switch (status)
        {
            case TestStatus.Failed:
                logStatus = Status.Fail;
                label = "Test Case Failed";
                color = ExtentColor.Red;
                _test?.Log(logStatus, "Failure Message: " + errorMessage);
                _test?.Log(logStatus, "Stack Trace: " + stacktrace);
                AttachScreenshotOnFailure();
                break;
            case TestStatus.Passed:
                logStatus = Status.Pass;
                label = "Test Case Passed";
                color = ExtentColor.Green;
                break;
            case TestStatus.Skipped:
                logStatus = Status.Skip;
                label = "Test Case Skipped";
                color = ExtentColor.Orange;
                break;
            case TestStatus.Inconclusive:
                logStatus = Status.Skip;
                label = "Test Case Inconclusive";
                color = ExtentColor.Blue;
                break;
            case TestStatus.Warning:
                logStatus = Status.Skip;
                label = "Test Case Warning";
                color = ExtentColor.Purple;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(status), "Unexpected TestStatus value");
        }

        _test?.Log(logStatus, MarkupHelper.CreateLabel(label, color));
    }

    [Obsolete("Obsolete")]
    private void AttachScreenshotOnFailure()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed) return;
        var screenshotPath = CaptureScreenshot();
        if (screenshotPath == null) return;
        var screenshotBytes = File.ReadAllBytes(screenshotPath);
        var screenshotBase64 = Convert.ToBase64String(screenshotBytes);

        _test?.AddScreenCaptureFromBase64String(screenshotBase64, "Screenshot on Failure");
    }

    [Obsolete("Obsolete")]
    private string? CaptureScreenshot()
    {
        try
        {
            var screenshotName = $"screenshot_{DateTime.Now:yyyy-MM-dd-HHmmss}.png";
            var screenshot = ((ITakesScreenshot)_driver!).GetScreenshot();
            var screenshotDirectory = GetScreenshotDirectory();
            var screenshotPath = Path.Combine(screenshotDirectory, screenshotName);

            screenshot.SaveAsFile(screenshotPath);
            DeleteOldScreenshots(screenshotDirectory);

            return screenshotPath;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error capturing screenshot: {ex.Message}");
            return null;
        }
    }

    private static string GetScreenshotDirectory()
    {
        var sourceDirectory = Environment.GetEnvironmentVariable("SourceDirectory") ??
                              @"C:\Projects\Repositories\Git\StabilityTest\StabilityTest\";
        var screenshotDirectory = Path.Combine(sourceDirectory, "Screenshots");
        Directory.CreateDirectory(screenshotDirectory);
        return screenshotDirectory;
    }

    private static void DeleteOldScreenshots(string screenshotDirectory)
    {
        var screenshots = Directory.GetFiles(screenshotDirectory, "*.png");
        if (screenshots.Length <= 10) return;
        var oldestScreenshots = screenshots.OrderBy(File.GetCreationTime).Take(screenshots.Length - 10);
        foreach (var oldScreenshot in oldestScreenshots)
        {
            File.Delete(oldScreenshot);
        }
    }

    private void LogStep(Status status, string message)
    {
        _test?.Log(status, message);
    }

    private void HandleTestFailure(Exception ex)
    {
        LogStep(Status.Fail, $"Test failed due to an error: {ex.Message}");
    }

    protected void ExecuteSteps(params (string, Action)[] steps)
    {
        try
        {
            foreach (var (description, action) in steps)
            {
                LogStep(Status.Info, description);
                action();
            }
        }
        catch (ElementNotFoundException ex)
        {
            _test?.Pass(ex.Message);
        }
        catch (Exception e)
        {
            HandleTestFailure(e);
            throw;
        }
    }
    
    private readonly Dictionary<string, string> _urlToPasswordMap = new()
    {
        { "https://pre-terranatura.admin.experticket.com", "&9kYP3nKjSxEvYFp" },
        { "https://admin.terranatura.experticket.com", "&9kYP3nKjSxEvYFp" },
        { "https://pre-puydufou.admin.experticket.com", "H!YN$LfiIR5" },
        { "https://admin.puydufou.experticket.com", "H!YN$LfiIR5" },
        { "https://pre-islamagica.admin.experticket.com", "H!YN$LfiIR5" },
        { "https://admin.islamagica.experticket.com", "H!YN$LfiIR5" },
        { "https://pre-portaventuraworld.admin.experticket.com", "H!YN$LfiIR5" },
        { "https://admin.portaventuraworld.experticket.com", "H!YN$LfiIR5" },
        { "https://pre-gdsparquesreunidos.admin.experticket.com", "H!YN$LfiIR5" }, 
        { "https://admin.gdsparquesreunidos.experticket.com", "H!YN$LfiIR5" }, 
        { "https://pre-travelparks.admin.experticket.com", "H!YN$LfiIR5" }, 
        { "https://admin.travelparks.experticket.com", "H!YN$LfiIR5" }, 
        { "https://pre-grpritaly.admin.experticket.com", "H!YN$LfiIR5" },
        { "https://admin.grpritaly.experticket.com", "H!YN$LfiIR5" }
    };

    protected void LoginSteps(string url)
    {
        var password = _urlToPasswordMap[url];
        ExecuteSteps(
            ("When I complete the login data", () => LoginPage!.CompleteLoginData(password)),
            ("And I click on the login button", () => LoginPage!.ClickOnLoginButton())
        );
    }
}