using Nomads.Primitives;

namespace Nomads;

public static class Result
{
    public static Ok<TValue> Ok<TValue>(TValue value) where TValue : notnull => new(value);
    
    public static Error<TError> Error<TError>(TError error) where TError : notnull => new(error);
}