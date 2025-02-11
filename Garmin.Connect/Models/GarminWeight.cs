using System;

namespace Garmin.Connect.Models;

public record GarminWeight
{
    public DateTime MeasurementDateTime { get; init; }

    public WeightUnit UnitKey { get; init; }

    public double Value { get; init; }

    public bool IsValid()
    {
        return Value is >= 1.0 and <= 453.0;
    }
}

public enum WeightUnit
{
    Kg,
    Lbs,
}