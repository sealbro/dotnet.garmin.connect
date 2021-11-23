using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminDeviceSettings
{
    [JsonPropertyName("deviceId")]
    public long DeviceId { get; init; }

    [JsonPropertyName("timeFormat")]
    public string TimeFormat { get; init; }

    [JsonPropertyName("dateFormat")]
    public string DateFormat { get; init; }

    [JsonPropertyName("measurementUnits")]
    public string MeasurementUnits { get; init; }

    [JsonPropertyName("allUnits")]
    public string AllUnits { get; init; }

    [JsonPropertyName("visibleScreens")]
    public object VisibleScreens { get; init; }

    [JsonPropertyName("enabledScreens")]
    public object EnabledScreens { get; init; }

    [JsonPropertyName("screenLists")]
    public object ScreenLists { get; init; }

    [JsonPropertyName("isVivohubEnabled")]
    public object IsVivohubEnabled { get; init; }

    [JsonPropertyName("alarms")]
    public object[] Alarms { get; init; }

    [JsonPropertyName("supportedAlarmModes")]
    public object SupportedAlarmModes { get; init; }

    [JsonPropertyName("multipleAlarmEnabled")]
    public bool MultipleAlarmEnabled { get; init; }

    [JsonPropertyName("maxAlarm")]
    public object MaxAlarm { get; init; }

    [JsonPropertyName("activityTracking")]
    public object ActivityTracking { get; init; }

    [JsonPropertyName("keyTonesEnabled")]
    public object KeyTonesEnabled { get; init; }

    [JsonPropertyName("keyVibrationEnabled")]
    public object KeyVibrationEnabled { get; init; }

    [JsonPropertyName("alertTonesEnabled")]
    public object AlertTonesEnabled { get; init; }

    [JsonPropertyName("userNoticeTonesEnabled")]
    public object UserNoticeTonesEnabled { get; init; }

    [JsonPropertyName("glonassEnabled")]
    public object GlonassEnabled { get; init; }

    [JsonPropertyName("turnPromptEnabled")]
    public object TurnPromptEnabled { get; init; }

    [JsonPropertyName("segmentPromptEnabled")]
    public object SegmentPromptEnabled { get; init; }

    [JsonPropertyName("supportedLanguages")]
    public SupportedLanguage[] SupportedLanguages { get; init; }

    [JsonPropertyName("language")]
    public long Language { get; init; }

    [JsonPropertyName("supportedAudioPromptDialects")]
    public object SupportedAudioPromptDialects { get; init; }

    [JsonPropertyName("defaultPage")]
    public object DefaultPage { get; init; }

    [JsonPropertyName("displayOrientation")]
    public object DisplayOrientation { get; init; }

    [JsonPropertyName("mountingSide")]
    public object MountingSide { get; init; }

    [JsonPropertyName("backlightMode")]
    public object BacklightMode { get; init; }

    [JsonPropertyName("backlightSetting")]
    public object BacklightSetting { get; init; }

    [JsonPropertyName("customWheelSize")]
    public object CustomWheelSize { get; init; }

    [JsonPropertyName("gestureMode")]
    public object GestureMode { get; init; }

    [JsonPropertyName("goalAnimation")]
    public object GoalAnimation { get; init; }

    [JsonPropertyName("autoSyncStepsBeforeSync")]
    public object AutoSyncStepsBeforeSync { get; init; }

    [JsonPropertyName("autoSyncMinutesBeforeSync")]
    public object AutoSyncMinutesBeforeSync { get; init; }

    [JsonPropertyName("bandOrientation")]
    public object BandOrientation { get; init; }

    [JsonPropertyName("screenOrientation")]
    public object ScreenOrientation { get; init; }

    [JsonPropertyName("duringActivity")]
    public object DuringActivity { get; init; }

    [JsonPropertyName("phoneVibrationEnabled")]
    public object PhoneVibrationEnabled { get; init; }

    [JsonPropertyName("connectIQ")]
    public ConnectIq ConnectIq { get; init; }

    [JsonPropertyName("opticalHeartRateEnabled")]
    public object OpticalHeartRateEnabled { get; init; }

    [JsonPropertyName("autoUploadEnabled")]
    public bool AutoUploadEnabled { get; init; }

    [JsonPropertyName("bleConnectionAlertEnabled")]
    public object BleConnectionAlertEnabled { get; init; }

    [JsonPropertyName("phoneNotificationMode")]
    public object PhoneNotificationMode { get; init; }

    [JsonPropertyName("lactateThresholdAutoDetectEnabled")]
    public object LactateThresholdAutoDetectEnabled { get; init; }

    [JsonPropertyName("wiFiAutoUploadEnabled")]
    public object WiFiAutoUploadEnabled { get; init; }

    [JsonPropertyName("blueToothEnabled")]
    public object BlueToothEnabled { get; init; }

    [JsonPropertyName("smartNotificationsStatus")]
    public object SmartNotificationsStatus { get; init; }

    [JsonPropertyName("smartNotificationsSound")]
    public object SmartNotificationsSound { get; init; }

    [JsonPropertyName("dndEnabled")]
    public object DndEnabled { get; init; }

    [JsonPropertyName("distanceUnit")]
    public object DistanceUnit { get; init; }

    [JsonPropertyName("paceSpeedUnit")]
    public object PaceSpeedUnit { get; init; }

    [JsonPropertyName("elevationUnit")]
    public object ElevationUnit { get; init; }

    [JsonPropertyName("weightUnit")]
    public object WeightUnit { get; init; }

    [JsonPropertyName("heightUnit")]
    public object HeightUnit { get; init; }

    [JsonPropertyName("temperatureUnit")]
    public object TemperatureUnit { get; init; }

    [JsonPropertyName("runningFormat")]
    public object RunningFormat { get; init; }

    [JsonPropertyName("cyclingFormat")]
    public object CyclingFormat { get; init; }

    [JsonPropertyName("hikingFormat")]
    public object HikingFormat { get; init; }

    [JsonPropertyName("strengthFormat")]
    public object StrengthFormat { get; init; }

    [JsonPropertyName("cardioFormat")]
    public object CardioFormat { get; init; }

    [JsonPropertyName("xcSkiFormat")]
    public object XcSkiFormat { get; init; }

    [JsonPropertyName("otherFormat")]
    public object OtherFormat { get; init; }

    [JsonPropertyName("startOfWeek")]
    public string StartOfWeek { get; init; }

    [JsonPropertyName("dataRecording")]
    public object DataRecording { get; init; }

    [JsonPropertyName("soundVibrationEnabled")]
    public object SoundVibrationEnabled { get; init; }

    [JsonPropertyName("soundInAppOnlyEnabled")]
    public object SoundInAppOnlyEnabled { get; init; }

    [JsonPropertyName("backlightKeysAndAlertsEnabled")]
    public object BacklightKeysAndAlertsEnabled { get; init; }

    [JsonPropertyName("backlightWristTurnEnabled")]
    public object BacklightWristTurnEnabled { get; init; }

    [JsonPropertyName("backlightTimeout")]
    public object BacklightTimeout { get; init; }

    [JsonPropertyName("supportedBacklightTimeouts")]
    public object SupportedBacklightTimeouts { get; init; }

    [JsonPropertyName("screenTimeout")]
    public object ScreenTimeout { get; init; }

    [JsonPropertyName("colorTheme")]
    public object ColorTheme { get; init; }

    [JsonPropertyName("autoActivityDetect")]
    public object AutoActivityDetect { get; init; }

    [JsonPropertyName("sleep")]
    public object Sleep { get; init; }

    [JsonPropertyName("screenMode")]
    public object ScreenMode { get; init; }

    [JsonPropertyName("watchFace")]
    public object WatchFace { get; init; }

    [JsonPropertyName("watchFaceItemList")]
    public object WatchFaceItemList { get; init; }

    [JsonPropertyName("multipleSupportedWatchFace")]
    public MultipleSupportedWatchFace MultipleSupportedWatchFace { get; init; }

    [JsonPropertyName("supportedScreenModes")]
    public object SupportedScreenModes { get; init; }

    [JsonPropertyName("supportedWatchFaces")]
    public object SupportedWatchFaces { get; init; }

    [JsonPropertyName("supportedWatchFaceColors")]
    public object SupportedWatchFaceColors { get; init; }

    [JsonPropertyName("autoSyncFrequency")]
    public object AutoSyncFrequency { get; init; }

    [JsonPropertyName("supportedBacklightSettings")]
    public object SupportedBacklightSettings { get; init; }

    [JsonPropertyName("supportedColorThemes")]
    public object SupportedColorThemes { get; init; }

    [JsonPropertyName("disableLastEnabledScreen")]
    public object DisableLastEnabledScreen { get; init; }

    [JsonPropertyName("nickname")]
    public object Nickname { get; init; }

    [JsonPropertyName("avatar")]
    public object Avatar { get; init; }

    [JsonPropertyName("controlsMenuList")]
    public object ControlsMenuList { get; init; }

    [JsonPropertyName("customUserText")]
    public object CustomUserText { get; init; }

    [JsonPropertyName("metricsFileTrueupEnabled")]
    public bool MetricsFileTrueupEnabled { get; init; }

    [JsonPropertyName("metricsUploadCapable")]
    public object MetricsUploadCapable { get; init; }

    [JsonPropertyName("relaxRemindersEnabled")]
    public object RelaxRemindersEnabled { get; init; }

    [JsonPropertyName("smartNotificationTimeout")]
    public object SmartNotificationTimeout { get; init; }

    [JsonPropertyName("intensityMinutesCalcMethod")]
    public object IntensityMinutesCalcMethod { get; init; }

    [JsonPropertyName("moderateIntensityMinutesHrZone")]
    public object ModerateIntensityMinutesHrZone { get; init; }

    [JsonPropertyName("vigorousIntensityMinutesHrZone")]
    public object VigorousIntensityMinutesHrZone { get; init; }

    [JsonPropertyName("keepUserNamePrivate")]
    public object KeepUserNamePrivate { get; init; }

    [JsonPropertyName("audioPromptLapEnabled")]
    public object AudioPromptLapEnabled { get; init; }

    [JsonPropertyName("audioPromptSpeedPaceEnabled")]
    public object AudioPromptSpeedPaceEnabled { get; init; }

    [JsonPropertyName("audioPromptSpeedPaceType")]
    public object AudioPromptSpeedPaceType { get; init; }

    [JsonPropertyName("audioPromptSpeedPaceFrequency")]
    public object AudioPromptSpeedPaceFrequency { get; init; }

    [JsonPropertyName("audioPromptSpeedPaceDuration")]
    public object AudioPromptSpeedPaceDuration { get; init; }

    [JsonPropertyName("audioPromptHeartRateEnabled")]
    public object AudioPromptHeartRateEnabled { get; init; }

    [JsonPropertyName("audioPromptHeartRateType")]
    public object AudioPromptHeartRateType { get; init; }

    [JsonPropertyName("audioPromptHeartRateFrequency")]
    public object AudioPromptHeartRateFrequency { get; init; }

    [JsonPropertyName("audioPromptHeartRateDuration")]
    public object AudioPromptHeartRateDuration { get; init; }

    [JsonPropertyName("audioPromptDialectType")]
    public object AudioPromptDialectType { get; init; }

    [JsonPropertyName("audioPromptActivityAlertsEnabled")]
    public object AudioPromptActivityAlertsEnabled { get; init; }

    [JsonPropertyName("audioPromptPowerEnabled")]
    public object AudioPromptPowerEnabled { get; init; }

    [JsonPropertyName("audioPromptPowerType")]
    public object AudioPromptPowerType { get; init; }

    [JsonPropertyName("audioPromptPowerFrequency")]
    public object AudioPromptPowerFrequency { get; init; }

    [JsonPropertyName("audioPromptPowerDuration")]
    public object AudioPromptPowerDuration { get; init; }

    [JsonPropertyName("weightOnlyModeEnabled")]
    public object WeightOnlyModeEnabled { get; init; }

    [JsonPropertyName("phoneNotificationPrivacyMode")]
    public object PhoneNotificationPrivacyMode { get; init; }

    [JsonPropertyName("diveAlerts")]
    public object DiveAlerts { get; init; }

    [JsonPropertyName("liveEventSharingEnabled")]
    public object LiveEventSharingEnabled { get; init; }

    [JsonPropertyName("liveTrackEnabled")]
    public object LiveTrackEnabled { get; init; }

    [JsonPropertyName("liveEventSharingEndTimestamp")]
    public object LiveEventSharingEndTimestamp { get; init; }

    [JsonPropertyName("liveEventSharingMsgContents")]
    public object LiveEventSharingMsgContents { get; init; }

    [JsonPropertyName("liveEventSharingTargetDistance")]
    public object LiveEventSharingTargetDistance { get; init; }

    [JsonPropertyName("liveEventSharingMsgTriggers")]
    public object LiveEventSharingMsgTriggers { get; init; }

    [JsonPropertyName("liveEventSharingTriggerDistance")]
    public object LiveEventSharingTriggerDistance { get; init; }

    [JsonPropertyName("liveEventSharingTriggerTime")]
    public object LiveEventSharingTriggerTime { get; init; }

    [JsonPropertyName("dbDrivenDefaults")]
    public object DbDrivenDefaults { get; init; }

    [JsonPropertyName("schoolMode")]
    public object SchoolMode { get; init; }

    [JsonPropertyName("vivohubEnabled")]
    public object VivohubEnabled { get; init; }
}

public record ConnectIq
{
    [JsonPropertyName("autoUpdate")]
    public bool AutoUpdate { get; init; }
}

public record MultipleSupportedWatchFace
{
}

public record SupportedLanguage
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }
}