namespace Nomads;

/// <summary>
/// Extension methods for <see cref="Option{T}"/>
/// </summary>
public static partial class Option
{
    /// <summary>
    /// Creates a new instance of <see cref="Option{T}"/> with a value
    /// </summary>
    /// <param name="value">Option's value</param>
    /// <typeparam name="T">Type of value</typeparam>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Option<string> stringOption = Option.Some("Hello");
    /// Option<bool> booleanOption = Option.Some(true);
    /// ]]>
    /// </code>
    /// </example>
    /// <returns></returns>
    public static Option<T> Some<T>(T value) where T : notnull => value;

    /// <summary>
    /// Creates an empty instance of <see cref="Option{T}"/>
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Option<string> stringOption = Option.None<string>();
    /// Option<bool> booleanOption = Option.None<string>();
    /// ]]>
    /// </code>
    /// </example>
    /// <returns></returns>
    public static Option<T> None<T>() where T : notnull => None();
    
    /// <summary>
    /// Creates a new instance of <see cref="None"/>, generally used to convert it to
    /// an empty <see cref="Option{T}"/>
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Option<string> stringOption = Option.None();
    /// Option<bool> booleanOption = Option.None();
    /// ]]>
    /// </code>
    /// </example>
    /// <returns></returns>
    public static None None() => new();
}