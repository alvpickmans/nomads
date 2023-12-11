using static Nomads.Option;

namespace Nomads.Linq;

/// <summary>
/// Linq-like extension methods for <see cref="Option{T}"/>
/// </summary>
public static class Option
{
    /// <summary>
    /// Applies a mapping function to a <see cref="Option{T}"/>
    /// </summary>
    /// <param name="option">Input option</param>
    /// <param name="selector">Mapping function</param>
    /// <typeparam name="TIn">Source type</typeparam>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <returns>An <see cref="Option{T}"/> with its value type mapped</returns>
    public static Option<TOut> Apply<TIn, TOut>(
        this Option<TIn> option,
        Func<TIn, TOut> selector)
        where TIn : notnull
        where TOut : notnull =>
        option.HasValue
            ? selector.Invoke(option.Value!)
            : None();
    
    /// <summary>
    /// Applies a mapping function to a <see cref="Option{T}"/>
    /// </summary>
    /// <param name="option">Input option</param>
    /// <param name="selector">Mapping function</param>
    /// <typeparam name="TIn">Source type</typeparam>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <returns>An <see cref="Option{T}"/> with its value type mapped</returns>
    public static Option<TOut> Apply<TIn, TOut>(
        this Option<TIn> option,
        Func<TIn, Option<TOut>> selector)
        where TIn : notnull
        where TOut : notnull =>
        option.HasValue
            ? selector.Invoke(option.Value!)
            : None();
}