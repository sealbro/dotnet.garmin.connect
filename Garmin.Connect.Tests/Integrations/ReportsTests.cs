using System;
using System.Threading.Tasks;
using Xunit;

namespace Garmin.Connect.Tests.Integrations;

[Collection("Garmin Integrations")]
public class ReportTests
{
    private readonly IGarminConnectClient _garmin;

    public ReportTests()
    {
        _garmin = LazyClient.Garmin.Value;
    }

    [Fact]
    public async Task GetReportHrvStatus_NotEmpty()
    {
        var endDate = DateTime.Now;
        var startDate = DateTime.Now.AddDays(-3);

        var hrvSummary = await _garmin.GetReportHrvStatus(startDate, endDate);

        if (hrvSummary == null)
        {
            Assert.Null(hrvSummary);
        }
        else
        {
            Assert.NotEmpty(hrvSummary.HrvSummaries);
        }
    }
}