using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminDeviceMessages
{
    [JsonPropertyName("serviceHost")]
    public Uri ServiceHost { get; init; }

    [JsonPropertyName("numOfMessages")]
    public long NumOfMessages { get; init; }

    [JsonPropertyName("messages")]
    public GarminDeviceMessage[] Messages { get; init; }
}

public record GarminDeviceMessage
{
    [JsonPropertyName("messageId")]
    public long MessageId { get; init; }

    [JsonPropertyName("messageType")]
    public string MessageType { get; init; }

    [JsonPropertyName("messageStatus")]
    public string MessageStatus { get; init; }

    [JsonPropertyName("deviceId")]
    public long DeviceId { get; init; }

    [JsonPropertyName("deviceName")]
    public string DeviceName { get; init; }

    [JsonPropertyName("applicationKey")]
    public string ApplicationKey { get; init; }

    [JsonPropertyName("firmwareVersion")]
    public string FirmwareVersion { get; init; }

    [JsonPropertyName("wifiSetup")]
    public bool WifiSetup { get; init; }

    [JsonPropertyName("deviceXmlDataType")]
    public string DeviceXmlDataType { get; init; }

    [JsonPropertyName("hidden")]
    public bool Hidden { get; init; }

    [JsonPropertyName("createdTimeStamp")]
    public long CreatedTimeStamp { get; init; }

    [JsonPropertyName("updatedTimeStamp")]
    public object UpdatedTimeStamp { get; init; }

    [JsonPropertyName("metaData")]
    public GarminDeviceMessageMetaData MetaData { get; init; }
}

public record GarminDeviceMessageMetaData
{
    [JsonPropertyName("type")]
    public string Type { get; init; }


    [JsonPropertyName("fileType")]
    public string FileType { get; init; }


    [JsonPropertyName("messageUrl")]
    public string MessageUrl { get; init; }


    [JsonPropertyName("absolute")]
    public bool? Absolute { get; init; }


    [JsonPropertyName("messageName")]
    public string MessageName { get; init; }

    [JsonPropertyName("groupName")]
    public string GroupName { get; init; }


    [JsonPropertyName("priority")]
    public long? Priority { get; init; }


    [JsonPropertyName("metaDataId")]
    public long? MetaDataId { get; init; }

    [JsonPropertyName("appDetails")]
    public object AppDetails { get; init; }


    [JsonPropertyName("partNumber")]
    public string PartNumber { get; init; }


    [JsonPropertyName("version")]
    public string Version { get; init; }


    [JsonPropertyName("path")]
    public string Path { get; init; }


    [JsonPropertyName("fileSize")]
    public long? FileSize { get; init; }


    [JsonPropertyName("serverPath")]
    public string ServerPath { get; init; }


    [JsonPropertyName("secureServerPath")]
    public string SecureServerPath { get; init; }


    [JsonPropertyName("fileName")]
    public string FileName { get; init; }


    [JsonPropertyName("filenameOnDevice")]
    public string FilenameOnDevice { get; init; }


    [JsonPropertyName("productName")]
    public string ProductName { get; init; }


    [JsonPropertyName("dataType")]
    public string DataType { get; init; }

    [JsonPropertyName("notes")]
    public object Notes { get; init; }

    [JsonPropertyName("instructions")]
    public object Instructions { get; init; }


    [JsonPropertyName("installationOrder")]
    public long? InstallationOrder { get; init; }


    [JsonPropertyName("deliveryRestrictions")]
    public string[] DeliveryRestrictions { get; init; }


    [JsonPropertyName("changeLog")]
    public object[] ChangeLog { get; init; }
}