namespace Nomads.Primitives;

public readonly struct Error<T> where T : notnull
{
    public readonly T Value;
    public Error(T value) => Value = value;
}