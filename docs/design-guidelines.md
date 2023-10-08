# Design guidelines

The main goal of this project is to provide a free space to test how far my understanding on functional programming can go within the context of C#, while at the same time create a set of tools I'm personally happy to use.

This document contains principles and guidelines made as we go, hoping to serve as context for certain design decisions.

## Pragmatism vs Theoretical purism

I am far from being an expert on ~~anything~~ functional programming and the theory and mathematics behind it. 

Because I know myself, there is a high chance I will dive deep into it and read many articles, papers and books. Probably Youtube's algorithm will spam me wth countless videos on category theory, and Haskell, OCaml and F#. But it is also possible that I won't.

I believe theory has its place, but so does practicality. At the time of writing, I'm looking to just dip my feet and get something useful I'd be comfortable using.

After all, C# is not (yet) considered a functional programming so trying to make it look like one might not end up being a very practical solution.

## Forgiving use

I believe that educating by shouting is often counter productive. Instead a guided journey results in a more rewarding outcome.

The first lines of code for `Option<T>` included throwing exceptions when trying to access the Value of an empty instance.

```csharp
public record struct Option<T> 
{
    private readonly T? _value;
    
    public bool HasValue { get; }
        
    public T? Value => HasValue
        ? _value
        : throw new Exception("Cannot access value on an empty Option");
}    
```

While this is technically correct, it doesn't communicate the intention to the user but instead will be learned at runtime when it throws an exception.


```csharp
public record struct Option<T> 
{
    [MemberNotNullWhen(true, nameof(Value))]
    public bool HasValue { get; }
        
    public T? Value { get: }
}    
```

Roslyn compiler has several utilities to warn users of improper use, so potential errors can be caught earlier. An example is the built-in [Attributes for null-state static analysis](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis), which among other things allows to warn the access of a given property (Value) when another has not been checked first (HasValue);
