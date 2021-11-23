using System;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Models;

public record GarminSocialProfile
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("profileId")]
    public long ProfileId { get; init; }

    [JsonPropertyName("garminGUID")]
    public string GarminGuid { get; init; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    [JsonPropertyName("fullName")]
    public string FullName { get; init; }

    [JsonPropertyName("userName")]
    public string UserName { get; init; }

    [JsonPropertyName("profileImageUrlLarge")]
    public string ProfileImageUrlLarge { get; init; }

    [JsonPropertyName("profileImageUrlMedium")]
    public string ProfileImageUrlMedium { get; init; }

    [JsonPropertyName("profileImageUrlSmall")]
    public string ProfileImageUrlSmall { get; init; }

    [JsonPropertyName("location")]
    public string Location { get; init; }

    [JsonPropertyName("facebookUrl")]
    public string FacebookUrl { get; init; }

    [JsonPropertyName("twitterUrl")]
    public string TwitterUrl { get; init; }

    [JsonPropertyName("personalWebsite")]
    public string PersonalWebsite { get; init; }

    [JsonPropertyName("motivation")]
    public long Motivation { get; init; }

    [JsonPropertyName("bio")]
    public object Bio { get; init; }

    [JsonPropertyName("primaryActivity")]
    public string PrimaryActivity { get; init; }

    [JsonPropertyName("favoriteActivityTypes")]
    public string[] FavoriteActivityTypes { get; init; }

    [JsonPropertyName("runningTrainingSpeed")]
    public double RunningTrainingSpeed { get; init; }

    [JsonPropertyName("cyclingTrainingSpeed")]
    public double CyclingTrainingSpeed { get; init; }

    [JsonPropertyName("favoriteCyclingActivityTypes")]
    public object[] FavoriteCyclingActivityTypes { get; init; }

    [JsonPropertyName("cyclingClassification")]
    public object CyclingClassification { get; init; }

    [JsonPropertyName("cyclingMaxAvgPower")]
    public double CyclingMaxAvgPower { get; init; }

    [JsonPropertyName("swimmingTrainingSpeed")]
    public double SwimmingTrainingSpeed { get; init; }

    [JsonPropertyName("profileVisibility")]
    public string ProfileVisibility { get; init; }

    [JsonPropertyName("activityStartVisibility")]
    public string ActivityStartVisibility { get; init; }

    [JsonPropertyName("activityMapVisibility")]
    public string ActivityMapVisibility { get; init; }

    [JsonPropertyName("courseVisibility")]
    public string CourseVisibility { get; init; }

    [JsonPropertyName("activityHeartRateVisibility")]
    public string ActivityHeartRateVisibility { get; init; }

    [JsonPropertyName("activityPowerVisibility")]
    public string ActivityPowerVisibility { get; init; }

    [JsonPropertyName("badgeVisibility")]
    public string BadgeVisibility { get; init; }

    [JsonPropertyName("showAge")]
    public bool ShowAge { get; init; }

    [JsonPropertyName("showWeight")]
    public bool ShowWeight { get; init; }

    [JsonPropertyName("showHeight")]
    public bool ShowHeight { get; init; }

    [JsonPropertyName("showWeightClass")]
    public bool ShowWeightClass { get; init; }

    [JsonPropertyName("showAgeRange")]
    public bool ShowAgeRange { get; init; }

    [JsonPropertyName("showGender")]
    public bool ShowGender { get; init; }

    [JsonPropertyName("showActivityClass")]
    public bool ShowActivityClass { get; init; }

    [JsonPropertyName("showVO2Max")]
    public bool ShowVo2Max { get; init; }

    [JsonPropertyName("showPersonalRecords")]
    public bool ShowPersonalRecords { get; init; }

    [JsonPropertyName("showLast12Months")]
    public bool ShowLast12Months { get; init; }

    [JsonPropertyName("showLifetimeTotals")]
    public bool ShowLifetimeTotals { get; init; }

    [JsonPropertyName("showUpcomingEvents")]
    public bool ShowUpcomingEvents { get; init; }

    [JsonPropertyName("showRecentFavorites")]
    public bool ShowRecentFavorites { get; init; }

    [JsonPropertyName("showRecentDevice")]
    public bool ShowRecentDevice { get; init; }

    [JsonPropertyName("showRecentGear")]
    public bool ShowRecentGear { get; init; }

    [JsonPropertyName("showBadges")]
    public bool ShowBadges { get; init; }

    [JsonPropertyName("otherActivity")]
    public string OtherActivity { get; init; }

    [JsonPropertyName("otherPrimaryActivity")]
    public object OtherPrimaryActivity { get; init; }

    [JsonPropertyName("otherMotivation")]
    public object OtherMotivation { get; init; }

    [JsonPropertyName("userRoles")]
    public string[] UserRoles { get; init; }

    [JsonPropertyName("nameApproved")]
    public bool NameApproved { get; init; }

    [JsonPropertyName("userProfileFullName")]
    public string UserProfileFullName { get; init; }

    [JsonPropertyName("makeGolfScorecardsPrivate")]
    public bool MakeGolfScorecardsPrivate { get; init; }

    [JsonPropertyName("allowGolfLiveScoring")]
    public bool AllowGolfLiveScoring { get; init; }

    [JsonPropertyName("allowGolfScoringByConnections")]
    public bool AllowGolfScoringByConnections { get; init; }

    [JsonPropertyName("userLevel")]
    public long UserLevel { get; init; }

    [JsonPropertyName("userPoint")]
    public long UserPoint { get; init; }

    [JsonPropertyName("levelUpdateDate")]
    public DateTime LevelUpdateDate { get; init; }

    [JsonPropertyName("levelIsViewed")]
    public bool LevelIsViewed { get; init; }

    [JsonPropertyName("levelPointThreshold")]
    public long LevelPointThreshold { get; init; }

    [JsonPropertyName("userPointOffset")]
    public long UserPointOffset { get; init; }

    [JsonPropertyName("userPro")]
    public bool UserPro { get; init; }
}