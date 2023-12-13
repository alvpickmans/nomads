using Nomads.Primitives;

namespace Nomads;

/// <summary>
/// Base model (functor?) representing either a value or nothing.
/// </summary>
/// <typeparam name="T">Type of value</typeparam>
public readonly record struct Option<T> : IEquatable<None> where T : notnull
{
    private readonly T? _value;

    /// <summary>
    /// Creates a instances of <see cref="Option{T}"/> with a value
    /// </summary>
    /// <param name="value"></param>
    private Option(T value) => _value = value;

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
    /// Returns the value of an <see cref="Option{T}"/> if it
    /// has a value, or execute the fallback delegate
    /// </summary>
    /// <param name="fallback"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Reduce(Func<T> fallback) => _value is not null ? _value : fallback();
    
    /// <summary>
    /// Returns the value of an <see cref="Option{T}"/> if it
    /// has a value, or the fallback value defined
    /// </summary>
    /// <param name="fallback"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Reduce(T fallback) => Reduce(() => fallback);

    /// <summary>
    /// Applies a mapping function to a <see cref="Option{T}"/>
    /// </summary>
    /// <param name="selector">Mapping function</param>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <returns>An <see cref="Option{T}"/> with its value type mapped</returns>
    public Option<TOut> Map<TOut>(Func<T, TOut> selector) where TOut : notnull =>
        _value is not null 
            ? selector.Invoke(_value) 
            : new Option<TOut>();

    public bool Equals(None other) => _value is null;
}