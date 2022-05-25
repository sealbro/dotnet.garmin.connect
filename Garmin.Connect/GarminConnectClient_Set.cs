using System.Threading.Tasks;
using Garmin.Connect.Models.Internal;

namespace Garmin.Connect;

public partial class GarminConnectClient : IGarminConnectClient
{
    public Task SetUserWeight(double weight)
    {
        var garminSetUserWeight = new GarminSetUserWeight(weight);
        return _context.MakeHttpPut(UserSettingsUrl, garminSetUserWeight);
    }

    public Task SetUserSleepTimes(long? sleepTime, long? wakeTime)
    {
        var garminUserSettings = new GarminSetUserSleepTimes(sleepTime, wakeTime);

        return _context.MakeHttpPut(UserSettingsUrl, garminUserSettings);
    }
}