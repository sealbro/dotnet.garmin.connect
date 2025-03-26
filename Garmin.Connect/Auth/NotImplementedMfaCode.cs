using System;
using System.Threading.Tasks;

namespace Garmin.Connect.Auth;

public sealed class NotImplementedMfaCode : IMfaCodeProvider
{
    public Task<string> GetMfaCodeAsync() => throw new NotImplementedException("IMfaCodeProvider is not implemented");
}