using System;
using System.Threading.Tasks;

namespace Garmin.Connect.Tests.Integrations;

[NotInParallel("Garmin Integrations")]
public class OwnerTests
{
    private readonly IGarminConnectClient _garmin = LazyClient.Garmin.Value;

    [Test]
    public async Task GetSocialProfile_NotNull()
    {
        var profile = await _garmin.GetSocialProfile(TestContext.Current!.Execution.CancellationToken);

        await Assert.That(profile).IsNotNull();
        await Assert.That(profile.DisplayName).IsNotNull();
    }

    [Test]
    public async Task GetPersonalRecord_NotNull()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var socialProfile = await _garmin.GetSocialProfile(ct);
        var personalRecords = await _garmin.GetPersonalRecord(socialProfile.DisplayName, ct);

        await Assert.That(personalRecords).IsNotNull();
    }

    [Test]
    public async Task GetUserSettings_NotNull()
    {
        var userSettings = await _garmin.GetUserSettings(TestContext.Current!.Execution.CancellationToken);

        await Assert.That(userSettings).IsNotNull();
    }

    [Test]
    [Obsolete]
    public async Task SetUserWeight()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var userSettingsOriginal = await _garmin.GetUserSettings(ct);
        await Assert.That(userSettingsOriginal).IsNotNull();

        var shiftedWeight = userSettingsOriginal.UserData.Weight + 1000;
        await _garmin.SetUserWeight(shiftedWeight, ct);
        var userSettingsUpdated = await _garmin.GetUserSettings(ct);
        var expectedWeight = shiftedWeight;
        var actualWeight = userSettingsUpdated.UserData.Weight;

        await Assert.That(userSettingsUpdated).IsNotNull();
        await Assert.That(actualWeight).IsEqualTo(expectedWeight).Within(0.5);

        await _garmin.SetUserWeight(userSettingsOriginal.UserData.Weight, ct);
        userSettingsUpdated = await _garmin.GetUserSettings(ct);
        expectedWeight = userSettingsOriginal.UserData.Weight;
        actualWeight = Math.Round(userSettingsUpdated.UserData.Weight);

        await Assert.That(userSettingsUpdated).IsNotNull();
        await Assert.That(actualWeight).IsEqualTo(expectedWeight).Within(0.5);
    }

    [Test, Skip("Not for CI only for self test")]
    public async Task SetUserSleepTimes()
    {
        var ct = TestContext.Current!.Execution.CancellationToken;
        var userSettingsOriginal = await _garmin.GetUserSettings(ct);
        await Assert.That(userSettingsOriginal).IsNotNull();

        const int expectedSleepTime = 1;
        const int expectedWakeTime = 2;

        await _garmin.SetUserSleepTimes(expectedSleepTime, expectedWakeTime, ct);
        var userSettingsUpdated = await _garmin.GetUserSettings(ct);
        await Assert.That(userSettingsUpdated).IsNotNull();
        await Assert.That(userSettingsUpdated.UserSleep.DefaultSleepTime).IsFalse();
        await Assert.That(userSettingsUpdated.UserSleep.SleepTime).IsEqualTo(expectedSleepTime);
        await Assert.That(userSettingsUpdated.UserSleep.DefaultWakeTime).IsFalse();
        await Assert.That(userSettingsUpdated.UserSleep.WakeTime).IsEqualTo(expectedWakeTime);

        long? userSleepSleepTime = userSettingsOriginal.UserSleep.DefaultSleepTime
            ? null
            : userSettingsOriginal.UserSleep.SleepTime;
        long? userSleepWakeTime = userSettingsOriginal.UserSleep.DefaultWakeTime
            ? null
            : userSettingsOriginal.UserSleep.WakeTime;
        await _garmin.SetUserSleepTimes(userSleepSleepTime, userSleepWakeTime, ct);
        var userSettingsBackToOriginal = await _garmin.GetUserSettings(ct);
        await Assert.That(userSettingsBackToOriginal).IsNotNull();
        await Assert.That(userSettingsBackToOriginal.UserSleep.DefaultSleepTime)
            .IsEqualTo(userSettingsOriginal.UserSleep.DefaultSleepTime);
        await Assert.That(userSettingsBackToOriginal.UserSleep.SleepTime).IsEqualTo(userSleepSleepTime);
        await Assert.That(userSettingsBackToOriginal.UserSleep.DefaultWakeTime)
            .IsEqualTo(userSettingsOriginal.UserSleep.DefaultWakeTime);
        await Assert.That(userSettingsBackToOriginal.UserSleep.WakeTime).IsEqualTo(userSleepWakeTime);
    }
}
