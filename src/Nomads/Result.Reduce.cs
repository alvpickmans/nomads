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
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TErr"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    /// <returns></returns>
    public static TOut Reduce<T, TErr, TOut>(
        this Result<T, TErr> result,
        Func<T, TOut> okDelegate,
        Func<TErr, TOut> errorDelegate)
        where T : notnull
        where TErr : notnull =>
        result switch
        {
            Ok<T, TErr> ok => okDelegate.Invoke(ok.Value),
            Error<T, TErr> err => errorDelegate.Invoke(err.Value),
            _ => throw new ArgumentException($"Unrecognised Result type '{result.GetType()}'")
        };

}