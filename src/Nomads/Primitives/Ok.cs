namespace Nomads.Primitives;

/// <summary>
/// Marker struct mainly used to implicitly create a successful <see cref="Result{TValue,TError}"/>
/// <para>
/// Generally advisable to use via static method Nomads.Result.<see cref="Nomads.Result.Ok{TValue}"/>
/// </para>
/// </summary>
/// <typeparam name="T">Type of value</typeparam>
/// <example>
/// <code>
/// <![CDATA[
/// Result<string, Exception> result = new Ok("Successful");
/// ]]>
/// </code>
/// </example>
public record struct Ok<T>(T Value) where T : notnull;
