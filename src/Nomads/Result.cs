using Nomads.Primitives;
#if NET_6_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace Nomads;

public readonly struct Result<TValue, TError>
    where TValue : notnull
    where TError : notnull
{
    private readonly TValue? _value;
    private readonly TError? _error;
    private readonly bool _hasValue;

    private Result(TValue value) => (_value, _error, _hasValue) = (value, default, true);
    private Result(TError error) => (_value, _error) = (default, error);

    public static implicit operator Result<TValue, TError>(TValue value) => new(value);
    
    public static implicit operator Result<TValue, TError>(TError error) => new(error);

    public static implicit operator Result<TValue, TError>(Ok<TValue> ok) => new(ok.Value);
    
    public static implicit operator Result<TValue, TError>(Error<TError> error) => new(error.Value);

    public bool HasValue(
        #if NET_6_OR_GREATER
        [NotNullWhen(true)]
        #endif
        out TValue? value)
    {
        value = _value;
        return _hasValue;
    }

    public bool HasError(
        #if NET_6_OR_GREATER
        [NotNullWhen(true)]
        #endif
        out TError? error)
    {
        error = _error;
        return !_hasValue;
    }
    
}