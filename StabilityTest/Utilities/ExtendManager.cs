using System.Text.RegularExpressions;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;

namespace StabilityTest.Utilities;

public abstract partial class ExtentManager
{
    private static ExtentReports? _extent;

    private static readonly string BaseReportDirectory = Path.Combine(
        Environment.GetEnvironmentVariable("SourceDirectory") ??
        @"C:\Projects\Repositories\Git\StabilityTest\StabilityTest\Reports");

    public static ExtentReports GetExtent(string testName)
    {
        if (_extent != null) return _extent;

        Directory.CreateDirectory(BaseReportDirectory);

        testName = MyRegex().Replace(testName, string.Empty);
        var reportFileName = $"report_{testName}_{DateTime.Now:yyyy-MM-dd-HHmmss}.html";
        var reportPath = Path.Combine(BaseReportDirectory, reportFileName);

        var htmlReporter = new ExtentSparkReporter(reportPath);
        _extent = new ExtentReports();
        _extent.AttachReporter(htmlReporter);

        _extent.AddSystemInfo("Tester", "Adolfo");
        _extent.AddSystemInfo("Environment", "Pre-Producción");

        htmlReporter.Config.Theme = Theme.Dark;
        htmlReporter.Config.DocumentTitle = testName + " Report";
        htmlReporter.Config.ReportName = testName + " Test Report";

        CleanUpOldReports();

        return _extent;
    }

    private static void CleanUpOldReports()
    {
        var reportFiles = Directory.GetFiles(BaseReportDirectory, "report*.html");

        const int maxReportsToKeep = 10;

        if (reportFiles.Length <= maxReportsToKeep) return;
        Array.Sort(reportFiles);
        for (var i = 0; i < reportFiles.Length - maxReportsToKeep; i++)
        {
            File.Delete(reportFiles[i]);
        }
    }

    [GeneratedRegex(@"\((.*?)\)")]
    private static partial Regex MyRegex();
}