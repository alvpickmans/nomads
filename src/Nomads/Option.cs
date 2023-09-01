#if NET_6_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace Nomads;

public readonly struct Option<T> where T : notnull
{
    private readonly T? _value;

    internal Option(T? value) => _value = value;

    public static implicit operator Option<T>(T value) => new(value);
    
    public static implicit operator Option<T>(None none) => new(default);

    public bool HasValue(
        #if NET_6_OR_GREATER
        [NotNullWhen(true)]
        #endif
        out T? value)
    {
        value = _value;
        return value is not null;
    }
}