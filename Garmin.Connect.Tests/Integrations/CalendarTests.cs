using System;
using System.Threading.Tasks;
using Garmin.Connect.Models;

namespace Garmin.Connect.Tests.Integrations;

[NotInParallel("Garmin Integrations")]
public class CalendarTests
{
    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;

    [Test]
    public async Task GetCalendarYear_Exists()
    {
        var year = DateTime.Now.Year;
        var calendarYear = await _garmin.GetCalendarByYear(year, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(calendarYear.YearSummaries).IsNotEmpty();
    }

    [Test]
    public async Task GetCalendarMonth_Exists()
    {
        var date = DateTime.Now.AddMonths(-1);
        var year = date.Year;
        var previousMonth = (GarminMonth)(date.Month - 1);
        var calendarMonth =
            await _garmin.GetCalendarByMonth(year, previousMonth, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(calendarMonth.Year).IsEqualTo(year);
        await Assert.That(calendarMonth.Month).IsEqualTo(previousMonth);
        await Assert.That(calendarMonth.CalendarItems).IsNotEmpty();
    }

    [Test]
    public async Task GetCalendarWeek_Exists()
    {
        var date = DateOnly.FromDateTime(DateTime.Now.AddDays(-7));
        var calendarWeek = await _garmin.GetCalendarByWeek(date, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(date >= calendarWeek.StartDate).IsTrue();
        await Assert.That(date <= calendarWeek.EndDate).IsTrue();
    }
}
