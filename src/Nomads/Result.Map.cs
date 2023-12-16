namespace Nomads;

public static partial class Result
{
    /// <summary>
    /// Applies a mapping function to a <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <param name="result"></param>
    /// <param name="selector">Mapping function</param>
    /// <typeparam name="T">Ok value type</typeparam>
    /// <typeparam name="TErr">Error value type</typeparam>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <returns>A <see cref="Result{TValue,TError}"/> with its value type mapped</returns>
    public static Result<TOut, TErr> Map<T, TErr, TOut>(
        this Result<T, TErr> result,
        Func<T, TOut> selector)
        where T : notnull 
        where TErr : notnull
        where TOut : notnull =>
        result switch
        {
            Ok<T, TErr> ok => selector.Invoke(ok.Value),
            Error<T, TErr> err => Error(err.Value),
            _ => throw new ArgumentException($"Unrecognised Result type '{result.GetType()}'")
        };
}