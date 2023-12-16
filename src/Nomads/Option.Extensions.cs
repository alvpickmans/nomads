namespace Nomads;

public static partial class Option
{
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