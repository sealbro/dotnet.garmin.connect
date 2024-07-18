using System.Text.Json.Serialization;

namespace Garmin.Connect.Models.Internal;

internal record struct GarminSetUserSleepTimes
{
    [JsonPropertyName("userSleep")]
    public UserSleep UserSleep { get; init; }

    public GarminSetUserSleepTimes(long? sleepTime, long? wakeTime)
    {
        UserSleep = new UserSleep
        {
            DefaultSleepTime = !sleepTime.HasValue,
            DefaultWakeTime = !wakeTime.HasValue
        };

        if (sleepTime.HasValue)
            UserSleep = UserSleep with { SleepTime = sleepTime.Value };

        if (wakeTime.HasValue)
            UserSleep = UserSleep with { WakeTime = wakeTime.Value };
    }
}