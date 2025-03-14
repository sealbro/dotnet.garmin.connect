namespace Garmin.Connect.OAuth;

/// <summary>
/// Specifies whether the final signature value should be escaped during calculation.
/// This might be necessary for some OAuth implementations that do not obey the default
/// specification for signature escaping.
/// </summary>
internal enum OAuthSignatureTreatment
{
    Escaped,
    Unescaped
}