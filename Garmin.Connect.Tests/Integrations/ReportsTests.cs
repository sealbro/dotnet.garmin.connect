using System;
using System.Threading.Tasks;

namespace Garmin.Connect.Tests.Integrations;

[NotInParallel("Garmin Integrations")]
public class ReportTests
{
    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;

    [Test]
    public async Task GetReportHrvStatus_NotEmpty()
    {
        var endDate = DateTime.Now;
        var startDate = DateTime.Now.AddDays(-3);

        var hrvSummary = await _garmin.GetReportHrvStatus(startDate, endDate, TestContext.Current!.Execution.CancellationToken);

        if (hrvSummary == null)
        {
            await Assert.That(hrvSummary).IsNull();
        }
        else
        {
            await Assert.That(hrvSummary.HrvSummaries).IsNotEmpty();
        }
    }
}
