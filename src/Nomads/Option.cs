#if NET_6_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace Nomads;

/// <summary>
/// Base model (functor?) representing either a value or nothing.
/// </summary>
/// <typeparam name="T">Type of value</typeparam>
public readonly struct Option<T> where T : notnull
{
    private readonly T? _value;
    private readonly bool _hasValue;

    internal Option(T value) => (_value, _hasValue) = (value, true);

    public static implicit operator Option<T>(T value) => new(value);
    
    public static implicit operator Option<T>(None _) => new();

    public static T operator !(Option<T> option) => option._value!;

    public bool HasValue(
        #if NET_6_OR_GREATER
        [NotNullWhen(true)]
        #endif
        out T? value)
    {
        value = _value;
        return _hasValue;
    }
}