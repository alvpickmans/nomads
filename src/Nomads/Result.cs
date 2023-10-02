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
public readonly record struct Result<TValue, TError>
    where TValue : notnull
    where TError : notnull
{
    /// <summary>
    /// Result's value, only accessible if <see cref="Result{TValue,TError}.HasValue"/> returns true.
    /// </summary>
    public readonly TValue? Value;

    /// <summary>
    /// Result's error, only accessible if <see cref="Result{TValue,TError}.HasValue"/> returns false.
    /// </summary>
    public readonly TError? Error;
    
    /// <summary>
    /// Determines if the instance of <see cref="Result{TValue, TError}"/> has a value or not
    /// </summary>
#if NET_6_OR_GREATER
    [MemberNotNullWhen(true, nameof(Value))]
    [MemberNotNullWhen(false, nameof(Error))]
#endif
    public readonly bool HasValue;

    private Result(TValue value) => (Value, Error, HasValue) = (value, default, true);
    
    private Result(TError error) => (Value, Error) = (default, error);

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
    
}