namespace Nomads;

/// <summary>
/// Implementation of <see cref="Option{T}"/> with a concrete value
/// </summary>
/// <param name="Value">Option value</param>
/// <typeparam name="T">Type of option value</typeparam>
public sealed record Some<T>(T Value) : Option<T>, IEquatable<Option<T>> 
    where T : notnull
{
    bool IEquatable<Option<T>>.Equals(Option<T>? other) =>
        other is Some<T> some && Value.Equals(some.Value);
}

