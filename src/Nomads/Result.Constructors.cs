namespace Nomads;

/// <summary>
/// Extension methods for <see cref="Result{TValue,TError}"/>
/// </summary>
public static partial class Result
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
    /// Creates an ok instance of <see cref="Result{TValue, TError}"/>, defining the result types
    /// for fluent declarations.
    /// </summary>
    /// <typeparam name="TValue">Type of value</typeparam>
    /// <typeparam name="TError">Type of error</typeparam>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Result<double, string> result = Result.Ok<string, string>("43.0")
    ///     .Map(x => double.TryParse(x, out double value)
    ///         ? value
    ///         : "Invalid input"
    ///     );
    /// ]]>
    /// </code>
    /// </example>
    public static Result<TValue, TError> Ok<TValue, TError>(TValue value) 
        where TValue : notnull 
        where TError : notnull => Ok(value);
    
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
    
    /// <summary>
    /// Creates an error instance of <see cref="Result{TValue, TError}"/>, defining the result types
    /// for fluent declarations.
    /// </summary>
    /// <typeparam name="TValue">Type of value</typeparam>
    /// <typeparam name="TError">Type of error</typeparam>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Result<double, string> result = Result.Error<string, string>("Failing result")
    ///     .Map(x => double.TryParse(x, out double value)
    ///         ? value
    ///         : "Invalid input"
    ///     );
    /// ]]>
    /// </code>
    /// </example>
    public static Result<TValue, TError> Error<TValue, TError>(TError error) 
        where TValue : notnull 
        where TError : notnull => Error(error);
}