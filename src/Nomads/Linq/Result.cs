using static Nomads.Result;

namespace Nomads.Linq;

public static class Result
{
    public static Result<TOut, TError> Select<TIn, TOut, TError>(
        this Result<TIn, TError> result,
        Func<TIn, TOut> selector)
        where TIn : notnull
        where TOut : notnull
        where TError : notnull =>
        result.HasValue
            ? Ok(selector.Invoke(result.Value!))
            : Error(result.Error!);
    
    public static Result<TOut, TError> Select<TIn, TOut, TError>(
        this Result<TIn, TError> result,
        Func<TIn, Result<TOut, TError>> selector)
        where TIn : notnull
        where TOut : notnull
        where TError : notnull =>
        result.HasValue
            ? selector.Invoke(result.Value!)
            : Error(result.Error!);
}