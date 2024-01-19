using System.Text.Json.Serialization;

namespace Garmin.Connect.Models.Internal;

internal record GarminSendToDevice
{
    [JsonPropertyName("deviceId")]
    public long DeviceId { get; init; }

    [JsonPropertyName("messageUrl")]
    public string MessageUrl { get; init; }

    [JsonPropertyName("messageType")]
    public string MessageType { get; init; }

    [JsonPropertyName("messageName")]
    public string MessageName { get; init; }

    [JsonPropertyName("groupName")]
    public object GroupName { get; init; }

    [JsonPropertyName("priority")]
    public long Priority { get; init; }

    [JsonPropertyName("fileType")]
    public string FileType { get; init; }

    [JsonPropertyName("metaDataId")]
    public long MetaDataId { get; init; }
}