namespace Xp.GestaoPortfolioInvestimentos.Shared.Common;

public readonly struct ValueResult
{
    public bool Succeeded { get; }
    public IReadOnlyCollection<ValueFailureDetail> FailureDetails { get; }

    private ValueResult(bool succeeded, ValueFailureDetail[]? failureDetails)
    {
        Succeeded = succeeded;
        FailureDetails = (IReadOnlyCollection<ValueFailureDetail>)(object)(failureDetails 
            ?? Enumerable.Empty<ValueFailureDetail>());
    }

    public static ValueResult Success()
    {
        return new ValueResult(succeeded: true, null);
    }

    public static ValueResult Failure(IEnumerable<ValueFailureDetail>? failureDetails)
    {
        return new ValueResult(succeeded: false, failureDetails?.ToArray());
    }

    public static ValueResult Failure(params string[] descriptions)
    {
        return Failure(descriptions?.Select((string description) => new ValueFailureDetail(description)));
    }
}

public readonly struct ValueResult<TResultValue>
{
    public bool Succeeded { get; }
    public TResultValue? Value { get; }
    public IReadOnlyCollection<ValueFailureDetail> FailureDetails { get; }

    private ValueResult(bool succeeded, TResultValue? value, ValueFailureDetail[]? failureDetails)
    {
        Succeeded = succeeded;
        Value = value;
        FailureDetails = (IReadOnlyCollection<ValueFailureDetail>)(object)(failureDetails
            ?? Enumerable.Empty<ValueFailureDetail>());
    }

    public static ValueResult<TResultValue> Success(TResultValue? value = default(TResultValue?)) 
    {
        return Create(true, value);
    }

    public static ValueResult<TResultValue> Failure()
    {
        return Create(false, default);
    }

    public static ValueResult<TResultValue> Failure(IEnumerable<ValueFailureDetail>? failureDetails)
    {
        ValueFailureDetail[] failureDetails1 = failureDetails?.ToArray();
        return Create(succeeded: false, default, failureDetails1);
    }

    public static ValueResult<TResultValue> Create(bool succeeded = true, TResultValue? value = default, params ValueFailureDetail[]? failureDetails)
    {
        return new ValueResult<TResultValue>(succeeded, value, failureDetails?.ToArray());
    }
}
