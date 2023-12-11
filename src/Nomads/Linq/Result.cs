using static Nomads.Result;

namespace Nomads.Linq;

/// <summary>
/// Linq-like extension methods for <see cref="Result{TValue,TError}"/>
/// </summary>
public static class Result
{
    /// <summary>
    /// Applies a mapping function to a <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <param name="result">Input result</param>
    /// <param name="selector">Mapping function</param>
    /// <typeparam name="TIn">Source type</typeparam>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <typeparam name="TError">Error type</typeparam>
    /// <returns>A <see cref="Result{TValue,TError}"/> with its value type mapped</returns>
    public static Result<TOut, TError> Apply<TIn, TOut, TError>(
        this Result<TIn, TError> result,
        Func<TIn, TOut> selector)
        where TIn : notnull
        where TOut : notnull
        where TError : notnull =>
        result.HasValue
            ? Ok(selector.Invoke(result.Value!))
            : Error(result.Error!);
    
    /// <summary>
    /// Applies a mapping function to a <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <param name="result">Input result</param>
    /// <param name="selector">Mapping function</param>
    /// <typeparam name="TIn">Source type</typeparam>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <typeparam name="TError">Error type</typeparam>
    /// <returns>A <see cref="Result{TValue,TError}"/> with its value type mapped</returns>
    public static Result<TOut, TError> Apply<TIn, TOut, TError>(
        this Result<TIn, TError> result,
        Func<TIn, Result<TOut, TError>> selector)
        where TIn : notnull
        where TOut : notnull
        where TError : notnull =>
        result.HasValue
            ? selector.Invoke(result.Value!)
            : Error(result.Error!);
}