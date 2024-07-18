using System;
using System.Threading.Tasks;
using Xunit;

namespace Garmin.Connect.Tests.Integrations;

[Collection("Garmin Integrations")]
public class OwnerTests
{
    private readonly IGarminConnectClient _garmin;

    public OwnerTests()
    {
        _garmin = LazyClient.Garmin.Value;
    }

    [Fact]
    public async Task GetSocialProfile_NotNull()
    {
        var profile = await _garmin.GetSocialProfile();

        Assert.NotNull(profile);
        Assert.NotNull(profile.DisplayName);
    }

    [Fact]
    public async Task GetPersonalRecord_NotNull()
    {
        var socialProfile = await _garmin.GetSocialProfile();
        var personalRecords = await _garmin.GetPersonalRecord(socialProfile.DisplayName);

        Assert.NotNull(personalRecords);
    }

    [Fact]
    public async Task GetUserSettings_NotNull()
    {
        var userSettings = await _garmin.GetUserSettings();

        Assert.NotNull(userSettings);
    }

    [Fact]
    public async Task SetUserWeight()
    {
        var userSettingsOriginal = await _garmin.GetUserSettings();
        Assert.NotNull(userSettingsOriginal);

        var shiftedWeight = userSettingsOriginal.UserData.Weight + 1000;
        await _garmin.SetUserWeight(shiftedWeight);
        var userSettingsUpdated = await _garmin.GetUserSettings();
        var expectedWeight = shiftedWeight;
        var actualWeight = userSettingsUpdated.UserData.Weight;

        Assert.NotNull(userSettingsUpdated);
        Assert.Equal(expectedWeight, actualWeight, 1);

        await _garmin.SetUserWeight(userSettingsOriginal.UserData.Weight);
        userSettingsUpdated = await _garmin.GetUserSettings();
        expectedWeight = userSettingsOriginal.UserData.Weight;
        actualWeight = Math.Round(userSettingsUpdated.UserData.Weight);

        Assert.NotNull(userSettingsUpdated);
        Assert.Equal(expectedWeight, actualWeight, 1);
    }

    [Fact(Skip = "Not for CI only for self test")]
    public async Task SetUserSleepTimes()
    {
        var userSettingsOriginal = await _garmin.GetUserSettings();
        Assert.NotNull(userSettingsOriginal);

        const int expectedSleepTime = 1;
        const int expectedWakeTime = 2;

        await _garmin.SetUserSleepTimes(expectedSleepTime, expectedWakeTime);
        var userSettingsUpdated = await _garmin.GetUserSettings();
        Assert.NotNull(userSettingsUpdated);
        Assert.False(userSettingsUpdated.UserSleep.DefaultSleepTime);
        Assert.Equal(expectedSleepTime, userSettingsUpdated.UserSleep.SleepTime);
        Assert.False(userSettingsUpdated.UserSleep.DefaultWakeTime);
        Assert.Equal(expectedWakeTime, userSettingsUpdated.UserSleep.WakeTime);

        long? userSleepSleepTime = userSettingsOriginal.UserSleep.DefaultSleepTime ? null : userSettingsOriginal.UserSleep.SleepTime;
        long? userSleepWakeTime = userSettingsOriginal.UserSleep.DefaultWakeTime ? null : userSettingsOriginal.UserSleep.WakeTime;
        await _garmin.SetUserSleepTimes(userSleepSleepTime, userSleepWakeTime);
        var userSettingsBackToOriginal = await _garmin.GetUserSettings();
        Assert.NotNull(userSettingsBackToOriginal);
        Assert.Equal(userSettingsOriginal.UserSleep.DefaultSleepTime, userSettingsBackToOriginal.UserSleep.DefaultSleepTime);
        Assert.Equal(userSleepSleepTime, userSettingsBackToOriginal.UserSleep.SleepTime);
        Assert.Equal(userSettingsOriginal.UserSleep.DefaultWakeTime, userSettingsBackToOriginal.UserSleep.DefaultWakeTime);
        Assert.Equal(userSleepWakeTime, userSettingsBackToOriginal.UserSleep.WakeTime);
    }
}