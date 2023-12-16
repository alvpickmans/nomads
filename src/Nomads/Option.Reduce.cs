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

}