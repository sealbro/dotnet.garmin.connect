namespace Garmin.Connect.Auth;

public class StaticUserAgent : IUserAgent
{
    private const string DefaultUseAgent = "GCM-iOS-5.7.2.1";

    public string New { get; }

    public StaticUserAgent() : this(DefaultUseAgent)
    {
    }

    private StaticUserAgent(string defaultUseAgent)
    {
        New = defaultUseAgent;
    }
}