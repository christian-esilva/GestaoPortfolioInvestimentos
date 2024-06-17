namespace Xp.GestaoPortfolioInvestimentos.Shared.Common;

public struct ValidationResult<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public IReadOnlyCollection<string> Errors { get; }

    private ValidationResult(bool success, T? value, string[]? errors)
    {
        IsSuccess = success;
        Value = value;
        Errors = (IReadOnlyCollection<string>)(object)(errors ?? Enumerable.Empty<string>());
    }

    public static ValidationResult<T> Success(T? value = default)
    {
        return Create(true, value);
    }

    public static ValidationResult<T> Failure()
    {
        return Create(false, default);
    }

    public static ValidationResult<T> Failure(IEnumerable<string>? errors)
    {
        string[] errors1 = errors?.ToArray();
        return Create(succeeded: false, default, errors1);
    }

    public static ValidationResult<T> Create(bool succeeded = true, T? value = default, params string[]? errors)
    {
        return new ValidationResult<T>(succeeded, value, errors?.ToArray());
    }

    public static ValidationResult<T> Failure(params string[] errors)
    {
        return Failure(errors?.Select((string error) => error));
    }
}
