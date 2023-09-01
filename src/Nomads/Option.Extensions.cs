namespace Nomads;

public static class Option
{
    public static Option<T> Some<T>(T value) where T : notnull => new(value);

    public static None None() => new();
    
    public static Option<T> None<T>() where T : notnull => new(default);

    public static bool HasValue<T>(this Option<T> option) where T : notnull => option.HasValue(out _);
}