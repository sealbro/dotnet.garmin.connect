using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garmin.Connect.Models;
using Xunit;

namespace Garmin.Connect.Tests.Integrations;

[Collection("Garmin Integrations")]
public class BloodPressureTests
{
    private readonly IGarminConnectClient _garmin;
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;

    public BloodPressureTests()
    {
        _garmin = LazyClient.Garmin.Value;
        _startDate = new DateTime(2024,1,10);
        _endDate = DateTime.Now.AddYears(1);
    }

    [Fact]
    public async Task GetBloodPressureRange_NotEmpty()
    {
        var bloodPressureRange = await _garmin.GetBloodPressureRange(_startDate, _endDate);

        Assert.NotEmpty(bloodPressureRange);
    }

    [Fact]
    public async Task GetBloodPressureDaily_NotEmpty()
    {
        var bloodPressureRange = await _garmin.GetBloodPressureRange(_startDate, _endDate);

        Assert.NotEmpty(bloodPressureRange);

        var garminBloodPressureMeasurement = bloodPressureRange.First();
        
        var bloodPressureDaily = await _garmin.GetBloodPressureDaily(garminBloodPressureMeasurement.MeasurementTimestampLocal);

        Assert.NotEmpty(bloodPressureDaily.BloodPressureMeasurements);
    }

    [Fact]
    public async Task Add_And_Remove_BloodPressure_Success()
    {
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

        var addBloodPressure = await _garmin.AddBloodPressure(bloodPressure);

        Assert.True(addBloodPressure);

        var bloodPressureRange = await _garmin.GetBloodPressureRange(startDate, endDate);

        Assert.NotEmpty(bloodPressureRange);

        var garminBloodPressureMeasurement = bloodPressureRange.First();

        Assert.Equal(bloodPressure.Diastolic, garminBloodPressureMeasurement.Diastolic);
        Assert.Equal(bloodPressure.Systolic, garminBloodPressureMeasurement.Systolic);
        Assert.Equal(bloodPressure.Pulse, garminBloodPressureMeasurement.Pulse);
        Assert.Equal(bloodPressure.Notes, garminBloodPressureMeasurement.Notes);

        await _garmin.RemoveBloodPressure(garminBloodPressureMeasurement);

        bloodPressureRange = await _garmin.GetBloodPressureRange(startDate, endDate);

        Assert.DoesNotContain(bloodPressureRange, x => x.Version == garminBloodPressureMeasurement.Version
                                                       && x.MeasurementTimestampLocal == garminBloodPressureMeasurement.MeasurementTimestampLocal);    
    }

    [Theory]
    [MemberData(nameof(BloodPressureData))]
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
        
        var addBloodPressure = await _garmin.AddBloodPressure(bloodPressure);

        Assert.False(addBloodPressure);
    }
    
    public static IEnumerable<object[]> BloodPressureData() {
        yield return [29, 100, 100];
        yield return [201, 100, 100];
        yield return [100, 39, 100];
        yield return [100, 301, 100];
        yield return [100, 100, 0];
        yield return [100, 100, 301];
    }
}