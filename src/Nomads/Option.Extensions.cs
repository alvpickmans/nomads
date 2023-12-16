namespace Nomads;

public static partial class Option
{
    /// <summary>
    /// Returns the value of an <see cref="Option{T}"/> if it
    /// has a value, or execute the fallback delegate
    /// </summary>
    /// <param name="option">Option</param>
    /// <param name="fallback"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Reduce<T>(this Option<T> option, Func<T> fallback) 
        where T : notnull =>
        option is Some<T> some
            ? some.Value
            : fallback();

    /// <summary>
    /// Returns the value of an <see cref="Option{T}"/> if it
    /// has a value, or the fallback value defined
    /// </summary>
    /// <param name="option">Option</param>
    /// <param name="fallback"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Reduce<T>(this Option<T> option, T fallback) 
        where T : notnull =>
        option.Reduce(() => fallback);

    /// <summary>
    /// Applies a mapping function to a <see cref="Option{T}"/>
    /// </summary>
    /// <param name="option">Option</param>
    /// <param name="selector">Mapping function</param>
    /// <typeparam name="T">Source type</typeparam>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <returns>An <see cref="Option{T}"/> with its value type mapped</returns>
    public static Option<TOut> Map<T, TOut>(this Option<T> option, Func<T, TOut> selector)
        where T : notnull
        where TOut : notnull =>
        option is Some<T> some
            ? selector.Invoke(some.Value)
            : None();

    /// <summary>
    /// Applies a mapping function to a <see cref="Option{T}"/>
    /// </summary>
    /// <param name="option">Input option</param>
    /// <param name="selector">Mapping function</param>
    /// <typeparam name="TIn">Source type</typeparam>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <returns>An <see cref="Option{T}"/> with its value type mapped</returns>
    public static Option<TOut> MapOptional<TIn, TOut>(
        this Option<TIn> option,
        Func<TIn, Option<TOut>> selector)
        where TIn : notnull
        where TOut : notnull =>
        option
            .Map(selector)
            .Reduce(None());
}