namespace Nomads;

/// <summary>
/// Base model (functor?) representing either a value or nothing.
/// </summary>
/// <typeparam name="T">Type of value</typeparam>
public abstract record Option<T> where T : notnull
{
    /// <summary>
    /// Implicitly creates an instance of <see cref="Option{T}"/> with a value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Option<T>(T value) => new Some<T>(value);
    
    /// <summary>
    /// Implicitly creates an empty instance of <see cref="Option{T}"/>
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    public static implicit operator Option<T>(None _) => new None<T>();
}
