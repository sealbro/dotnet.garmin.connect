using System.Text.Json.Serialization;

namespace Garmin.Connect.Models
{
    public class GarminDeviceSettings
    {
        [JsonPropertyName("deviceId")]
        public long DeviceId { get; set; }

        [JsonPropertyName("timeFormat")]
        public string TimeFormat { get; set; }

        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; }

        [JsonPropertyName("measurementUnits")]
        public string MeasurementUnits { get; set; }

        [JsonPropertyName("allUnits")]
        public string AllUnits { get; set; }

        [JsonPropertyName("visibleScreens")]
        public object VisibleScreens { get; set; }

        [JsonPropertyName("enabledScreens")]
        public object EnabledScreens { get; set; }

        [JsonPropertyName("screenLists")]
        public object ScreenLists { get; set; }

        [JsonPropertyName("isVivohubEnabled")]
        public object IsVivohubEnabled { get; set; }

        [JsonPropertyName("alarms")]
        public object[] Alarms { get; set; }

        [JsonPropertyName("supportedAlarmModes")]
        public object SupportedAlarmModes { get; set; }

        [JsonPropertyName("multipleAlarmEnabled")]
        public bool MultipleAlarmEnabled { get; set; }

        [JsonPropertyName("maxAlarm")]
        public object MaxAlarm { get; set; }

        [JsonPropertyName("activityTracking")]
        public object ActivityTracking { get; set; }

        [JsonPropertyName("keyTonesEnabled")]
        public object KeyTonesEnabled { get; set; }

        [JsonPropertyName("keyVibrationEnabled")]
        public object KeyVibrationEnabled { get; set; }

        [JsonPropertyName("alertTonesEnabled")]
        public object AlertTonesEnabled { get; set; }

        [JsonPropertyName("userNoticeTonesEnabled")]
        public object UserNoticeTonesEnabled { get; set; }

        [JsonPropertyName("glonassEnabled")]
        public object GlonassEnabled { get; set; }

        [JsonPropertyName("turnPromptEnabled")]
        public object TurnPromptEnabled { get; set; }

        [JsonPropertyName("segmentPromptEnabled")]
        public object SegmentPromptEnabled { get; set; }

        [JsonPropertyName("supportedLanguages")]
        public SupportedLanguage[] SupportedLanguages { get; set; }

        [JsonPropertyName("language")]
        public long Language { get; set; }

        [JsonPropertyName("supportedAudioPromptDialects")]
        public object SupportedAudioPromptDialects { get; set; }

        [JsonPropertyName("defaultPage")]
        public object DefaultPage { get; set; }

        [JsonPropertyName("displayOrientation")]
        public object DisplayOrientation { get; set; }

        [JsonPropertyName("mountingSide")]
        public object MountingSide { get; set; }

        [JsonPropertyName("backlightMode")]
        public object BacklightMode { get; set; }

        [JsonPropertyName("backlightSetting")]
        public object BacklightSetting { get; set; }

        [JsonPropertyName("customWheelSize")]
        public object CustomWheelSize { get; set; }

        [JsonPropertyName("gestureMode")]
        public object GestureMode { get; set; }

        [JsonPropertyName("goalAnimation")]
        public object GoalAnimation { get; set; }

        [JsonPropertyName("autoSyncStepsBeforeSync")]
        public object AutoSyncStepsBeforeSync { get; set; }

        [JsonPropertyName("autoSyncMinutesBeforeSync")]
        public object AutoSyncMinutesBeforeSync { get; set; }

        [JsonPropertyName("bandOrientation")]
        public object BandOrientation { get; set; }

        [JsonPropertyName("screenOrientation")]
        public object ScreenOrientation { get; set; }

        [JsonPropertyName("duringActivity")]
        public object DuringActivity { get; set; }

        [JsonPropertyName("phoneVibrationEnabled")]
        public object PhoneVibrationEnabled { get; set; }

        [JsonPropertyName("connectIQ")]
        public ConnectIq ConnectIq { get; set; }

        [JsonPropertyName("opticalHeartRateEnabled")]
        public object OpticalHeartRateEnabled { get; set; }

        [JsonPropertyName("autoUploadEnabled")]
        public bool AutoUploadEnabled { get; set; }

        [JsonPropertyName("bleConnectionAlertEnabled")]
        public object BleConnectionAlertEnabled { get; set; }

        [JsonPropertyName("phoneNotificationMode")]
        public object PhoneNotificationMode { get; set; }

        [JsonPropertyName("lactateThresholdAutoDetectEnabled")]
        public object LactateThresholdAutoDetectEnabled { get; set; }

