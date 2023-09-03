using static Nomads.Option;

namespace Nomads.Linq;

public static class Option
{
    public static Option<TOut> Select<TIn, TOut>(
        this Option<TIn> option,
        Func<TIn, TOut> selector)
        where TIn : notnull
        where TOut : notnull =>
        option.HasValue
            ? selector.Invoke(option.Value!)
            : None();
    
    public static Option<TOut> Select<TIn, TOut>(
        this Option<TIn> option,
        Func<TIn, Option<TOut>> selector)
        where TIn : notnull
        where TOut : notnull =>
        option.HasValue
            ? selector.Invoke(option.Value!)
            : None();
}