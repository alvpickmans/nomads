namespace Nomads.Primitives;

/// <summary>
/// Marker struct to help on the creation of empty <see cref="Option{T}"/>
/// using implicit operators.
/// <para>
/// Generally advisable to use via static method Nomads.Option.<see cref="Nomads.Option.None()"/>
/// </para>
/// </summary>
/// <example>
/// <code>
/// <![CDATA[
/// Option<string> stringOption = new None();
/// Option<bool> booleanOption = new None();
/// ]]>
/// </code>
/// </example>
public record struct None;