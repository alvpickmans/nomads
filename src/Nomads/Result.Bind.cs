namespace Nomads;

public static partial class Result
{
    /// <summary>
    /// Elevates a function returning <see cref="Result{TOut, TErr}"/>
    /// to accept a result of its input type
    /// </summary>
    /// <param name="result">Input result</param>
    /// <param name="func">Function</param>
    /// <typeparam name="TIn">Source type</typeparam>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <typeparam name="TErr">Error type</typeparam>
    /// <returns>A <see cref="Result{TValue,TError}"/> with its value type mapped</returns>
    public static Result<TOut, TErr> Bind<TIn, TOut, TErr>(
        this Result<TIn, TErr> result,
        Func<TIn, Result<TOut, TErr>> func)
        where TIn : notnull
        where TOut : notnull
        where TErr : notnull =>
        result.Reduce(func.Invoke, err => err);

    /// <summary>
    /// Elevates a function returning <see cref="Result{TOut, TErr}"/>
    /// to accept a result of its input type
    /// </summary>
    /// <param name="func">Function</param>
    /// <typeparam name="TIn">Source type</typeparam>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <typeparam name="TErr">Error type</typeparam>
    /// <returns>A <see cref="Result{TValue,TError}"/> with its value type mapped</returns>
    public static Func<Result<TIn, TErr>, Result<TOut, TErr>> Bind<TIn, TOut, TErr>(
        this Func<TIn, Result<TOut, TErr>> func)
        where TIn : notnull
        where TOut : notnull
        where TErr : notnull =>
        x => x.Reduce(func.Invoke, err => err);

}