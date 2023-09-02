using Nomads.Primitives;

namespace Nomads;

/// <summary>
/// Extension methods for <see cref="Result{TValue,TError}"/>
/// </summary>
public static class Result
{
    
    /// <summary>
    /// Creates a new instance of <see cref="Ok{TValue}"/>, usually used to cast it to a <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <typeparam name="TValue">Type of value</typeparam>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Result<string, Exception> result = Result.Ok("Successful");
    /// ]]>
    /// </code>
    /// </example>
    public static Ok<TValue> Ok<TValue>(TValue value) where TValue : notnull => new(value);
    
    /// <summary>
    /// Creates a new instance of <see cref="Error{TError}"/>, usually used to cast it to a <see cref="Result{TValue,TError}"/>
    /// </summary>
    /// <typeparam name="TError">Type of error value</typeparam>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Result<string, Exception> result = Result.Error(new Exception("Something failed"));
    /// ]]>
    /// </code>
    /// </example>
    public static Error<TError> Error<TError>(TError error) where TError : notnull => new(error);
}