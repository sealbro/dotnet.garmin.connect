using System;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Tests.Converters;

public class DateOnlyConverterTests
{
    private static readonly JsonSerializerOptions Options = new() { Converters = { new DateOnlyConverter() } };

    [Test]
    public async Task Read_ParsesIsoDate()
    {
        const string json = "\"2026-04-26\"";

        var actual = JsonSerializer.Deserialize<DateOnly>(json, Options);

        await Assert.That(actual).IsEqualTo(new DateOnly(2026, 4, 26));
    }

    /// <summary>
    /// A culture-sensitive parse would read this as a different date (or a different calendar).
    /// </summary>
    [Test]
    [Arguments("th-TH")]
    [Arguments("ar-SA")]
    public async Task Read_IsCultureInvariant(string culture)
    {
        var original = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = new CultureInfo(culture);
        try
        {
            var actual = JsonSerializer.Deserialize<DateOnly>("\"2026-04-26\"", Options);

            await Assert.That(actual).IsEqualTo(new DateOnly(2026, 4, 26));
            await Assert.That(JsonSerializer.Serialize(new DateOnly(2026, 4, 26), Options))
                .IsEqualTo("\"2026-04-26\"");
        }
        finally
        {
            CultureInfo.CurrentCulture = original;
        }
    }

    [Test]
    [Arguments("null")]
    [Arguments("\"\"")]
    public async Task Read_ReturnsDefaultForMissingValue(string json)
    {
        var actual = JsonSerializer.Deserialize<DateOnly>(json, Options);

        await Assert.That(actual).IsEqualTo(default(DateOnly));
    }

    [Test]
    public async Task Read_ThrowsForUnsupportedFormat()
    {
        await Assert.That(() => JsonSerializer.Deserialize<DateOnly>("\"26/04/2026\"", Options))
            .Throws<FormatException>();
    }
}
