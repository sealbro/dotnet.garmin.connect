using System.Threading.Tasks;
using Garmin.Connect.Auth;

namespace Garmin.Connect.Tests;

public class StaticMfaCode : IMfaCodeProvider
{
    public Task<string> GetMfaCodeAsync()
    {
        // var code = Console.ReadLine().Trim();
        var code = "123456";
        return Task.FromResult(code);
    }
}