        [JsonPropertyName("wiFiAutoUploadEnabled")]
        public object WiFiAutoUploadEnabled { get; set; }

        [JsonPropertyName("blueToothEnabled")]
        public object BlueToothEnabled { get; set; }

        [JsonPropertyName("smartNotificationsStatus")]
        public object SmartNotificationsStatus { get; set; }

        [JsonPropertyName("smartNotificationsSound")]
        public object SmartNotificationsSound { get; set; }

        [JsonPropertyName("dndEnabled")]
        public object DndEnabled { get; set; }

        [JsonPropertyName("distanceUnit")]
        public object DistanceUnit { get; set; }

        [JsonPropertyName("paceSpeedUnit")]
        public object PaceSpeedUnit { get; set; }

        [JsonPropertyName("elevationUnit")]
        public object ElevationUnit { get; set; }

        [JsonPropertyName("weightUnit")]
        public object WeightUnit { get; set; }

        [JsonPropertyName("heightUnit")]
        public object HeightUnit { get; set; }

        [JsonPropertyName("temperatureUnit")]
        public object TemperatureUnit { get; set; }

        [JsonPropertyName("runningFormat")]
        public object RunningFormat { get; set; }

        [JsonPropertyName("cyclingFormat")]
        public object CyclingFormat { get; set; }

        [JsonPropertyName("hikingFormat")]
        public object HikingFormat { get; set; }

        [JsonPropertyName("strengthFormat")]
        public object StrengthFormat { get; set; }

        [JsonPropertyName("cardioFormat")]
        public object CardioFormat { get; set; }

        [JsonPropertyName("xcSkiFormat")]
        public object XcSkiFormat { get; set; }

        [JsonPropertyName("otherFormat")]
        public object OtherFormat { get; set; }

        [JsonPropertyName("startOfWeek")]
        public string StartOfWeek { get; set; }

        [JsonPropertyName("dataRecording")]
        public object DataRecording { get; set; }

        [JsonPropertyName("soundVibrationEnabled")]
        public object SoundVibrationEnabled { get; set; }

        [JsonPropertyName("soundInAppOnlyEnabled")]
        public object SoundInAppOnlyEnabled { get; set; }

        [JsonPropertyName("backlightKeysAndAlertsEnabled")]
        public object BacklightKeysAndAlertsEnabled { get; set; }

        [JsonPropertyName("backlightWristTurnEnabled")]
        public object BacklightWristTurnEnabled { get; set; }

        [JsonPropertyName("backlightTimeout")]
        public object BacklightTimeout { get; set; }

        [JsonPropertyName("supportedBacklightTimeouts")]
        public object SupportedBacklightTimeouts { get; set; }

        [JsonPropertyName("screenTimeout")]
        public object ScreenTimeout { get; set; }

        [JsonPropertyName("colorTheme")]
        public object ColorTheme { get; set; }

        [JsonPropertyName("autoActivityDetect")]
        public object AutoActivityDetect { get; set; }

        [JsonPropertyName("sleep")]
        public object Sleep { get; set; }

        [JsonPropertyName("screenMode")]
        public object ScreenMode { get; set; }

        [JsonPropertyName("watchFace")]
        public object WatchFace { get; set; }

        [JsonPropertyName("watchFaceItemList")]
        public object WatchFaceItemList { get; set; }

        [JsonPropertyName("multipleSupportedWatchFace")]
        public MultipleSupportedWatchFace MultipleSupportedWatchFace { get; set; }

        [JsonPropertyName("supportedScreenModes")]
        public object SupportedScreenModes { get; set; }

        [JsonPropertyName("supportedWatchFaces")]
        public object SupportedWatchFaces { get; set; }

        [JsonPropertyName("supportedWatchFaceColors")]
        public object SupportedWatchFaceColors { get; set; }

        [JsonPropertyName("autoSyncFrequency")]
        public object AutoSyncFrequency { get; set; }

        [JsonPropertyName("supportedBacklightSettings")]
        public object SupportedBacklightSettings { get; set; }

        [JsonPropertyName("supportedColorThemes")]
        public object SupportedColorThemes { get; set; }

        [JsonPropertyName("disableLastEnabledScreen")]
        public object DisableLastEnabledScreen { get; set; }

        [JsonPropertyName("nickname")]
        public object Nickname { get; set; }

        [JsonPropertyName("avatar")]
        public object Avatar { get; set; }

        [JsonPropertyName("controlsMenuList")]
        public object ControlsMenuList { get; set; }

        [JsonPropertyName("customUserText")]
        public object CustomUserText { get; set; }

        [JsonPropertyName("metricsFileTrueupEnabled")]
        public bool MetricsFileTrueupEnabled { get; set; }

