namespace Upnext.Domain.Shared;

/// <summary>
///     Represents the result of some operation, with status information and possibly a value and an error.
/// </summary>
/// <typeparam name="TValue">The result value type.</typeparam>
public class Result<TValue> : Result
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Result{TValueType}" /> class with the specified parameters.
    /// </summary>
    /// <param name="value">The result value.</param>
    /// <param name="isSuccess">The flag indicating if the result is successful.</param>
    /// <param name="error">The error.</param>
    protected internal Result(TValue value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    /// <summary>
    ///     Gets the result value if the result is successful, otherwise throws an exception.
    /// </summary>
    /// <returns>The result value if the result is successful.</returns>
    /// <exception cref="InvalidOperationException"> when <see cref="Result.IsFailure" /> is true.</exception>
    public TValue Value => IsSuccess
        ? field
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public static implicit operator Result<TValue>(TValue value)
    {
        return Success(value);
    }

    public TResult Match<TResult>(Func<TValue, TResult> onValue, Func<Error, TResult> onFailure)
    {
        return IsFailure ? onFailure(Error) : onValue(Value);
    }

    public Result<TResult> MapSuccess<TResult>(Func<TValue, TResult> transform)
    {
        if (IsSuccess) return transform(Value);

        return new Result<TResult>(default!, false, Error);
    }

    public TValue GetOrDefault(Func<TValue> defaultValue)
    {
        return IsSuccess ? Value : defaultValue();
    }

    public TValue? GetOrNull()
    {
        return IsSuccess ? Value : default;
    }
}