using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminSleepData
{
    [JsonPropertyName("dailySleepDTO")]
    public DailySleepDto DailySleepDto { get; init; }

    [JsonPropertyName("sleepMovement")]
    public Sleep[] SleepMovement { get; init; }

    [JsonPropertyName("remSleepData")]
    public bool RemSleepData { get; init; }

    [JsonPropertyName("sleepLevels")]
    public Sleep[] SleepLevels { get; init; }

    [JsonPropertyName("wellnessEpochRespirationDataDTOList")]
    public WellnessEpochRespirationDataDtoList[] WellnessEpochRespirationDataDtoList { get; init; }

    [JsonPropertyName("sleepStress")]
    public SleepStress[] SleepStress { get; init; }
}

public record DailySleepDto
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("userProfilePK")]
    public long UserProfilePk { get; init; }

    [JsonPropertyName("calendarDate")]
    public DateTime CalendarDate { get; init; }

    [JsonPropertyName("sleepTimeSeconds")]
    public long SleepTimeSeconds { get; init; }

    [JsonPropertyName("napTimeSeconds")]
    public long NapTimeSeconds { get; init; }

    [JsonPropertyName("sleepWindowConfirmed")]
    public bool SleepWindowConfirmed { get; init; }

    [JsonPropertyName("sleepWindowConfirmationType")]
    public string SleepWindowConfirmationType { get; init; }

    [JsonPropertyName("sleepStartTimestampGMT")]
    public long SleepStartTimestampGmt { get; init; }

    [JsonPropertyName("sleepEndTimestampGMT")]
    public long SleepEndTimestampGmt { get; init; }

    [JsonPropertyName("sleepStartTimestampLocal")]
    public long SleepStartTimestampLocal { get; init; }

    [JsonPropertyName("sleepEndTimestampLocal")]
    public long SleepEndTimestampLocal { get; init; }

    [JsonPropertyName("autoSleepStartTimestampGMT")]
    public object AutoSleepStartTimestampGmt { get; init; }

    [JsonPropertyName("autoSleepEndTimestampGMT")]
    public object AutoSleepEndTimestampGmt { get; init; }

    [JsonPropertyName("sleepQualityTypePK")]
    public object SleepQualityTypePk { get; init; }

    [JsonPropertyName("sleepResultTypePK")]
    public object SleepResultTypePk { get; init; }

    [JsonPropertyName("unmeasurableSleepSeconds")]
    public long UnmeasurableSleepSeconds { get; init; }

    [JsonPropertyName("deepSleepSeconds")]
    public long DeepSleepSeconds { get; init; }

    [JsonPropertyName("lightSleepSeconds")]
    public long LightSleepSeconds { get; init; }

    [JsonPropertyName("remSleepSeconds")]
    public long RemSleepSeconds { get; init; }

    [JsonPropertyName("awakeSleepSeconds")]
    public long AwakeSleepSeconds { get; init; }

    [JsonPropertyName("deviceRemCapable")]
    public bool DeviceRemCapable { get; init; }

    [JsonPropertyName("retro")]
    public bool Retro { get; init; }

    [JsonPropertyName("sleepFromDevice")]
    public bool SleepFromDevice { get; init; }

    [JsonPropertyName("averageRespirationValue")]
    public double AverageRespirationValue { get; init; }

    [JsonPropertyName("lowestRespirationValue")]
    public double LowestRespirationValue { get; init; }

    [JsonPropertyName("highestRespirationValue")]
    public double HighestRespirationValue { get; init; }

    [JsonPropertyName("awakeCount")]
    public long AwakeCount { get; init; }

    [JsonPropertyName("avgSleepStress")]
    public double AvgSleepStress { get; init; }

    [JsonPropertyName("ageGroup")]
    public string AgeGroup { get; init; }

    [JsonPropertyName("sleepScoreFeedback")]
    public string SleepScoreFeedback { get; init; }

    [JsonPropertyName("sleepScoreInsight")]
    public string SleepScoreInsight { get; init; }

    [JsonPropertyName("sleepScores")]
    public SleepScores SleepScores { get; init; }
}

public record SleepScores
{
    [JsonPropertyName("totalDuration")]
    public AwakeCount TotalDuration { get; init; }

    [JsonPropertyName("stress")]
    public AwakeCount Stress { get; init; }

    [JsonPropertyName("awakeCount")]
    public AwakeCount AwakeCount { get; init; }

    [JsonPropertyName("overall")]
    public Overall Overall { get; init; }

    [JsonPropertyName("remPercentage")]
    public Percentage RemPercentage { get; init; }

    [JsonPropertyName("restlessness")]
    public Restlessness Restlessness { get; init; }

    [JsonPropertyName("lightPercentage")]
    public Percentage LightPercentage { get; init; }

    [JsonPropertyName("deepPercentage")]
    public Percentage DeepPercentage { get; init; }
}

public record AwakeCount
{
    [JsonPropertyName("qualifierKey")]
    public string QualifierKey { get; init; }

    [JsonPropertyName("optimalStart")]
    public double OptimalStart { get; init; }

    [JsonPropertyName("optimalEnd")]
    public double OptimalEnd { get; init; }
}

public record Percentage
{
    [JsonPropertyName("qualifierKey")]
    public string QualifierKey { get; init; }

    [JsonPropertyName("optimalStart")]
    public double OptimalStart { get; init; }

    [JsonPropertyName("optimalEnd")]
    public double OptimalEnd { get; init; }

    [JsonPropertyName("idealStartInSeconds")]
    public double IdealStartInSeconds { get; init; }

    [JsonPropertyName("idealEndInSeconds")]
    public double IdealEndInSeconds { get; init; }
}

public record Overall
{
    [JsonPropertyName("value")]
    public long Value { get; init; }

    [JsonPropertyName("qualifierKey")]
    public string QualifierKey { get; init; }
}

public record Restlessness
{
    [JsonPropertyName("qualifierKey")]
    public string QualifierKey { get; init; }
}

public record Sleep
{
    [JsonPropertyName("startGMT")]
    public DateTime StartGmt { get; init; }

    [JsonPropertyName("endGMT")]
    public DateTime EndGmt { get; init; }

    [JsonPropertyName("activityLevel")]
    public double ActivityLevel { get; init; }
}

public record SleepStress
{
    [JsonPropertyName("value")]
    public long Value { get; init; }

    [JsonPropertyName("startGMT")]
    public long StartGmt { get; init; }
}

public record WellnessEpochRespirationDataDtoList
{
    [JsonPropertyName("startTimeGMT")]
    public long StartTimeGmt { get; init; }

    [JsonPropertyName("respirationValue")]
    public double RespirationValue { get; init; }
}