using Nomads.Primitives;

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
    private readonly bool _hasValue;
    private readonly TValue? _value;
    private readonly TError? _error;

    private Result(TValue value) => (_value, _hasValue) = (value, true);

    private Result(TError error) => _error = error;

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
    /// Method that runs a delegate on eiter Value or Error case,
    /// allowing to materialise a resulting value from a <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <param name="okDelegate"></param>
    /// <param name="errorDelegate"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TError"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    /// <returns></returns>
    public TOut Reduce<TOut>(
        Func<TValue, TOut> okDelegate,
        Func<TError, TOut> errorDelegate) =>
        _hasValue
            ? okDelegate.Invoke(_value!)
            : errorDelegate.Invoke(_error!);
    
    /// <summary>
    /// Applies a mapping function to a <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <param name="selector">Mapping function</param>
    /// <typeparam name="TOut">Target type</typeparam>
    /// <returns>A <see cref="Result{TValue,TError}"/> with its value type mapped</returns>
    public Result<TOut, TError> Map<TOut>(
        Func<TValue, TOut> selector)
        where TOut : notnull =>
        _hasValue
            ? selector.Invoke(_value!)
            : _error!;
}