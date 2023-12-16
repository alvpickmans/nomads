namespace Nomads;

/// <summary>
/// Utility record to create an untyped instance of any empty option
/// that can be casted to <see cref="None{T}"/>
/// </summary>
public record struct None;

/// <summary>
/// Concrete implementation of an empty <see cref="Option{T}"/>
/// </summary>
/// <typeparam name="T">Type of option</typeparam>
public record None<T> : Option<T>, IEquatable<Option<T>> 
    where T : notnull
{
    public static implicit operator None<T>(None _) => new();
    
    bool IEquatable<Option<T>>.Equals(Option<T>? other) => other is None<T>;
}
