using Nomads.Primitives;
#if NET_6_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace Nomads;

/// <summary>
/// Base model (functor?) representing either a value or nothing.
/// </summary>
/// <typeparam name="T">Type of value</typeparam>
public readonly record struct Option<T> where T : notnull
{
    /// <summary>
    /// Determines if the instance of <see cref="Option{T}"/> has a value or not
    /// </summary>
#if NET_6_OR_GREATER
    [MemberNotNullWhen(true, nameof(Value))]
#endif
    public readonly bool HasValue;

    /// <summary>
    /// Option's value, only accessible if <see cref="Option{T}.HasValue"/> returns true.
    /// </summary>
    public readonly T? Value;
    
    /// <summary>
    /// Creates a instances of <see cref="Option{T}"/> with a value
    /// </summary>
    /// <param name="value"></param>
    private Option(T value) => (Value, HasValue) = (value, true);

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
    
}