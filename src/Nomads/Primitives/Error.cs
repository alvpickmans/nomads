namespace Nomads.Primitives;

/// <summary>
/// Marker struct mainly used to implicitly create an error <see cref="Result{TValue,TError}"/>
/// <para>
/// Generally advisable to use via static method Nomads.Result.<see cref="Nomads.Result.Error{TError}"/>
/// </para>
/// </summary>
/// <typeparam name="T">Type of error value</typeparam>
/// <example>
/// <code>
/// <![CDATA[
/// Result<string, Exception> result = new Error(new Exception("Something failed"));
/// ]]>
/// </code>
/// </example>
public record struct Error<T>(T Value) where T : notnull;