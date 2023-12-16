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

    /// <summary>
    /// Applies a mapping function to a <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <param name="result"></param>
    /// <param name="selector">Mapping function</param>
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
    
    /// <summary>
    /// Applies a mapping function to a <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <param name="result">Input result</param>
    /// <param name="selector">Mapping function</param>
    /// <typeparam name="TIn">Source type</typeparam>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <typeparam name="TError">Error type</typeparam>
    /// <returns>A <see cref="Result{TValue,TError}"/> with its value type mapped</returns>
    public static Result<TOut, TError> MapResult<TIn, TOut, TError>(
        this Result<TIn, TError> result,
        Func<TIn, Result<TOut, TError>> selector)
        where TIn : notnull
        where TOut : notnull
        where TError : notnull =>
        result
            .Map(selector.Invoke)
            .Reduce(
                ok => ok,
                err => err);

    
}