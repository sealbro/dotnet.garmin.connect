using System;

namespace Garmin.Connect.Models;

public record GarminBloodPressure
{
    public long Systolic { get; init; }

    public long Diastolic { get; init; }

    public long Pulse { get; init; }

    public string Notes { get; init; }

    public DateTime MeasurementDateTime { get; init; }

    public bool IsValid()
    {
        if (Diastolic is < 30 or > 200)
        {
            return false;
        }

        if (Systolic is < 40 or > 300)
        {
            return false;
        }

        return Pulse is >= 1 and <= 300;
    }
}