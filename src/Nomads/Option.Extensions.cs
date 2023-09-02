using Nomads.Primitives;

namespace Nomads;

/// <summary>
/// Extension methods for <see cref="Option{T}"/>
/// </summary>
public static class Option
{
    /// <summary>
    /// Creates a new instance of <see cref="Option{T}"/> with a value
    /// </summary>
    /// <param name="value">Option's value</param>
    /// <typeparam name="T">Type of value</typeparam>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Option<string> stringOption = Some("Hello");
    /// Option<bool> booleanOption = Some(true);
    /// ]]>
    /// </code>
    /// </example>
    /// <returns></returns>
    public static Option<T> Some<T>(T value) where T : notnull => value;

    /// <summary>
    /// Creates a new instance of <see cref="None"/>, generally used to convert it to
    /// an empty <see cref="Option{T}"/>
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Option<string> stringOption = None();
    /// Option<bool> booleanOption = None();
    /// ]]>
    /// </code>
    /// </example>
    /// <returns></returns>
    public static None None() => new();
    
    /// <summary>
    /// Overload of <see cref="Option{T}.HasValue"/> that does not return the
    /// value of <see cref="T"/> in case of non-empty Option.
    /// </summary>
    /// <param name="option">Option</param>
    /// <typeparam name="T">Type of option value</typeparam>
    /// <returns></returns>
    public static bool HasValue<T>(this Option<T> option) where T : notnull => option.HasValue(out _);
}