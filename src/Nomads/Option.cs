using Nomads.Primitives;

namespace Nomads;

public record Some<T>(T Value) : Option<T>, IEquatable<Option<T>> where T : notnull
{
    bool IEquatable<Option<T>>.Equals(Option<T>? other) =>
        other is Some<T> some && Value.Equals(some.Value);
}

public record None<T> : Option<T>, IEquatable<Option<T>> where T : notnull
{
    public static implicit operator None<T>(None _) => new();
    bool IEquatable<Option<T>>.Equals(Option<T>? other) => other is None<T>;
}

/// <summary>
/// Base model (functor?) representing either a value or nothing.
/// </summary>
/// <typeparam name="T">Type of value</typeparam>
public abstract record Option<T> where T : notnull
{
    /// <summary>
    /// Implicitly creates an instance of <see cref="Option{T}"/> with a value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Option<T>(T value) => new Some<T>(value);
    
    /// <summary>
    /// Implicitly creates an empty instance of <see cref="Option{T}"/>
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    public static implicit operator Option<T>(None _) => new None<T>();
}