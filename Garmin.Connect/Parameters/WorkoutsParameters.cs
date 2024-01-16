namespace Garmin.Connect.Parameters;

public record WorkoutsParameters
{
    public uint Start { get; init; } = 1;
    public uint Limit { get; init; } = 50;
    public WorkoutsOrderBy OrderBy { get; init; } = WorkoutsOrderBy.CREATED_DATE;
    public OrderSeq OrderSeq { get; init; } = OrderSeq.DESC;
    public bool IncludeAtp { get; init; } = true;
    public bool MyWorkoutsOnly { get; init; } = true;
    public bool SharedWorkoutsOnly { get; init; } = false;

    internal string ToQueryParams() => $"start={Start}&limit={Limit}&orderBy={OrderBy}&orderSeq={OrderSeq}&includeAtp={IncludeAtp}&myWorkoutsOnly={MyWorkoutsOnly}&sharedWorkoutsOnly={SharedWorkoutsOnly}";
}

public enum WorkoutsOrderBy
{
    WORKOUT_NAME,
    UPDATE_DATE,
    CREATED_DATE,
    WORKOUT_SPORT_PK,
}

public enum OrderSeq
{
    ASC,
    DESC,
}