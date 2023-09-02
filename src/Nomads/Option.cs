using Nomads.Primitives;
#if NET_6_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace Nomads;

/// <summary>
/// Base model (functor?) representing either a value or nothing.
/// </summary>
/// <typeparam name="T">Type of value</typeparam>
public readonly struct Option<T> where T : notnull
{
    private readonly T? _value;
    private readonly bool _hasValue;

    /// <summary>
    /// Creates a instances of <see cref="Option{T}"/> with a value
    /// </summary>
    /// <param name="value"></param>
    private Option(T value) => (_value, _hasValue) = (value, true);

    /// <summary>
    /// Implicitly creates an instance of <see cref="Option{T}"/> with a value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Option<T>(T value) => new(value);
    
    /// <summary>
    /// Implicitly creates an empty instance of <see cref="Option{T}"/>
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    public static implicit operator Option<T>(None _) => new();

    /// <summary>
    /// Determines if the <see cref="Option{T}"/> has a value,
    /// returning it if so.
    /// </summary>
    /// <param name="value">Possible value if the option is not empty</param>
    /// <returns>True if the option has a value, false if not</returns>
    public bool HasValue(
        #if NET_6_OR_GREATER
        [NotNullWhen(true)]
        #endif
        out T? value)
    {
        value = _value;
        return _hasValue;
    }
}