using System;
using System.Threading.Tasks;
using Xunit;

namespace Garmin.Connect.Tests.Integrations;

[Collection("Garmin Integrations")]
public class OwnerTests
{
    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;

    [Fact]
    public async Task GetSocialProfile_NotNull()
    {
        var profile = await _garmin.GetSocialProfile(TestContext.Current.CancellationToken);

        Assert.NotNull(profile);
        Assert.NotNull(profile.DisplayName);
    }

    [Fact]
    public async Task GetPersonalRecord_NotNull()
    {
        var ct = TestContext.Current.CancellationToken;
        var socialProfile = await _garmin.GetSocialProfile(ct);
        var personalRecords = await _garmin.GetPersonalRecord(socialProfile.DisplayName, ct);

        Assert.NotNull(personalRecords);
    }

    [Fact]
    public async Task GetUserSettings_NotNull()
    {
        var userSettings = await _garmin.GetUserSettings(TestContext.Current.CancellationToken);

        Assert.NotNull(userSettings);
    }

    [Fact]
    [Obsolete]
    public async Task SetUserWeight()
    {
        var ct = TestContext.Current.CancellationToken;
        var userSettingsOriginal = await _garmin.GetUserSettings(ct);
        Assert.NotNull(userSettingsOriginal);

        var shiftedWeight = userSettingsOriginal.UserData.Weight + 1000;
        await _garmin.SetUserWeight(shiftedWeight, ct);
        var userSettingsUpdated = await _garmin.GetUserSettings(ct);
        var expectedWeight = shiftedWeight;
        var actualWeight = userSettingsUpdated.UserData.Weight;

        Assert.NotNull(userSettingsUpdated);
        Assert.Equal(expectedWeight, actualWeight, 1);

        await _garmin.SetUserWeight(userSettingsOriginal.UserData.Weight, ct);
        userSettingsUpdated = await _garmin.GetUserSettings(ct);
        expectedWeight = userSettingsOriginal.UserData.Weight;
        actualWeight = Math.Round(userSettingsUpdated.UserData.Weight);

        Assert.NotNull(userSettingsUpdated);
        Assert.Equal(expectedWeight, actualWeight, 1);
    }

    [Fact(Skip = "Not for CI only for self test")]
    public async Task SetUserSleepTimes()
    {
        var ct = TestContext.Current.CancellationToken;
        var userSettingsOriginal = await _garmin.GetUserSettings(ct);
        Assert.NotNull(userSettingsOriginal);

        const int expectedSleepTime = 1;
        const int expectedWakeTime = 2;

        await _garmin.SetUserSleepTimes(expectedSleepTime, expectedWakeTime, ct);
        var userSettingsUpdated = await _garmin.GetUserSettings(ct);
        Assert.NotNull(userSettingsUpdated);
        Assert.False(userSettingsUpdated.UserSleep.DefaultSleepTime);
        Assert.Equal(expectedSleepTime, userSettingsUpdated.UserSleep.SleepTime);
        Assert.False(userSettingsUpdated.UserSleep.DefaultWakeTime);
        Assert.Equal(expectedWakeTime, userSettingsUpdated.UserSleep.WakeTime);

        long? userSleepSleepTime = userSettingsOriginal.UserSleep.DefaultSleepTime
            ? null
            : userSettingsOriginal.UserSleep.SleepTime;
        long? userSleepWakeTime = userSettingsOriginal.UserSleep.DefaultWakeTime
            ? null
            : userSettingsOriginal.UserSleep.WakeTime;
        await _garmin.SetUserSleepTimes(userSleepSleepTime, userSleepWakeTime, ct);
        var userSettingsBackToOriginal = await _garmin.GetUserSettings(ct);
        Assert.NotNull(userSettingsBackToOriginal);
        Assert.Equal(userSettingsOriginal.UserSleep.DefaultSleepTime,
            userSettingsBackToOriginal.UserSleep.DefaultSleepTime);
        Assert.Equal(userSleepSleepTime, userSettingsBackToOriginal.UserSleep.SleepTime);
        Assert.Equal(userSettingsOriginal.UserSleep.DefaultWakeTime,
            userSettingsBackToOriginal.UserSleep.DefaultWakeTime);
        Assert.Equal(userSleepWakeTime, userSettingsBackToOriginal.UserSleep.WakeTime);
    }
}