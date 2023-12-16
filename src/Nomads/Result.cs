namespace Nomads;

/// <summary>
/// Represents model for a successful state of <see cref="T"/> or failed of <see cref="TErr"/>
/// </summary>
/// <typeparam name="T">Type of successful state value</typeparam>
/// <typeparam name="TErr">Type of failed state value</typeparam>
public abstract record Result<T, TErr>
    where T : notnull
    where TErr : notnull
{
    /// <summary>
    /// Implicitly creates a successful instance of <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <param name="value">Result's value</param>
    /// <returns></returns>
    public static implicit operator Result<T, TErr>(T value) =>
        new Ok<T, TErr>(value);
    
    /// <summary>
    /// Implicitly creates a failed instance of <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <param name="error">Result's error</param>
    /// <returns></returns>
    public static implicit operator Result<T, TErr>(TErr error) => 
        new Error<T, TErr>(error);

    /// <summary>
    /// Implicitly creates a successful instance of <see cref="Result{TValue,TError}"/>
    /// from a primitive <see cref="Ok{T}"/> value.
    /// </summary>
    /// <param name="ok">Instance of <see cref="Ok{T}"/></param>
    /// <returns></returns>
    public static implicit operator Result<T, TErr>(Ok<T> ok) => ok.Value;
        
    /// <summary>
    /// Implicitly creates a successful instance of <see cref="Result{TValue,TError}"/>
    /// from a primitive <see cref="Error{T}"/> value
    /// </summary>
    /// <param name="error">Instance of <see cref="Error{T}"/></param>
    /// <returns></returns>
    public static implicit operator Result<T, TErr>(Error<TErr> error) => error.Value;
}