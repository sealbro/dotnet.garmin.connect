using System;
using System.Diagnostics;

namespace Garmin.Connect.OAuth;

#if !Smartphone
[DebuggerDisplay("{Name}:{Value}")]
#endif
#if !SILVERLIGHT && !WINRT
[Serializable]
#endif
internal class WebParameter
{
    public WebParameter(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public string Value { get; set; }
    public string Name { get; private set; }
}