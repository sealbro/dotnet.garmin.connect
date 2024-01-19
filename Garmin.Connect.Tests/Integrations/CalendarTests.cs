using System;
using System.Threading.Tasks;
using Garmin.Connect.Models;
using Xunit;

namespace Garmin.Connect.Tests.Integrations;

[Collection("Garmin Integrations")]
public class CalendarTests
{
    private readonly IGarminConnectClient _garmin;

    public CalendarTests()
    {
        _garmin = LazyClient.Garmin.Value;
    }

    [Fact]
    public async Task GetCalendarYear_Exists()
    {
        var year = DateTime.Now.Year;
        var calendarYear = await _garmin.GetCalendarYear(year);

        Assert.NotEmpty(calendarYear.YearSummaries);
    }

    [Fact]
    public async Task GetCalendarMonth_Exists()
    {
        var date = DateTime.Now.AddMonths(-1);
        var year = date.Year;
        var previousMonth = (GarminMonth)(date.Month - 1);
        var calendarMonth = await _garmin.GetCalendarMonth(year, previousMonth);

        Assert.Equal(year, calendarMonth.Year);
        Assert.Equal(previousMonth, calendarMonth.Month);
        Assert.NotEmpty(calendarMonth.CalendarItems);
    }

    [Fact]
    public async Task GetCalendarWeek_Exists()
    {
        var date = DateOnly.FromDateTime(DateTime.Now.AddDays(-7));
        var calendarWeek = await _garmin.GetCalendarWeek(date);

        Assert.True(date >= calendarWeek.StartDate);
        Assert.True(date <= calendarWeek.EndDate);
    }
}