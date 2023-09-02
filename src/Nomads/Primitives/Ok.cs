namespace Nomads.Primitives;

public readonly struct Ok<T> where T : notnull
{
    public readonly T Value;
    public Ok(T value) => Value = value;
}