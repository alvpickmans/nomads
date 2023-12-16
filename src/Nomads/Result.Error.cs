namespace Nomads;

/// <summary>
/// Utility record to create an error result that can be
/// casted to a <see cref="Result{T,TErr}"/> of any ok value type
/// </summary>
/// <param name="Value">Error instance</param>
/// <typeparam name="TErr">Error type</typeparam>
public record Error<TErr>(TErr Value) where TErr : notnull
{
    public static implicit operator Error<TErr>(TErr value) => new(value);
}

/// <summary>
/// Concrete instance of an error <see cref="Result{T,TErr}"/> with a
/// given value.
/// </summary>
/// <param name="Value">Error value</param>
/// <typeparam name="T">Value type</typeparam>
/// <typeparam name="TErr">Error type</typeparam>
public record Error<T, TErr>(TErr Value) : Result<T, TErr>
    where T : notnull
    where TErr : notnull;
