namespace Nomads;

/// <summary>
/// Utility record to create a successful result that can be
/// casted to a <see cref="Result{T,TErr}"/> of any error type
/// </summary>
/// <param name="Value">Successful value instance</param>
/// <typeparam name="T">Value type</typeparam>
public record struct Ok<T>(T Value) where T : notnull;

/// <summary>
/// Concrete instance of a successful <see cref="Result{T,TErr}"/> with a
/// given value.
/// </summary>
/// <param name="Value">Value instance</param>
/// <typeparam name="T">Value type</typeparam>
/// <typeparam name="TErr">Error type</typeparam>
public record Ok<T, TErr>(T Value) : Result<T, TErr>
    where T : notnull
    where TErr : notnull;
