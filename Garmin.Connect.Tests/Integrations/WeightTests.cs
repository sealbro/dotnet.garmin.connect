using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Models;

namespace Garmin.Connect.Tests.Integrations;

[NotInParallel("Garmin Integrations")]
public class WeightTests
{
    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;
    private readonly DateTime _startDate = new(2022, 1, 1);
    private readonly DateTime _endDate = DateTime.Now.AddYears(1);

    [Test]
    public async Task GetWeightRange_NotEmpty()
    {
        var weightRange = await _garmin.GetWeightRange(_startDate, _endDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(weightRange.DailyWeightSummaries).IsNotEmpty();
    }

    [Test]
    public async Task Add_And_Remove_Weight_Success()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var startDate = DateTime.Now.AddDays(-1);
        var endDate = DateTime.Now.AddDays(1);
        var weight = new GarminWeight { MeasurementDateTime = DateTime.Now, UnitKey = WeightUnit.Kg, Value = 42 };
        var expectedWeightInGram = weight.Value * 1000;

        var isAdded = await _garmin.AddWeight(weight, ct);

        await Assert.That(isAdded).IsTrue();

        var weightRange = await _garmin.GetWeightRange(startDate, endDate, ct);

        await Assert.That(weightRange.DailyWeightSummaries).IsNotEmpty();

        var measurement = weightRange.DailyWeightSummaries.First(summary =>
                summary.SummaryDate == DateOnly.FromDateTime(weight.MeasurementDateTime))
            .AllWeightMetrics.First(weightMeasurement =>
                Math.Abs(weightMeasurement.Weight - expectedWeightInGram) < 0.1);

        await Assert.That(measurement.Weight).IsEqualTo(expectedWeightInGram);

        await _garmin.RemoveWeight(measurement, ct);

        weightRange = await _garmin.GetWeightRange(startDate, endDate, ct);
        var garminWeightDailyWeightSummary = weightRange.DailyWeightSummaries.FirstOrDefault(summary =>
            summary.SummaryDate == DateOnly.FromDateTime(weight.MeasurementDateTime));
        if (garminWeightDailyWeightSummary is null)
        {
            await Assert.That(weightRange.DailyWeightSummaries).IsEmpty();
        }
        else
        {
            await Assert.That(garminWeightDailyWeightSummary.AllWeightMetrics)
                .DoesNotContain(x => x.SamplePk == measurement.SamplePk && x.CalendarDate == measurement.CalendarDate &&
                                     Math.Abs(x.Weight - measurement.Weight) < 0.1);
        }
    }

    [Test]
    [MethodDataSource(nameof(WeightData))]
    public async Task Add_Weight_Failed(double weight)
    {
        var weightData = new GarminWeight
        {
            MeasurementDateTime = DateTime.Now,
            UnitKey = WeightUnit.Kg,
            Value = weight
        };

        var isAdded = await _garmin.AddWeight(weightData, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(isAdded).IsFalse();
    }

    public static IEnumerable<double> WeightData()
    {
        yield return 0.0;
        yield return 454.0;
    }
}
