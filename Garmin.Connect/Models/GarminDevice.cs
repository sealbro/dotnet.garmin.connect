using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminDevice
{
    [JsonPropertyName("appSupport")]
    public bool AppSupport { get; init; }

    [JsonPropertyName("applicationKey")]
    public string ApplicationKey { get; init; }

    [JsonPropertyName("deviceTypePk")]
    public long DeviceTypePk { get; init; }

    [JsonPropertyName("bestInClassVideoLink")]
    public string BestInClassVideoLink { get; init; }

    [JsonPropertyName("bluetoothClassicDevice")]
    public bool BluetoothClassicDevice { get; init; }

    [JsonPropertyName("bluetoothLowEnergyDevice")]
    public bool BluetoothLowEnergyDevice { get; init; }

    [JsonPropertyName("deviceCategories")]
    public string[] DeviceCategories { get; init; }

    [JsonPropertyName("deviceEmbedVideoLink")]
    public string DeviceEmbedVideoLink { get; init; }

    [JsonPropertyName("deviceSettingsFile")]
    public string DeviceSettingsFile { get; init; }

    [JsonPropertyName("gcmSettingsFile")]
    public string GcmSettingsFile { get; init; }

    [JsonPropertyName("deviceVideoPageLink")]
    public string DeviceVideoPageLink { get; init; }

    [JsonPropertyName("displayOrder")]
    public long DisplayOrder { get; init; }

    [JsonPropertyName("golfDisplayOrder")]
    public long GolfDisplayOrder { get; init; }

    [JsonPropertyName("hasOpticalHeartRate")]
    public bool HasOpticalHeartRate { get; init; }

    [JsonPropertyName("highlighted")]
    public bool Highlighted { get; init; }

    [JsonPropertyName("hybrid")]
    public bool Hybrid { get; init; }

    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; init; }

    [JsonPropertyName("minGCMAndroidVersion")]
    public long MinGcmAndroidVersion { get; init; }

    [JsonPropertyName("minGCMWindowsVersion")]
    public long MinGcmWindowsVersion { get; init; }

    [JsonPropertyName("minGCMiOSVersion")]
    public long MinGcMiOsVersion { get; init; }

    [JsonPropertyName("minGolfAppiOSVersion")]
    public long MinGolfAppiOsVersion { get; init; }

    [JsonPropertyName("minGolfAppAndroidVersion")]
    public long MinGolfAppAndroidVersion { get; init; }

    [JsonPropertyName("partNumber")]
    public string PartNumber { get; init; }

    [JsonPropertyName("primary")]
    public bool Primary { get; init; }

    [JsonPropertyName("productDisplayName")]
    public string ProductDisplayName { get; init; }

    [JsonPropertyName("deviceTags")]
    public object DeviceTags { get; init; }

    [JsonPropertyName("productSku")]
    public string ProductSku { get; init; }

    [JsonPropertyName("wasp")]
    public bool Wasp { get; init; }

    [JsonPropertyName("weightScale")]
    public bool WeightScale { get; init; }

    [JsonPropertyName("wellness")]
    public bool Wellness { get; init; }

    [JsonPropertyName("wifi")]
    public bool Wifi { get; init; }

    [JsonPropertyName("hasPowerButton")]
    public bool HasPowerButton { get; init; }

    [JsonPropertyName("supportsSecondaryUsers")]
    public bool SupportsSecondaryUsers { get; init; }

    [JsonPropertyName("abnormalHeartRateAlertCapable")]
    public bool AbnormalHeartRateAlertCapable { get; init; }

    [JsonPropertyName("activitySummFitFileCapable")]
    public bool ActivitySummFitFileCapable { get; init; }

    [JsonPropertyName("aerobicTrainingEffectCapable")]
    public bool AerobicTrainingEffectCapable { get; init; }

    [JsonPropertyName("alarmDaysCapable")]
    public bool AlarmDaysCapable { get; init; }

    [JsonPropertyName("allDayStressCapable")]
    public bool AllDayStressCapable { get; init; }

    [JsonPropertyName("anaerobicTrainingEffectCapable")]
    public bool AnaerobicTrainingEffectCapable { get; init; }

    [JsonPropertyName("atpWorkoutCapable")]
    public bool AtpWorkoutCapable { get; init; }

    [JsonPropertyName("bodyBatteryCapable")]
    public bool BodyBatteryCapable { get; init; }

    [JsonPropertyName("brickWorkoutCapable")]
    public bool BrickWorkoutCapable { get; init; }

    [JsonPropertyName("cardioCapable")]
    public bool CardioCapable { get; init; }

    [JsonPropertyName("cardioOptionCapable")]
    public bool CardioOptionCapable { get; init; }

    [JsonPropertyName("cardioSportsCapable")]
    public bool CardioSportsCapable { get; init; }

    [JsonPropertyName("cardioWorkoutCapable")]
    public bool CardioWorkoutCapable { get; init; }

    [JsonPropertyName("cellularCapable")]
    public bool CellularCapable { get; init; }

    [JsonPropertyName("changeLogCapable")]
    public bool ChangeLogCapable { get; init; }

    [JsonPropertyName("contactManagementCapable")]
    public bool ContactManagementCapable { get; init; }

    [JsonPropertyName("courseCapable")]
    public bool CourseCapable { get; init; }

    [JsonPropertyName("courseFileType")]
    public string CourseFileType { get; init; }

    [JsonPropertyName("coursePromptCapable")]
    public bool CoursePromptCapable { get; init; }

    [JsonPropertyName("customIntensityMinutesCapable")]
    public bool CustomIntensityMinutesCapable { get; init; }

    [JsonPropertyName("customWorkoutCapable")]
    public bool CustomWorkoutCapable { get; init; }

    [JsonPropertyName("cyclingSegmentCapable")]
    public bool CyclingSegmentCapable { get; init; }

    [JsonPropertyName("cyclingSportsCapable")]
    public bool CyclingSportsCapable { get; init; }

    [JsonPropertyName("cyclingWorkoutCapable")]
    public bool CyclingWorkoutCapable { get; init; }

    [JsonPropertyName("defaultSettingCapable")]
    public bool DefaultSettingCapable { get; init; }

    [JsonPropertyName("deviceSettingCapable")]
    public bool DeviceSettingCapable { get; init; }

    [JsonPropertyName("deviceSettingFileType")]
    public object DeviceSettingFileType { get; init; }

    [JsonPropertyName("displayFieldsExtCapable")]
    public bool DisplayFieldsExtCapable { get; init; }

    [JsonPropertyName("divingCapable")]
    public bool DivingCapable { get; init; }

    [JsonPropertyName("ellipticalOptionCapable")]
    public bool EllipticalOptionCapable { get; init; }

    [JsonPropertyName("floorsClimbedGoalCapable")]
    public bool FloorsClimbedGoalCapable { get; init; }

    [JsonPropertyName("ftpCapable")]
    public bool FtpCapable { get; init; }

    [JsonPropertyName("gcj02CourseCapable")]
    public bool Gcj02CourseCapable { get; init; }

    [JsonPropertyName("glonassCapable")]
    public bool GlonassCapable { get; init; }

    [JsonPropertyName("goalCapable")]
    public bool GoalCapable { get; init; }

    [JsonPropertyName("goalFileType")]
    public string GoalFileType { get; init; }

    [JsonPropertyName("golfAppSyncCapable")]
    public bool GolfAppSyncCapable { get; init; }

    [JsonPropertyName("gpsRouteCapable")]
    public bool GpsRouteCapable { get; init; }

    [JsonPropertyName("handednessCapable")]
    public bool HandednessCapable { get; init; }

    [JsonPropertyName("hrZoneCapable")]
    public bool HrZoneCapable { get; init; }

    [JsonPropertyName("hrvStressCapable")]
    public bool HrvStressCapable { get; init; }

    [JsonPropertyName("intensityMinutesGoalCapable")]
    public bool IntensityMinutesGoalCapable { get; init; }

    [JsonPropertyName("lactateThresholdCapable")]
    public bool LactateThresholdCapable { get; init; }

    [JsonPropertyName("languageSettingCapable")]
    public bool LanguageSettingCapable { get; init; }

    [JsonPropertyName("languageSettingFileType")]
    public object LanguageSettingFileType { get; init; }

    [JsonPropertyName("lowHrAlertCapable")]
    public bool LowHrAlertCapable { get; init; }

    [JsonPropertyName("maxHRCapable")]
    public bool MaxHrCapable { get; init; }

    [JsonPropertyName("maxWorkoutCount")]
    public long MaxWorkoutCount { get; init; }

    [JsonPropertyName("metricsFitFileReceiveCapable")]
    public bool MetricsFitFileReceiveCapable { get; init; }

    [JsonPropertyName("metricsUploadCapable")]
    public bool MetricsUploadCapable { get; init; }

    [JsonPropertyName("militaryTimeCapable")]
    public bool MilitaryTimeCapable { get; init; }

    [JsonPropertyName("moderateIntensityMinutesGoalCapable")]
    public bool ModerateIntensityMinutesGoalCapable { get; init; }

    [JsonPropertyName("nfcCapable")]
    public bool NfcCapable { get; init; }

    [JsonPropertyName("otherOptionCapable")]
    public bool OtherOptionCapable { get; init; }

    [JsonPropertyName("otherSportsCapable")]
    public bool OtherSportsCapable { get; init; }

    [JsonPropertyName("personalRecordCapable")]
    public bool PersonalRecordCapable { get; init; }

    [JsonPropertyName("personalRecordFileType")]
    public string PersonalRecordFileType { get; init; }

    [JsonPropertyName("poolSwimOptionCapable")]
    public bool PoolSwimOptionCapable { get; init; }

    [JsonPropertyName("powerCurveCapable")]
    public bool PowerCurveCapable { get; init; }

    [JsonPropertyName("powerZonesCapable")]
    public bool PowerZonesCapable { get; init; }

    [JsonPropertyName("pulseOxAllDayCapable")]
    public bool PulseOxAllDayCapable { get; init; }

    [JsonPropertyName("pulseOxOnDemandCapable")]
    public bool PulseOxOnDemandCapable { get; init; }

    [JsonPropertyName("pulseOxSleepCapable")]
    public bool PulseOxSleepCapable { get; init; }

    [JsonPropertyName("remCapable")]
    public bool RemCapable { get; init; }

    [JsonPropertyName("reminderAlarmCapable")]
    public bool ReminderAlarmCapable { get; init; }

    [JsonPropertyName("reorderablePagesCapable")]
    public bool ReorderablePagesCapable { get; init; }

    [JsonPropertyName("restingHRCapable")]
    public bool RestingHrCapable { get; init; }

    [JsonPropertyName("rideOptionsCapable")]
    public bool RideOptionsCapable { get; init; }

    [JsonPropertyName("runOptionIndoorCapable")]
    public bool RunOptionIndoorCapable { get; init; }

    [JsonPropertyName("runOptionsCapable")]
    public bool RunOptionsCapable { get; init; }

    [JsonPropertyName("runningSegmentCapable")]
    public bool RunningSegmentCapable { get; init; }

    [JsonPropertyName("runningSportsCapable")]
    public bool RunningSportsCapable { get; init; }

    [JsonPropertyName("runningWorkoutCapable")]
    public bool RunningWorkoutCapable { get; init; }

    [JsonPropertyName("scheduleCapable")]
    public bool ScheduleCapable { get; init; }

    [JsonPropertyName("scheduleFileType")]
    public string ScheduleFileType { get; init; }

    [JsonPropertyName("segmentCapable")]
    public bool SegmentCapable { get; init; }

    [JsonPropertyName("segmentPointCapable")]
    public bool SegmentPointCapable { get; init; }

    [JsonPropertyName("settingCapable")]
    public bool SettingCapable { get; init; }

    [JsonPropertyName("settingFileType")]
    public string SettingFileType { get; init; }

    [JsonPropertyName("sleepTimeCapable")]
    public bool SleepTimeCapable { get; init; }

    [JsonPropertyName("smallFitFileOnlyCapable")]
    public bool SmallFitFileOnlyCapable { get; init; }

    [JsonPropertyName("sportCapable")]
    public bool SportCapable { get; init; }

    [JsonPropertyName("sportFileType")]
    public string SportFileType { get; init; }

    [JsonPropertyName("stairStepperOptionCapable")]
    public bool StairStepperOptionCapable { get; init; }

    [JsonPropertyName("strengthOptionsCapable")]
    public bool StrengthOptionsCapable { get; init; }

    [JsonPropertyName("strengthWorkoutCapable")]
    public bool StrengthWorkoutCapable { get; init; }

    [JsonPropertyName("supportedHrZones")]
    public string[] SupportedHrZones { get; init; }

    [JsonPropertyName("swimWorkoutCapable")]
    public bool SwimWorkoutCapable { get; init; }

    [JsonPropertyName("trainingPlanCapable")]
    public bool TrainingPlanCapable { get; init; }

    [JsonPropertyName("trainingStatusCapable")]
    public bool TrainingStatusCapable { get; init; }

    [JsonPropertyName("trainingStatusPauseCapable")]
    public bool TrainingStatusPauseCapable { get; init; }

    [JsonPropertyName("userProfileCapable")]
    public bool UserProfileCapable { get; init; }

    [JsonPropertyName("userProfileFileType")]
    public object UserProfileFileType { get; init; }

    [JsonPropertyName("userTcxExportCapable")]
    public bool UserTcxExportCapable { get; init; }

    [JsonPropertyName("vo2MaxBikeCapable")]
    public bool Vo2MaxBikeCapable { get; init; }

    [JsonPropertyName("vo2MaxRunCapable")]
    public bool Vo2MaxRunCapable { get; init; }

    [JsonPropertyName("walkOptionCapable")]
    public bool WalkOptionCapable { get; init; }

    [JsonPropertyName("walkingSportsCapable")]
    public bool WalkingSportsCapable { get; init; }

    [JsonPropertyName("weatherAlertsCapable")]
    public bool WeatherAlertsCapable { get; init; }

    [JsonPropertyName("weatherSettingsCapable")]
    public bool WeatherSettingsCapable { get; init; }

    [JsonPropertyName("workoutCapable")]
    public bool WorkoutCapable { get; init; }

    [JsonPropertyName("workoutFileType")]
    public string WorkoutFileType { get; init; }

    [JsonPropertyName("yogaCapable")]
    public bool YogaCapable { get; init; }

    [JsonPropertyName("yogaOptionCapable")]
    public bool YogaOptionCapable { get; init; }

    [JsonPropertyName("heatAndAltitudeAcclimationCapable")]
    public bool HeatAndAltitudeAcclimationCapable { get; init; }

    [JsonPropertyName("trainingLoadBalanceCapable")]
    public bool TrainingLoadBalanceCapable { get; init; }

    [JsonPropertyName("indoorTrackOptionsCapable")]
    public bool IndoorTrackOptionsCapable { get; init; }

    [JsonPropertyName("indoorBikeOptionsCapable")]
    public bool IndoorBikeOptionsCapable { get; init; }

    [JsonPropertyName("indoorWalkOptionsCapable")]
    public bool IndoorWalkOptionsCapable { get; init; }

    [JsonPropertyName("trainingEffectLabelCapable")]
    public bool TrainingEffectLabelCapable { get; init; }

    [JsonPropertyName("pacebandCapable")]
    public bool PacebandCapable { get; init; }

    [JsonPropertyName("respirationCapable")]
    public bool RespirationCapable { get; init; }

    [JsonPropertyName("openWaterSwimOptionCapable")]
    public bool OpenWaterSwimOptionCapable { get; init; }

    [JsonPropertyName("phoneVerificationCheckRequired")]
    public bool PhoneVerificationCheckRequired { get; init; }

    [JsonPropertyName("weightGoalCapable")]
    public bool WeightGoalCapable { get; init; }

    [JsonPropertyName("yogaWorkoutCapable")]
    public bool YogaWorkoutCapable { get; init; }

    [JsonPropertyName("pilatesWorkoutCapable")]
    public bool PilatesWorkoutCapable { get; init; }

    [JsonPropertyName("connectedGPSCapable")]
    public bool ConnectedGpsCapable { get; init; }

    [JsonPropertyName("diveAppSyncCapable")]
    public bool DiveAppSyncCapable { get; init; }

    [JsonPropertyName("golfLiveScoringCapable")]
    public bool GolfLiveScoringCapable { get; init; }

    [JsonPropertyName("bloodEfficiencySleepCapable")]
    public bool BloodEfficiencySleepCapable { get; init; }

    [JsonPropertyName("bloodEfficiencyAllDayCapable")]
    public bool BloodEfficiencyAllDayCapable { get; init; }

    [JsonPropertyName("bloodEfficiencyOnDemandCapable")]
    public bool BloodEfficiencyOnDemandCapable { get; init; }

    [JsonPropertyName("solarPanelUtilizationCapable")]
    public bool SolarPanelUtilizationCapable { get; init; }

    [JsonPropertyName("sweatLossCapable")]
    public bool SweatLossCapable { get; init; }

    [JsonPropertyName("diveAlertCapable")]
    public bool DiveAlertCapable { get; init; }

    [JsonPropertyName("requiresInitialDeviceNickname")]
    public bool RequiresInitialDeviceNickname { get; init; }

    [JsonPropertyName("defaultSettingsHbaseMigrated")]
    public bool DefaultSettingsHbaseMigrated { get; init; }

    [JsonPropertyName("sleepScoreCapable")]
    public bool SleepScoreCapable { get; init; }

    [JsonPropertyName("fitnessAgeV2Capable")]
    public bool FitnessAgeV2Capable { get; init; }

    [JsonPropertyName("intensityMinutesV2Capable")]
    public bool IntensityMinutesV2Capable { get; init; }

    [JsonPropertyName("collapsibleControlMenuCapable")]
    public bool CollapsibleControlMenuCapable { get; init; }

    [JsonPropertyName("measurementUnitSettingCapable")]
    public bool MeasurementUnitSettingCapable { get; init; }

    [JsonPropertyName("onDeviceSleepCalculationCapable")]
    public bool OnDeviceSleepCalculationCapable { get; init; }

    [JsonPropertyName("hiitWorkoutCapable")]
    public bool HiitWorkoutCapable { get; init; }

    [JsonPropertyName("runningHeartRateZoneCapable")]
    public bool RunningHeartRateZoneCapable { get; init; }

    [JsonPropertyName("cyclingHeartRateZoneCapable")]
    public bool CyclingHeartRateZoneCapable { get; init; }

    [JsonPropertyName("swimmingHeartRateZoneCapable")]
    public bool SwimmingHeartRateZoneCapable { get; init; }

    [JsonPropertyName("defaultHeartRateZoneCapable")]
    public bool DefaultHeartRateZoneCapable { get; init; }

    [JsonPropertyName("cyclingPowerZonesCapable")]
    public bool CyclingPowerZonesCapable { get; init; }

    [JsonPropertyName("xcSkiPowerZonesCapable")]
    public bool XcSkiPowerZonesCapable { get; init; }

    [JsonPropertyName("swimAlgorithmCapable")]
    public bool SwimAlgorithmCapable { get; init; }

    [JsonPropertyName("benchmarkExerciseCapable")]
    public bool BenchmarkExerciseCapable { get; init; }

    [JsonPropertyName("spectatorMessagingCapable")]
    public bool SpectatorMessagingCapable { get; init; }

    [JsonPropertyName("ecgCapable")]
    public bool EcgCapable { get; init; }

    [JsonPropertyName("lteLiveEventSharingCapable")]
    public bool LteLiveEventSharingCapable { get; init; }

    [JsonPropertyName("sleepFitFileReceiveCapable")]
    public bool SleepFitFileReceiveCapable { get; init; }

    [JsonPropertyName("secondaryWorkoutStepTargetCapable")]
    public bool SecondaryWorkoutStepTargetCapable { get; init; }

    [JsonPropertyName("assistancePlusCapable")]
    public bool AssistancePlusCapable { get; init; }

    [JsonPropertyName("powerGuidanceCapable")]
    public bool PowerGuidanceCapable { get; init; }

    [JsonPropertyName("airIntegrationCapable")]
    public bool AirIntegrationCapable { get; init; }

    [JsonPropertyName("healthSnapshotCapable")]
    public bool HealthSnapshotCapable { get; init; }

    [JsonPropertyName("racePredictionsRunCapable")]
    public bool RacePredictionsRunCapable { get; init; }

    [JsonPropertyName("vivohubCompatible")]
    public bool VivohubCompatible { get; init; }

    [JsonPropertyName("stepsTrueUpChartCapable")]
    public bool StepsTrueUpChartCapable { get; init; }

    [JsonPropertyName("sportingEventCapable")]
    public bool SportingEventCapable { get; init; }

    [JsonPropertyName("solarChargeCapable")]
    public bool SolarChargeCapable { get; init; }

    [JsonPropertyName("realTimeSettingsCapable")]
    public bool RealTimeSettingsCapable { get; init; }

    [JsonPropertyName("emergencyCallingCapable")]
    public bool EmergencyCallingCapable { get; init; }

    [JsonPropertyName("personalRepRecordCapable")]
    public bool PersonalRepRecordCapable { get; init; }

    [JsonPropertyName("hrvStatusCapable")]
    public bool HrvStatusCapable { get; init; }

    [JsonPropertyName("trainingReadinessCapable")]
    public bool TrainingReadinessCapable { get; init; }

    [JsonPropertyName("publicBetaSoftwareCapable")]
    public bool PublicBetaSoftwareCapable { get; init; }

    [JsonPropertyName("workoutAudioPromptsCapable")]
    public bool WorkoutAudioPromptsCapable { get; init; }

    [JsonPropertyName("actualStepRecordingCapable")]
    public bool ActualStepRecordingCapable { get; init; }

    [JsonPropertyName("groupTrack2Capable")]
    public bool GroupTrack2Capable { get; init; }

    [JsonPropertyName("golfAppPairingCapable")]
    public bool GolfAppPairingCapable { get; init; }

    [JsonPropertyName("localWindConditionsCapable")]
    public bool LocalWindConditionsCapable { get; init; }

    [JsonPropertyName("multipleGolfCourseCapable")]
    public bool MultipleGolfCourseCapable { get; init; }

    [JsonPropertyName("beaconTrackingCapable")]
    public bool BeaconTrackingCapable { get; init; }

    [JsonPropertyName("batteryStatusCapable")]
    public bool BatteryStatusCapable { get; init; }

    [JsonPropertyName("datasource")]
    public string Datasource { get; init; }

    [JsonPropertyName("deviceStatus")]
    public string DeviceStatus { get; init; }

    [JsonPropertyName("registeredDate")]
    public long RegisteredDate { get; init; }

    [JsonPropertyName("actualProductSku")]
    public string ActualProductSku { get; init; }

    [JsonPropertyName("vivohubConfigurable")]
    public object VivohubConfigurable { get; init; }

    [JsonPropertyName("serialNumber")]
    public string SerialNumber { get; init; }

    [JsonPropertyName("shortName")]
    public object ShortName { get; init; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    [JsonPropertyName("unitId")]
    public long UnitId { get; init; }

    [JsonPropertyName("deviceId")]
    public long DeviceId { get; init; }

    [JsonPropertyName("wifiSetup")]
    public bool WifiSetup { get; init; }

    [JsonPropertyName("currentFirmwareVersionMajor")]
    public long CurrentFirmwareVersionMajor { get; init; }

    [JsonPropertyName("currentFirmwareVersionMinor")]
    public long CurrentFirmwareVersionMinor { get; init; }

    [JsonPropertyName("activeInd")]
    public long ActiveInd { get; init; }

    [JsonPropertyName("primaryActivityTrackerIndicator")]
    public bool PrimaryActivityTrackerIndicator { get; init; }

    [JsonPropertyName("currentFirmwareVersion")]
    public string CurrentFirmwareVersion { get; init; }

    [JsonPropertyName("isPrimaryUser")]
    public bool IsPrimaryUser { get; init; }

    [JsonPropertyName("corporateDevice")]
    public bool CorporateDevice { get; init; }

    [JsonPropertyName("prePairedWithHRM")]
    public bool PrePairedWithHrm { get; init; }

    [JsonPropertyName("unRetirable")]
    public bool UnRetirable { get; init; }

    [JsonPropertyName("otherAssociation")]
    public bool OtherAssociation { get; init; }

    [JsonPropertyName("minCustomIntensityMinutesVersion")]
    public string MinCustomIntensityMinutesVersion { get; init; }
}