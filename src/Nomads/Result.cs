using Nomads.Primitives;
#if NET_6_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace Nomads;

/// <summary>
/// Represents model for a successful state of <see cref="TValue"/> or failed of <see cref="TError"/>
/// </summary>
/// <typeparam name="TValue">Type of successful state value</typeparam>
/// <typeparam name="TError">Type of failed state value</typeparam>
public readonly struct Result<TValue, TError>
    where TValue : notnull
    where TError : notnull
{
    private readonly TValue? _value;
    private readonly TError? _error;
    private readonly bool _hasValue;

    private Result(TValue value) => (_value, _error, _hasValue) = (value, default, true);
    
    private Result(TError error) => (_value, _error) = (default, error);

    /// <summary>
    /// Implicitly creates a successful instance of <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <param name="value">Result's value</param>
    /// <returns></returns>
    public static implicit operator Result<TValue, TError>(TValue value) => new(value);
    
    /// <summary>
    /// Implicitly creates a failed instance of <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <param name="error">Result's error</param>
    /// <returns></returns>
    public static implicit operator Result<TValue, TError>(TError error) => new(error);

    /// <summary>
    /// Implicitly creates a successful instance of <see cref="Result{TValue,TError}"/>
    /// from a primitive <see cref="Ok{T}"/> value.
    /// </summary>
    /// <param name="ok">Instance of <see cref="Ok{T}"/></param>
    /// <returns></returns>
    public static implicit operator Result<TValue, TError>(Ok<TValue> ok) => new(ok.Value);
    
    /// <summary>
    /// Implicitly creates a successful instance of <see cref="Result{TValue,TError}"/>
    /// from a primitive <see cref="Error{T}"/> value
    /// </summary>
    /// <param name="error">Instance of <see cref="Error{T}"/></param>
    /// <returns></returns>
    public static implicit operator Result<TValue, TError>(Error<TError> error) => new(error.Value);

    
    /// <summary>
    /// Determines if the <see cref="Result{TValue,TError}"/> has a successful value,
    /// returning it if so.
    /// </summary>
    /// <param name="value">Possible value if the result is successful</param>
    /// <returns>True if the result is successful, false if not</returns>
    public bool HasValue(
        #if NET_6_OR_GREATER
        [NotNullWhen(true)]
        #endif
        out TValue? value)
    {
        value = _value;
        return _hasValue;
    }

    /// <summary>
    /// Determines if the <see cref="Result{TValue,TError}"/> has an error value,
    /// returning it if so.
    /// </summary>
    /// <param name="error">Possible error value if the result is failed</param>
    /// <returns>True if the result is failed, false if not</returns>
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