using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public class GarminDevice
{
    [JsonPropertyName("appSupport")]
    public bool AppSupport { get; set; }

    [JsonPropertyName("applicationKey")]
    public string ApplicationKey { get; set; }

    [JsonPropertyName("deviceTypePk")]
    public long DeviceTypePk { get; set; }

    [JsonPropertyName("bestInClassVideoLink")]
    public string BestInClassVideoLink { get; set; }

    [JsonPropertyName("bluetoothClassicDevice")]
    public bool BluetoothClassicDevice { get; set; }

    [JsonPropertyName("bluetoothLowEnergyDevice")]
    public bool BluetoothLowEnergyDevice { get; set; }

    [JsonPropertyName("deviceCategories")]
    public string[] DeviceCategories { get; set; }

    [JsonPropertyName("deviceEmbedVideoLink")]
    public string DeviceEmbedVideoLink { get; set; }

    [JsonPropertyName("deviceSettingsFile")]
    public string DeviceSettingsFile { get; set; }

    [JsonPropertyName("gcmSettingsFile")]
    public string GcmSettingsFile { get; set; }

    [JsonPropertyName("deviceVideoPageLink")]
    public string DeviceVideoPageLink { get; set; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; set; }

    [JsonPropertyName("golfDisplayOrder")]
    public long GolfDisplayOrder { get; set; }

    [JsonPropertyName("hasOpticalHeartRate")]
    public bool HasOpticalHeartRate { get; set; }

    [JsonPropertyName("highlighted")]
    public bool Highlighted { get; set; }

    [JsonPropertyName("hybrid")]
    public bool Hybrid { get; set; }

    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("minGCMAndroidVersion")]
    public long MinGcmAndroidVersion { get; set; }

    [JsonPropertyName("minGCMWindowsVersion")]
    public long MinGcmWindowsVersion { get; set; }

    [JsonPropertyName("minGCMiOSVersion")]
    public long MinGcMiOsVersion { get; set; }

    [JsonPropertyName("minGolfAppiOSVersion")]
    public long MinGolfAppiOsVersion { get; set; }

    [JsonPropertyName("minGolfAppAndroidVersion")]
    public long MinGolfAppAndroidVersion { get; set; }

    [JsonPropertyName("partNumber")]
    public string PartNumber { get; set; }

    [JsonPropertyName("primary")]
    public bool Primary { get; set; }

    [JsonPropertyName("productDisplayName")]
    public string ProductDisplayName { get; set; }

    [JsonPropertyName("deviceTags")]
    public object DeviceTags { get; set; }

    [JsonPropertyName("productSku")]
    public string ProductSku { get; set; }

    [JsonPropertyName("wasp")]
    public bool Wasp { get; set; }

    [JsonPropertyName("weightScale")]
    public bool WeightScale { get; set; }

    [JsonPropertyName("wellness")]
    public bool Wellness { get; set; }

    [JsonPropertyName("wifi")]
    public bool Wifi { get; set; }

    [JsonPropertyName("hasPowerButton")]
    public bool HasPowerButton { get; set; }

    [JsonPropertyName("supportsSecondaryUsers")]
    public bool SupportsSecondaryUsers { get; set; }

    [JsonPropertyName("abnormalHeartRateAlertCapable")]
    public bool AbnormalHeartRateAlertCapable { get; set; }

    [JsonPropertyName("activitySummFitFileCapable")]
    public bool ActivitySummFitFileCapable { get; set; }

    [JsonPropertyName("aerobicTrainingEffectCapable")]
    public bool AerobicTrainingEffectCapable { get; set; }

    [JsonPropertyName("alarmDaysCapable")]
    public bool AlarmDaysCapable { get; set; }

    [JsonPropertyName("allDayStressCapable")]
    public bool AllDayStressCapable { get; set; }

    [JsonPropertyName("anaerobicTrainingEffectCapable")]
    public bool AnaerobicTrainingEffectCapable { get; set; }

    [JsonPropertyName("atpWorkoutCapable")]
    public bool AtpWorkoutCapable { get; set; }

    [JsonPropertyName("bodyBatteryCapable")]
    public bool BodyBatteryCapable { get; set; }

    [JsonPropertyName("brickWorkoutCapable")]
    public bool BrickWorkoutCapable { get; set; }

    [JsonPropertyName("cardioCapable")]
    public bool CardioCapable { get; set; }

    [JsonPropertyName("cardioOptionCapable")]
    public bool CardioOptionCapable { get; set; }

    [JsonPropertyName("cardioSportsCapable")]
    public bool CardioSportsCapable { get; set; }

    [JsonPropertyName("cardioWorkoutCapable")]
    public bool CardioWorkoutCapable { get; set; }

    [JsonPropertyName("cellularCapable")]
    public bool CellularCapable { get; set; }

    [JsonPropertyName("changeLogCapable")]
    public bool ChangeLogCapable { get; set; }

    [JsonPropertyName("contactManagementCapable")]
    public bool ContactManagementCapable { get; set; }

    [JsonPropertyName("courseCapable")]
    public bool CourseCapable { get; set; }

    [JsonPropertyName("courseFileType")]
    public string CourseFileType { get; set; }

    [JsonPropertyName("coursePromptCapable")]
    public bool CoursePromptCapable { get; set; }

    [JsonPropertyName("customIntensityMinutesCapable")]
    public bool CustomIntensityMinutesCapable { get; set; }

    [JsonPropertyName("customWorkoutCapable")]
    public bool CustomWorkoutCapable { get; set; }

    [JsonPropertyName("cyclingSegmentCapable")]
    public bool CyclingSegmentCapable { get; set; }

    [JsonPropertyName("cyclingSportsCapable")]
    public bool CyclingSportsCapable { get; set; }

    [JsonPropertyName("cyclingWorkoutCapable")]
    public bool CyclingWorkoutCapable { get; set; }

    [JsonPropertyName("defaultSettingCapable")]
    public bool DefaultSettingCapable { get; set; }

    [JsonPropertyName("deviceSettingCapable")]
    public bool DeviceSettingCapable { get; set; }

    [JsonPropertyName("deviceSettingFileType")]
    public object DeviceSettingFileType { get; set; }

    [JsonPropertyName("displayFieldsExtCapable")]
    public bool DisplayFieldsExtCapable { get; set; }

    [JsonPropertyName("divingCapable")]
    public bool DivingCapable { get; set; }

    [JsonPropertyName("ellipticalOptionCapable")]
    public bool EllipticalOptionCapable { get; set; }

    [JsonPropertyName("floorsClimbedGoalCapable")]
    public bool FloorsClimbedGoalCapable { get; set; }

    [JsonPropertyName("ftpCapable")]
    public bool FtpCapable { get; set; }

    [JsonPropertyName("gcj02CourseCapable")]
    public bool Gcj02CourseCapable { get; set; }

    [JsonPropertyName("glonassCapable")]
    public bool GlonassCapable { get; set; }

    [JsonPropertyName("goalCapable")]
    public bool GoalCapable { get; set; }

    [JsonPropertyName("goalFileType")]
    public string GoalFileType { get; set; }

    [JsonPropertyName("golfAppSyncCapable")]
    public bool GolfAppSyncCapable { get; set; }

    [JsonPropertyName("gpsRouteCapable")]
    public bool GpsRouteCapable { get; set; }

    [JsonPropertyName("handednessCapable")]
    public bool HandednessCapable { get; set; }

    [JsonPropertyName("hrZoneCapable")]
    public bool HrZoneCapable { get; set; }

    [JsonPropertyName("hrvStressCapable")]
    public bool HrvStressCapable { get; set; }

    [JsonPropertyName("intensityMinutesGoalCapable")]
    public bool IntensityMinutesGoalCapable { get; set; }

    [JsonPropertyName("lactateThresholdCapable")]
    public bool LactateThresholdCapable { get; set; }

    [JsonPropertyName("languageSettingCapable")]
    public bool LanguageSettingCapable { get; set; }

    [JsonPropertyName("languageSettingFileType")]
    public object LanguageSettingFileType { get; set; }

    [JsonPropertyName("lowHrAlertCapable")]
    public bool LowHrAlertCapable { get; set; }

    [JsonPropertyName("maxHRCapable")]
    public bool MaxHrCapable { get; set; }

    [JsonPropertyName("maxWorkoutCount")]
    public long MaxWorkoutCount { get; set; }

    [JsonPropertyName("metricsFitFileReceiveCapable")]
    public bool MetricsFitFileReceiveCapable { get; set; }

    [JsonPropertyName("metricsUploadCapable")]
    public bool MetricsUploadCapable { get; set; }

    [JsonPropertyName("militaryTimeCapable")]
    public bool MilitaryTimeCapable { get; set; }

    [JsonPropertyName("moderateIntensityMinutesGoalCapable")]
    public bool ModerateIntensityMinutesGoalCapable { get; set; }

    [JsonPropertyName("nfcCapable")]
    public bool NfcCapable { get; set; }

    [JsonPropertyName("otherOptionCapable")]
    public bool OtherOptionCapable { get; set; }

    [JsonPropertyName("otherSportsCapable")]
    public bool OtherSportsCapable { get; set; }

    [JsonPropertyName("personalRecordCapable")]
    public bool PersonalRecordCapable { get; set; }

    [JsonPropertyName("personalRecordFileType")]
    public string PersonalRecordFileType { get; set; }

    [JsonPropertyName("poolSwimOptionCapable")]
    public bool PoolSwimOptionCapable { get; set; }

    [JsonPropertyName("powerCurveCapable")]
    public bool PowerCurveCapable { get; set; }

    [JsonPropertyName("powerZonesCapable")]
    public bool PowerZonesCapable { get; set; }

    [JsonPropertyName("pulseOxAllDayCapable")]
    public bool PulseOxAllDayCapable { get; set; }

    [JsonPropertyName("pulseOxOnDemandCapable")]
    public bool PulseOxOnDemandCapable { get; set; }

    [JsonPropertyName("pulseOxSleepCapable")]
    public bool PulseOxSleepCapable { get; set; }

    [JsonPropertyName("remCapable")]
    public bool RemCapable { get; set; }

    [JsonPropertyName("reminderAlarmCapable")]
    public bool ReminderAlarmCapable { get; set; }

    [JsonPropertyName("reorderablePagesCapable")]
    public bool ReorderablePagesCapable { get; set; }

    [JsonPropertyName("restingHRCapable")]
    public bool RestingHrCapable { get; set; }

    [JsonPropertyName("rideOptionsCapable")]
    public bool RideOptionsCapable { get; set; }

    [JsonPropertyName("runOptionIndoorCapable")]
    public bool RunOptionIndoorCapable { get; set; }

    [JsonPropertyName("runOptionsCapable")]
    public bool RunOptionsCapable { get; set; }

    [JsonPropertyName("runningSegmentCapable")]
    public bool RunningSegmentCapable { get; set; }

    [JsonPropertyName("runningSportsCapable")]
    public bool RunningSportsCapable { get; set; }

    [JsonPropertyName("runningWorkoutCapable")]
    public bool RunningWorkoutCapable { get; set; }

    [JsonPropertyName("scheduleCapable")]
    public bool ScheduleCapable { get; set; }

    [JsonPropertyName("scheduleFileType")]
    public string ScheduleFileType { get; set; }

    [JsonPropertyName("segmentCapable")]
    public bool SegmentCapable { get; set; }

    [JsonPropertyName("segmentPointCapable")]
    public bool SegmentPointCapable { get; set; }

    [JsonPropertyName("settingCapable")]
    public bool SettingCapable { get; set; }

    [JsonPropertyName("settingFileType")]
    public string SettingFileType { get; set; }

    [JsonPropertyName("sleepTimeCapable")]
    public bool SleepTimeCapable { get; set; }

    [JsonPropertyName("smallFitFileOnlyCapable")]
    public bool SmallFitFileOnlyCapable { get; set; }

    [JsonPropertyName("sportCapable")]
    public bool SportCapable { get; set; }

    [JsonPropertyName("sportFileType")]
    public string SportFileType { get; set; }

    [JsonPropertyName("stairStepperOptionCapable")]
    public bool StairStepperOptionCapable { get; set; }

    [JsonPropertyName("strengthOptionsCapable")]
    public bool StrengthOptionsCapable { get; set; }

    [JsonPropertyName("strengthWorkoutCapable")]
    public bool StrengthWorkoutCapable { get; set; }

    [JsonPropertyName("supportedHrZones")]
    public string[] SupportedHrZones { get; set; }

    [JsonPropertyName("swimWorkoutCapable")]
    public bool SwimWorkoutCapable { get; set; }

    [JsonPropertyName("trainingPlanCapable")]
    public bool TrainingPlanCapable { get; set; }

    [JsonPropertyName("trainingStatusCapable")]
    public bool TrainingStatusCapable { get; set; }

    [JsonPropertyName("trainingStatusPauseCapable")]
    public bool TrainingStatusPauseCapable { get; set; }

    [JsonPropertyName("userProfileCapable")]
    public bool UserProfileCapable { get; set; }

    [JsonPropertyName("userProfileFileType")]
    public object UserProfileFileType { get; set; }

    [JsonPropertyName("userTcxExportCapable")]
    public bool UserTcxExportCapable { get; set; }

    [JsonPropertyName("vo2MaxBikeCapable")]
    public bool Vo2MaxBikeCapable { get; set; }

    [JsonPropertyName("vo2MaxRunCapable")]
    public bool Vo2MaxRunCapable { get; set; }

    [JsonPropertyName("walkOptionCapable")]
    public bool WalkOptionCapable { get; set; }

    [JsonPropertyName("walkingSportsCapable")]
    public bool WalkingSportsCapable { get; set; }

    [JsonPropertyName("weatherAlertsCapable")]
    public bool WeatherAlertsCapable { get; set; }

    [JsonPropertyName("weatherSettingsCapable")]
    public bool WeatherSettingsCapable { get; set; }

    [JsonPropertyName("workoutCapable")]
    public bool WorkoutCapable { get; set; }

    [JsonPropertyName("workoutFileType")]
    public string WorkoutFileType { get; set; }

    [JsonPropertyName("yogaCapable")]
    public bool YogaCapable { get; set; }

    [JsonPropertyName("yogaOptionCapable")]
    public bool YogaOptionCapable { get; set; }

    [JsonPropertyName("heatAndAltitudeAcclimationCapable")]
    public bool HeatAndAltitudeAcclimationCapable { get; set; }

    [JsonPropertyName("trainingLoadBalanceCapable")]
    public bool TrainingLoadBalanceCapable { get; set; }

    [JsonPropertyName("indoorTrackOptionsCapable")]
    public bool IndoorTrackOptionsCapable { get; set; }

    [JsonPropertyName("indoorBikeOptionsCapable")]
    public bool IndoorBikeOptionsCapable { get; set; }

    [JsonPropertyName("indoorWalkOptionsCapable")]
    public bool IndoorWalkOptionsCapable { get; set; }

    [JsonPropertyName("trainingEffectLabelCapable")]
    public bool TrainingEffectLabelCapable { get; set; }

    [JsonPropertyName("pacebandCapable")]
    public bool PacebandCapable { get; set; }

    [JsonPropertyName("respirationCapable")]
    public bool RespirationCapable { get; set; }

    [JsonPropertyName("openWaterSwimOptionCapable")]
    public bool OpenWaterSwimOptionCapable { get; set; }

    [JsonPropertyName("phoneVerificationCheckRequired")]
    public bool PhoneVerificationCheckRequired { get; set; }

    [JsonPropertyName("weightGoalCapable")]
    public bool WeightGoalCapable { get; set; }

    [JsonPropertyName("yogaWorkoutCapable")]
    public bool YogaWorkoutCapable { get; set; }

    [JsonPropertyName("pilatesWorkoutCapable")]
    public bool PilatesWorkoutCapable { get; set; }

    [JsonPropertyName("connectedGPSCapable")]
    public bool ConnectedGpsCapable { get; set; }

    [JsonPropertyName("diveAppSyncCapable")]
    public bool DiveAppSyncCapable { get; set; }

    [JsonPropertyName("golfLiveScoringCapable")]
    public bool GolfLiveScoringCapable { get; set; }

    [JsonPropertyName("bloodEfficiencySleepCapable")]
    public bool BloodEfficiencySleepCapable { get; set; }

    [JsonPropertyName("bloodEfficiencyAllDayCapable")]
    public bool BloodEfficiencyAllDayCapable { get; set; }

    [JsonPropertyName("bloodEfficiencyOnDemandCapable")]
    public bool BloodEfficiencyOnDemandCapable { get; set; }

    [JsonPropertyName("solarPanelUtilizationCapable")]
    public bool SolarPanelUtilizationCapable { get; set; }

    [JsonPropertyName("sweatLossCapable")]
    public bool SweatLossCapable { get; set; }

    [JsonPropertyName("diveAlertCapable")]
    public bool DiveAlertCapable { get; set; }

    [JsonPropertyName("requiresInitialDeviceNickname")]
    public bool RequiresInitialDeviceNickname { get; set; }

    [JsonPropertyName("defaultSettingsHbaseMigrated")]
    public bool DefaultSettingsHbaseMigrated { get; set; }

    [JsonPropertyName("sleepScoreCapable")]
    public bool SleepScoreCapable { get; set; }

    [JsonPropertyName("fitnessAgeV2Capable")]
    public bool FitnessAgeV2Capable { get; set; }

    [JsonPropertyName("intensityMinutesV2Capable")]
    public bool IntensityMinutesV2Capable { get; set; }

    [JsonPropertyName("collapsibleControlMenuCapable")]
    public bool CollapsibleControlMenuCapable { get; set; }

    [JsonPropertyName("measurementUnitSettingCapable")]
    public bool MeasurementUnitSettingCapable { get; set; }

    [JsonPropertyName("onDeviceSleepCalculationCapable")]
    public bool OnDeviceSleepCalculationCapable { get; set; }

    [JsonPropertyName("hiitWorkoutCapable")]
    public bool HiitWorkoutCapable { get; set; }

    [JsonPropertyName("runningHeartRateZoneCapable")]
    public bool RunningHeartRateZoneCapable { get; set; }

    [JsonPropertyName("cyclingHeartRateZoneCapable")]
    public bool CyclingHeartRateZoneCapable { get; set; }

    [JsonPropertyName("swimmingHeartRateZoneCapable")]
    public bool SwimmingHeartRateZoneCapable { get; set; }

    [JsonPropertyName("defaultHeartRateZoneCapable")]
    public bool DefaultHeartRateZoneCapable { get; set; }

    [JsonPropertyName("cyclingPowerZonesCapable")]
    public bool CyclingPowerZonesCapable { get; set; }

    [JsonPropertyName("xcSkiPowerZonesCapable")]
    public bool XcSkiPowerZonesCapable { get; set; }

    [JsonPropertyName("swimAlgorithmCapable")]
    public bool SwimAlgorithmCapable { get; set; }

    [JsonPropertyName("benchmarkExerciseCapable")]
    public bool BenchmarkExerciseCapable { get; set; }

    [JsonPropertyName("spectatorMessagingCapable")]
    public bool SpectatorMessagingCapable { get; set; }

    [JsonPropertyName("ecgCapable")]
    public bool EcgCapable { get; set; }

    [JsonPropertyName("lteLiveEventSharingCapable")]
    public bool LteLiveEventSharingCapable { get; set; }

    [JsonPropertyName("sleepFitFileReceiveCapable")]
    public bool SleepFitFileReceiveCapable { get; set; }

    [JsonPropertyName("secondaryWorkoutStepTargetCapable")]
    public bool SecondaryWorkoutStepTargetCapable { get; set; }

    [JsonPropertyName("assistancePlusCapable")]
    public bool AssistancePlusCapable { get; set; }

    [JsonPropertyName("powerGuidanceCapable")]
    public bool PowerGuidanceCapable { get; set; }

    [JsonPropertyName("airIntegrationCapable")]
    public bool AirIntegrationCapable { get; set; }

    [JsonPropertyName("healthSnapshotCapable")]
    public bool HealthSnapshotCapable { get; set; }

    [JsonPropertyName("racePredictionsRunCapable")]
    public bool RacePredictionsRunCapable { get; set; }

    [JsonPropertyName("vivohubCompatible")]
    public bool VivohubCompatible { get; set; }

    [JsonPropertyName("stepsTrueUpChartCapable")]
    public bool StepsTrueUpChartCapable { get; set; }

    [JsonPropertyName("sportingEventCapable")]
    public bool SportingEventCapable { get; set; }

    [JsonPropertyName("solarChargeCapable")]
    public bool SolarChargeCapable { get; set; }

    [JsonPropertyName("realTimeSettingsCapable")]
    public bool RealTimeSettingsCapable { get; set; }

    [JsonPropertyName("emergencyCallingCapable")]
    public bool EmergencyCallingCapable { get; set; }

    [JsonPropertyName("personalRepRecordCapable")]
    public bool PersonalRepRecordCapable { get; set; }

    [JsonPropertyName("hrvStatusCapable")]
    public bool HrvStatusCapable { get; set; }

    [JsonPropertyName("trainingReadinessCapable")]
    public bool TrainingReadinessCapable { get; set; }

    [JsonPropertyName("publicBetaSoftwareCapable")]
    public bool PublicBetaSoftwareCapable { get; set; }

    [JsonPropertyName("workoutAudioPromptsCapable")]
    public bool WorkoutAudioPromptsCapable { get; set; }

    [JsonPropertyName("actualStepRecordingCapable")]
    public bool ActualStepRecordingCapable { get; set; }

    [JsonPropertyName("groupTrack2Capable")]
    public bool GroupTrack2Capable { get; set; }

    [JsonPropertyName("golfAppPairingCapable")]
    public bool GolfAppPairingCapable { get; set; }

    [JsonPropertyName("localWindConditionsCapable")]
    public bool LocalWindConditionsCapable { get; set; }

    [JsonPropertyName("multipleGolfCourseCapable")]
    public bool MultipleGolfCourseCapable { get; set; }

    [JsonPropertyName("beaconTrackingCapable")]
    public bool BeaconTrackingCapable { get; set; }

    [JsonPropertyName("batteryStatusCapable")]
    public bool BatteryStatusCapable { get; set; }

    [JsonPropertyName("datasource")]
    public string Datasource { get; set; }

    [JsonPropertyName("deviceStatus")]
    public string DeviceStatus { get; set; }

    [JsonPropertyName("registeredDate")]
    public long RegisteredDate { get; set; }

    [JsonPropertyName("actualProductSku")]
    public string ActualProductSku { get; set; }

    [JsonPropertyName("vivohubConfigurable")]
    public object VivohubConfigurable { get; set; }

    [JsonPropertyName("serialNumber")]
    public string SerialNumber { get; set; }

    [JsonPropertyName("shortName")]
    public object ShortName { get; set; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("unitId")]
    public long UnitId { get; set; }

    [JsonPropertyName("deviceId")]
    public long DeviceId { get; set; }

    [JsonPropertyName("wifiSetup")]
    public bool WifiSetup { get; set; }

    [JsonPropertyName("currentFirmwareVersionMajor")]
    public long CurrentFirmwareVersionMajor { get; set; }

    [JsonPropertyName("currentFirmwareVersionMinor")]
    public long CurrentFirmwareVersionMinor { get; set; }

    [JsonPropertyName("activeInd")]
    public long ActiveInd { get; set; }

    [JsonPropertyName("primaryActivityTrackerIndicator")]
    public bool PrimaryActivityTrackerIndicator { get; set; }

    [JsonPropertyName("currentFirmwareVersion")]
    public string CurrentFirmwareVersion { get; set; }

    [JsonPropertyName("isPrimaryUser")]
    public bool IsPrimaryUser { get; set; }

    [JsonPropertyName("corporateDevice")]
    public bool CorporateDevice { get; set; }

    [JsonPropertyName("prePairedWithHRM")]
    public bool PrePairedWithHrm { get; set; }

    [JsonPropertyName("unRetirable")]
    public bool UnRetirable { get; set; }

    [JsonPropertyName("otherAssociation")]
    public bool OtherAssociation { get; set; }

    [JsonPropertyName("minCustomIntensityMinutesVersion")]
    public string MinCustomIntensityMinutesVersion { get; set; }
}