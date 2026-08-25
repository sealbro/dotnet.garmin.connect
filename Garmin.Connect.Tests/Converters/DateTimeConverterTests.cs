using System;
using System.Text.Json;
using System.Threading.Tasks;
using Garmin.Connect.Converters;

namespace Garmin.Connect.Tests.Converters;

public class DateTimeConverterTests
{
    private static readonly JsonSerializerOptions Options = new() { Converters = { new DateTimeConverter() } };

    [Test]
    [Arguments("\"2026-04-26\"", 2026, 4, 26, 0, 0, 0, 0)]
    [Arguments("\"2026-04-26 05:32:52\"", 2026, 4, 26, 5, 32, 52, 0)]
    [Arguments("\"2026-04-26T05:32:52.4\"", 2026, 4, 26, 5, 32, 52, 400)]
    [Arguments("\"2026-04-26T05:32:52.43\"", 2026, 4, 26, 5, 32, 52, 430)]
    [Arguments("\"2026-04-26T05:32:52.431\"", 2026, 4, 26, 5, 32, 52, 431)]
    public async Task Read_ParsesSupportedFormats(string json, int year, int month, int day, int hour, int minute,
        int second, int millisecond)
    {
        var actual = JsonSerializer.Deserialize<DateTime>(json, Options);

        var expected = new DateTime(year, month, day, hour, minute, second, millisecond);
        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    public async Task Read_ParsesFormatWithTimezoneOffset()
    {
        const string json = "\"2026-04-26T05:32:52.431+02:00\"";

        var actual = JsonSerializer.Deserialize<DateTime>(json, Options);

        var expected = new DateTimeOffset(2026, 4, 26, 5, 32, 52, 431, TimeSpan.FromHours(2)).LocalDateTime;
        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    public async Task Read_ThrowsForUnsupportedFormat()
    {
        const string json = "\"26/04/2026\"";

        await Assert.That(() => JsonSerializer.Deserialize<DateTime>(json, Options)).Throws<FormatException>();
    }
}
