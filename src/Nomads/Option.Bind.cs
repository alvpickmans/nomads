namespace Nomads;

public static partial class Option
{
    /// <summary>
    /// Elevates a function returning <see cref="Option{TOut}"/>
    /// to accept an option of its input type
    /// </summary>
    /// <param name="option">Input option</param>
    /// <param name="func">Function</param>
    /// <typeparam name="TIn">Source type</typeparam>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <returns>An <see cref="Option{T}"/> with its value type mapped</returns>
    public static Option<TOut> Bind<TIn, TOut>(
        this Option<TIn> option,
        Func<TIn, Option<TOut>> func)
        where TIn : notnull
        where TOut : notnull =>
        option is Some<TIn> some
            ? func.Invoke(some.Value)
            : None();

    /// <summary>
    /// Elevates a function returning <see cref="Option{TOut}"/>
    /// to accept an option of its input type
    /// </summary>
    /// <param name="func">Mapping function</param>
    /// <typeparam name="TIn">Source type</typeparam>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <returns>An elevated function accepting an option as input</returns>
    public static Func<Option<TIn>, Option<TOut>> Bind<TIn, TOut>(
        this Func<TIn, Option<TOut>> func)
        where TIn : notnull
        where TOut : notnull =>
        x => x is Some<TIn> some
            ? func.Invoke(some.Value)
            : None();
}