using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Models;
using Xunit;

namespace Garmin.Connect.Tests.Integrations;

[Collection("Garmin Integrations")]
public class WeightTests
{
    private readonly IGarminConnectClient _garmin;
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;

    public WeightTests()
    {
        _garmin = LazyClient.Garmin.Value;
        _startDate = new DateTime(2022,1,1);
        _endDate = DateTime.Now.AddYears(1);
    }

    [Fact]
    public async Task GetWeightRange_NotEmpty()
    {
        var weightRange = await _garmin.GetWeightRange(_startDate, _endDate);

        Assert.NotEmpty(weightRange.DailyWeightSummaries);
    }

    [Fact]
    public async Task Add_And_Remove_Weight_Success()
    {
        var startDate = DateTime.Now.AddDays(-1);
        var endDate = DateTime.Now.AddDays(1);
        var weight = new GarminWeight
        {
            MeasurementDateTime = DateTime.Now,
            UnitKey = WeightUnit.Kg,
            Value = 42
        };
        var expectedWeightInGram = weight.Value * 1000;

        var isAdded = await _garmin.AddWeight(weight);

        Assert.True(isAdded);

        var weightRange = await _garmin.GetWeightRange(startDate, endDate);

        Assert.NotEmpty(weightRange.DailyWeightSummaries);

        var measurement = weightRange.DailyWeightSummaries.First(summary => summary.SummaryDate == DateOnly.FromDateTime(weight.MeasurementDateTime))
            .AllWeightMetrics.First(weightMeasurement => weightMeasurement.Weight == expectedWeightInGram);

        Assert.Equal(expectedWeightInGram, measurement.Weight);

        await _garmin.RemoveWeight(measurement);

        weightRange = await _garmin.GetWeightRange(startDate, endDate);
        var garminWeightDailyWeightSummary = weightRange.DailyWeightSummaries.FirstOrDefault(summary => summary.SummaryDate == DateOnly.FromDateTime(weight.MeasurementDateTime));
        if (garminWeightDailyWeightSummary is null)
        {
            Assert.Empty(weightRange.DailyWeightSummaries);
        }
        else
        {
            Assert.DoesNotContain(garminWeightDailyWeightSummary.AllWeightMetrics,
                x => x.SamplePk == measurement.SamplePk && x.CalendarDate == measurement.CalendarDate && x.Weight == measurement.Weight);
        }
    }

    [Theory]
    [MemberData(nameof(WeightData))]
    public async Task Add_Weight_Failed(double weight)
    {
        var weightData = new GarminWeight
        {
            MeasurementDateTime = DateTime.Now,
            UnitKey = WeightUnit.Kg,
            Value = weight
        };

        var isAdded = await _garmin.AddWeight(weightData);

        Assert.False(isAdded);
    }
    
    public static IEnumerable<object[]> WeightData() {
        yield return [0.0];
        yield return [454.0];
    }
}