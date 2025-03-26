using System.Threading.Tasks;

namespace Garmin.Connect.Auth;

/// <summary>
/// Defines a provider for multi-factor authentication codes.
/// </summary>
public interface IMfaCodeProvider
{
    /// <summary>
    /// Gets a multi-factor authentication code from email, SMS, etc.
    /// You can implement this interface to provide the MFA code.
    /// </summary>
    /// <returns>MFA code</returns>
    Task<string> GetMfaCodeAsync();
}