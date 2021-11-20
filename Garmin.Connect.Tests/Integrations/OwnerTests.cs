using System.Threading.Tasks;
using Xunit;

namespace Garmin.Connect.Tests.Integrations;

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
}