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
    public async Task GetPreferences_NotNull()
    {
        var preferences = await _garmin.GetPreferences();

        Assert.NotNull(preferences);
        Assert.NotNull(preferences.DisplayName);
    }

    [Fact]
    public async Task GetSocialProfile_NotNull()
    {
        var profile = await _garmin.GetSocialProfile();

        Assert.NotNull(profile);
    }

    [Fact]
    public async Task GetDeviceSettings_NotNull()
    {
        var preferences = await _garmin.GetPreferences();
        var personalRecords = await _garmin.GetPersonalRecord(preferences.DisplayName);

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

        await _garmin.SetUserWeight(userSettingsOriginal.UserData.Weight + 1000);
        var userSettingsUpdated = await _garmin.GetUserSettings();
        Assert.NotNull(userSettingsUpdated);
        Assert.True(Math.Round(userSettingsOriginal.UserData.Weight + 1000) == Math.Round(userSettingsUpdated.UserData.Weight));

        await _garmin.SetUserWeight(userSettingsOriginal.UserData.Weight);
        var userSettingsBackToOriginal = await _garmin.GetUserSettings();
        Assert.NotNull(userSettingsBackToOriginal);
        Assert.True(Math.Round(userSettingsOriginal.UserData.Weight) == Math.Round(userSettingsBackToOriginal.UserData.Weight));
    }

    [Fact]
    public async Task SetUserSleepTimes()
    {
        var userSettingsOriginal = await _garmin.GetUserSettings();
        Assert.NotNull(userSettingsOriginal);

        await _garmin.SetUserSleepTimes(1, 2);
        var userSettingsUpdated = await _garmin.GetUserSettings();
        Assert.NotNull(userSettingsUpdated);
        Assert.True(!userSettingsUpdated.UserSleep.DefaultSleepTime);
        Assert.True(userSettingsUpdated.UserSleep.SleepTime == 1);
        Assert.True(!userSettingsUpdated.UserSleep.DefaultWakeTime);
        Assert.True(userSettingsUpdated.UserSleep.WakeTime == 2);

        await _garmin.SetUserSleepTimes(userSettingsOriginal.UserSleep.DefaultSleepTime ? null : userSettingsOriginal.UserSleep.SleepTime, userSettingsOriginal.UserSleep.DefaultWakeTime ? null : userSettingsOriginal.UserSleep.WakeTime);
        var userSettingsBackToOriginal = await _garmin.GetUserSettings();
        Assert.NotNull(userSettingsBackToOriginal);
        Assert.True(userSettingsOriginal.UserSleep.DefaultSleepTime == userSettingsBackToOriginal.UserSleep.DefaultSleepTime);
        Assert.True(userSettingsOriginal.UserSleep.DefaultSleepTime || userSettingsOriginal.UserSleep.SleepTime == userSettingsBackToOriginal.UserSleep.SleepTime);
        Assert.True(userSettingsOriginal.UserSleep.DefaultWakeTime == userSettingsBackToOriginal.UserSleep.DefaultWakeTime);
        Assert.True(userSettingsOriginal.UserSleep.DefaultWakeTime || userSettingsOriginal.UserSleep.WakeTime == userSettingsBackToOriginal.UserSleep.WakeTime);
    }
}