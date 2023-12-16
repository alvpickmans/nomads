namespace Nomads;

public static partial class Option
{
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
}