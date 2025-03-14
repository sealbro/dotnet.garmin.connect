namespace Garmin.Connect.OAuth;

/// <summary>
/// The types of OAuth requests possible in a typical workflow.
/// Used for validation purposes and to build static helpers.
/// </summary>
internal enum OAuthRequestType
{
    RequestToken,
    AccessToken,
    ProtectedResource,
    ClientAuthentication
}