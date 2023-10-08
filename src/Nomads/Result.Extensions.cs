namespace Nomads;

public static partial class Result
{
    /// <summary>
    /// Method that runs a delegate on eiter Value or Error case,
    /// allowing to materialise a resulting value from a <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <param name="result"></param>
    /// <param name="okDelegate"></param>
    /// <param name="errorDelegate"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TError"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    /// <returns></returns>
    public static TOut Match<TValue, TError, TOut>(
        this Result<TValue, TError> result,
        Func<TValue, TOut> okDelegate,
        Func<TError, TOut> errorDelegate)
        where TValue : notnull
        where TError : notnull =>
        result.HasValue
            ? okDelegate.Invoke(result.Value!)
            : errorDelegate.Invoke(result.Error!);
}