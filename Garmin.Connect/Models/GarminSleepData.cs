using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminSleepData
{
    [JsonPropertyName("dailySleepDTO")]
    public DailySleepDto DailySleepDto { get; set; }

    [JsonPropertyName("sleepMovement")]
    public Sleep[] SleepMovement { get; set; }

    [JsonPropertyName("remSleepData")]
    public bool RemSleepData { get; set; }

    [JsonPropertyName("sleepLevels")]
    public Sleep[] SleepLevels { get; set; }

    [JsonPropertyName("wellnessEpochRespirationDataDTOList")]
    public WellnessEpochRespirationDataDtoList[] WellnessEpochRespirationDataDtoList { get; set; }

    [JsonPropertyName("sleepStress")]
    public SleepStress[] SleepStress { get; set; }
}

public class DailySleepDto
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("userProfilePK")]
    public long UserProfilePk { get; set; }

    [JsonPropertyName("calendarDate")]
    public DateTimeOffset CalendarDate { get; set; }

    [JsonPropertyName("sleepTimeSeconds")]
    public long SleepTimeSeconds { get; set; }

    [JsonPropertyName("napTimeSeconds")]
    public long NapTimeSeconds { get; set; }

    [JsonPropertyName("sleepWindowConfirmed")]
    public bool SleepWindowConfirmed { get; set; }

    [JsonPropertyName("sleepWindowConfirmationType")]
    public string SleepWindowConfirmationType { get; set; }

    [JsonPropertyName("sleepStartTimestampGMT")]
    public long SleepStartTimestampGmt { get; set; }

    [JsonPropertyName("sleepEndTimestampGMT")]
    public long SleepEndTimestampGmt { get; set; }

    [JsonPropertyName("sleepStartTimestampLocal")]
    public long SleepStartTimestampLocal { get; set; }

    [JsonPropertyName("sleepEndTimestampLocal")]
    public long SleepEndTimestampLocal { get; set; }

    [JsonPropertyName("autoSleepStartTimestampGMT")]
    public object AutoSleepStartTimestampGmt { get; set; }

    [JsonPropertyName("autoSleepEndTimestampGMT")]
    public object AutoSleepEndTimestampGmt { get; set; }

    [JsonPropertyName("sleepQualityTypePK")]
    public object SleepQualityTypePk { get; set; }

    [JsonPropertyName("sleepResultTypePK")]
    public object SleepResultTypePk { get; set; }

    [JsonPropertyName("unmeasurableSleepSeconds")]
    public long UnmeasurableSleepSeconds { get; set; }

    [JsonPropertyName("deepSleepSeconds")]
    public long DeepSleepSeconds { get; set; }

    [JsonPropertyName("lightSleepSeconds")]
    public long LightSleepSeconds { get; set; }

    [JsonPropertyName("remSleepSeconds")]
    public long RemSleepSeconds { get; set; }

    [JsonPropertyName("awakeSleepSeconds")]
    public long AwakeSleepSeconds { get; set; }

    [JsonPropertyName("deviceRemCapable")]
    public bool DeviceRemCapable { get; set; }

    [JsonPropertyName("retro")]
    public bool Retro { get; set; }

    [JsonPropertyName("sleepFromDevice")]
    public bool SleepFromDevice { get; set; }

    [JsonPropertyName("averageRespirationValue")]
    public double AverageRespirationValue { get; set; }

    [JsonPropertyName("lowestRespirationValue")]
    public double LowestRespirationValue { get; set; }

    [JsonPropertyName("highestRespirationValue")]
    public double HighestRespirationValue { get; set; }

    [JsonPropertyName("awakeCount")]
    public long AwakeCount { get; set; }

    [JsonPropertyName("avgSleepStress")]
    public double AvgSleepStress { get; set; }

    [JsonPropertyName("ageGroup")]
    public string AgeGroup { get; set; }

    [JsonPropertyName("sleepScoreFeedback")]
    public string SleepScoreFeedback { get; set; }

    [JsonPropertyName("sleepScoreInsight")]
    public string SleepScoreInsight { get; set; }

    [JsonPropertyName("sleepScores")]
    public SleepScores SleepScores { get; set; }
}

public class SleepScores
{
    [JsonPropertyName("totalDuration")]
    public AwakeCount TotalDuration { get; set; }

    [JsonPropertyName("stress")]
    public AwakeCount Stress { get; set; }

    [JsonPropertyName("awakeCount")]
    public AwakeCount AwakeCount { get; set; }

    [JsonPropertyName("overall")]
    public Overall Overall { get; set; }

    [JsonPropertyName("remPercentage")]
    public Percentage RemPercentage { get; set; }

    [JsonPropertyName("restlessness")]
    public Restlessness Restlessness { get; set; }

    [JsonPropertyName("lightPercentage")]
    public Percentage LightPercentage { get; set; }

    [JsonPropertyName("deepPercentage")]
    public Percentage DeepPercentage { get; set; }
}

public class AwakeCount
{
    [JsonPropertyName("qualifierKey")]
    public string QualifierKey { get; set; }

    [JsonPropertyName("optimalStart")]
    public double OptimalStart { get; set; }

    [JsonPropertyName("optimalEnd")]
    public double OptimalEnd { get; set; }
}

public class Percentage
{
    [JsonPropertyName("qualifierKey")]
    public string QualifierKey { get; set; }

    [JsonPropertyName("optimalStart")]
    public double OptimalStart { get; set; }

    [JsonPropertyName("optimalEnd")]
    public double OptimalEnd { get; set; }

    [JsonPropertyName("idealStartInSeconds")]
    public double IdealStartInSeconds { get; set; }

    [JsonPropertyName("idealEndInSeconds")]
    public double IdealEndInSeconds { get; set; }
}

public class Overall
{
    [JsonPropertyName("value")]
    public long Value { get; set; }

    [JsonPropertyName("qualifierKey")]
    public string QualifierKey { get; set; }
}

public class Restlessness
{
    [JsonPropertyName("qualifierKey")]
    public string QualifierKey { get; set; }
}

public class Sleep
{
    [JsonPropertyName("startGMT")]
    public DateTimeOffset StartGmt { get; set; }

    [JsonPropertyName("endGMT")]
    public DateTimeOffset EndGmt { get; set; }

    [JsonPropertyName("activityLevel")]
    public double ActivityLevel { get; set; }
}

public class SleepStress
{
    [JsonPropertyName("value")]
    public long Value { get; set; }

    [JsonPropertyName("startGMT")]
    public long StartGmt { get; set; }
}

public class WellnessEpochRespirationDataDtoList
{
    [JsonPropertyName("startTimeGMT")]
    public long StartTimeGmt { get; set; }

    [JsonPropertyName("respirationValue")]
    public double RespirationValue { get; set; }
}