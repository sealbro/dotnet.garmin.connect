using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Models;

namespace Garmin.Connect.Tests.Integrations;

[NotInParallel("Garmin Integrations")]
public class BloodPressureTests
{
    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;
    private readonly DateTime _startDate = new(2024, 1, 10);
    private readonly DateTime _endDate = DateTime.Now.AddYears(1);

    [Test]
    public async Task GetBloodPressureRange_NotEmpty()
    {
        var bloodPressureRange =
            await _garmin.GetBloodPressureRange(_startDate, _endDate, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(bloodPressureRange).IsNotEmpty();
    }

    [Test]
    public async Task GetBloodPressureDaily_NotEmpty()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var bloodPressureRange = await _garmin.GetBloodPressureRange(_startDate, _endDate, ct);

        await Assert.That(bloodPressureRange).IsNotEmpty();

        var garminBloodPressureMeasurement = bloodPressureRange.First();

        var bloodPressureDaily =
            await _garmin.GetBloodPressureDaily(garminBloodPressureMeasurement.MeasurementTimestampLocal, ct);

        await Assert.That(bloodPressureDaily.BloodPressureMeasurements).IsNotEmpty();
    }

    [Test]
    public async Task Add_And_Remove_BloodPressure_Success()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var startDate = DateTime.Now.AddDays(-1);
        var endDate = DateTime.Now.AddDays(1);
        var bloodPressure = new GarminBloodPressure
        {
            Diastolic = 80,
            Systolic = 120,
            Pulse = 60,
            MeasurementDateTime = DateTime.Now,
            Notes = "123"
        };

        var addBloodPressure = await _garmin.AddBloodPressure(bloodPressure, ct);

        await Assert.That(addBloodPressure).IsTrue();

        var bloodPressureRange = await _garmin.GetBloodPressureRange(startDate, endDate, ct);

        await Assert.That(bloodPressureRange).IsNotEmpty();

        var garminBloodPressureMeasurement = bloodPressureRange.First();

        await Assert.That(garminBloodPressureMeasurement.Diastolic).IsEqualTo(bloodPressure.Diastolic);
        await Assert.That(garminBloodPressureMeasurement.Systolic).IsEqualTo(bloodPressure.Systolic);
        await Assert.That(garminBloodPressureMeasurement.Pulse).IsEqualTo(bloodPressure.Pulse);
        await Assert.That(garminBloodPressureMeasurement.Notes).IsEqualTo(bloodPressure.Notes);

        await _garmin.RemoveBloodPressure(garminBloodPressureMeasurement, ct);

        bloodPressureRange = await _garmin.GetBloodPressureRange(startDate, endDate, ct);

        await Assert.That(bloodPressureRange)
            .DoesNotContain(x => x.Version == garminBloodPressureMeasurement.Version
                                 && x.MeasurementTimestampLocal == garminBloodPressureMeasurement.MeasurementTimestampLocal);
    }

    [Test]
    [MethodDataSource(nameof(BloodPressureData))]
    public async Task Add_And_Remove_BloodPressure_Failed(long diastolic, long systolic, long pulse)
    {
        var bloodPressure = new GarminBloodPressure
        {
            Diastolic = diastolic,
            Systolic = systolic,
            Pulse = pulse,
            MeasurementDateTime = DateTime.Now,
            Notes = "123"
        };

        var addBloodPressure = await _garmin.AddBloodPressure(bloodPressure, TestContext.Current!.Execution.CancellationToken);

        await Assert.That(addBloodPressure).IsFalse();
    }

    public static IEnumerable<(long, long, long)> BloodPressureData()
    {
        yield return (29, 100, 100);
        yield return (201, 100, 100);
        yield return (100, 39, 100);
        yield return (100, 301, 100);
        yield return (100, 100, 0);
        yield return (100, 100, 301);
    }
}