        [JsonPropertyName("metricsUploadCapable")]
        public object MetricsUploadCapable { get; set; }

        [JsonPropertyName("relaxRemindersEnabled")]
        public object RelaxRemindersEnabled { get; set; }

        [JsonPropertyName("smartNotificationTimeout")]
        public object SmartNotificationTimeout { get; set; }

        [JsonPropertyName("intensityMinutesCalcMethod")]
        public object IntensityMinutesCalcMethod { get; set; }

        [JsonPropertyName("moderateIntensityMinutesHrZone")]
        public object ModerateIntensityMinutesHrZone { get; set; }

        [JsonPropertyName("vigorousIntensityMinutesHrZone")]
        public object VigorousIntensityMinutesHrZone { get; set; }

        [JsonPropertyName("keepUserNamePrivate")]
        public object KeepUserNamePrivate { get; set; }

        [JsonPropertyName("audioPromptLapEnabled")]
        public object AudioPromptLapEnabled { get; set; }

        [JsonPropertyName("audioPromptSpeedPaceEnabled")]
        public object AudioPromptSpeedPaceEnabled { get; set; }

        [JsonPropertyName("audioPromptSpeedPaceType")]
        public object AudioPromptSpeedPaceType { get; set; }

        [JsonPropertyName("audioPromptSpeedPaceFrequency")]
        public object AudioPromptSpeedPaceFrequency { get; set; }

        [JsonPropertyName("audioPromptSpeedPaceDuration")]
        public object AudioPromptSpeedPaceDuration { get; set; }

        [JsonPropertyName("audioPromptHeartRateEnabled")]
        public object AudioPromptHeartRateEnabled { get; set; }

        [JsonPropertyName("audioPromptHeartRateType")]
        public object AudioPromptHeartRateType { get; set; }

        [JsonPropertyName("audioPromptHeartRateFrequency")]
        public object AudioPromptHeartRateFrequency { get; set; }

        [JsonPropertyName("audioPromptHeartRateDuration")]
        public object AudioPromptHeartRateDuration { get; set; }

        [JsonPropertyName("audioPromptDialectType")]
        public object AudioPromptDialectType { get; set; }

        [JsonPropertyName("audioPromptActivityAlertsEnabled")]
        public object AudioPromptActivityAlertsEnabled { get; set; }

        [JsonPropertyName("audioPromptPowerEnabled")]
        public object AudioPromptPowerEnabled { get; set; }

        [JsonPropertyName("audioPromptPowerType")]
        public object AudioPromptPowerType { get; set; }

        [JsonPropertyName("audioPromptPowerFrequency")]
        public object AudioPromptPowerFrequency { get; set; }

        [JsonPropertyName("audioPromptPowerDuration")]
        public object AudioPromptPowerDuration { get; set; }

        [JsonPropertyName("weightOnlyModeEnabled")]
        public object WeightOnlyModeEnabled { get; set; }

        [JsonPropertyName("phoneNotificationPrivacyMode")]
        public object PhoneNotificationPrivacyMode { get; set; }

        [JsonPropertyName("diveAlerts")]
        public object DiveAlerts { get; set; }

        [JsonPropertyName("liveEventSharingEnabled")]
        public object LiveEventSharingEnabled { get; set; }

        [JsonPropertyName("liveTrackEnabled")]
        public object LiveTrackEnabled { get; set; }

        [JsonPropertyName("liveEventSharingEndTimestamp")]
        public object LiveEventSharingEndTimestamp { get; set; }

        [JsonPropertyName("liveEventSharingMsgContents")]
        public object LiveEventSharingMsgContents { get; set; }

        [JsonPropertyName("liveEventSharingTargetDistance")]
        public object LiveEventSharingTargetDistance { get; set; }

        [JsonPropertyName("liveEventSharingMsgTriggers")]
        public object LiveEventSharingMsgTriggers { get; set; }

        [JsonPropertyName("liveEventSharingTriggerDistance")]
        public object LiveEventSharingTriggerDistance { get; set; }

        [JsonPropertyName("liveEventSharingTriggerTime")]
        public object LiveEventSharingTriggerTime { get; set; }

        [JsonPropertyName("dbDrivenDefaults")]
        public object DbDrivenDefaults { get; set; }

        [JsonPropertyName("schoolMode")]
        public object SchoolMode { get; set; }

        [JsonPropertyName("vivohubEnabled")]
        public object VivohubEnabled { get; set; }
    }

    public class ConnectIq
    {
        [JsonPropertyName("autoUpdate")]
        public bool AutoUpdate { get; set; }
    }

    public class MultipleSupportedWatchFace
    {
    }

    public class SupportedLanguage
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}