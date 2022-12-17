using System;
using System.Threading.Tasks;

using Garmin.Connect.Models;

using Xunit;

namespace Garmin.Connect.Tests.Integrations;

[Collection("Garmin Integrations")]
public class GearsTests
{
    private readonly Lazy<Task<GarminActivity[]>> _lazyActivities =
        new(() => LazyClient.Garmin.Value.GetActivities(1, 1));

    private readonly IGarminConnectClient _garmin;

    public GearsTests()
    {
        _garmin = LazyClient.Garmin.Value;
    }

    [Fact]
    public async Task GetGearTypes_NotNull()
    {
        var gearTypes = await _garmin.GetGearTypes();

        Assert.NotNull(gearTypes);
        Assert.NotEmpty(gearTypes);
    }

    [Fact]
    public async Task GetUserGears_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;
        var userGears = await _garmin.GetUserGears(garminActivities[0].OwnerId);

        Assert.NotNull(userGears);
        Assert.NotEmpty(userGears);
    }

    [Fact]
    public async Task GetActivityGears_NotNull()
    {
        var garminActivities = await _lazyActivities.Value;
        var activityGears = await _garmin.GetActivityGears(garminActivities[0].ActivityId);

        Assert.NotNull(activityGears);
        // Assert.NotEmpty(activityGears);
    }
}