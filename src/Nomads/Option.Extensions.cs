namespace Nomads;

public static partial class Option
{

    /// <summary>
    /// Returns the value of an <see cref="Option{T}"/> if it
    /// has a value, or the fallback value defined
    /// </summary>
    /// <param name="option"></param>
    /// <param name="fallback"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T ValueOrElse<T>(this Option<T> option, T fallback) where T : notnull =>
        option.HasValue ? option.Value! : fallback;

}