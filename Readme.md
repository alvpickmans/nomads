# Nomads

Exploring **monads** from the illiterate perspective of a software engineer that has no clue about hardcore mathematics, functional programming or category theory.

## Motivation

At some point at work, I was introduced to *Railway Oriented Programming* [^1] by a colleague that created an internal library to chain and beautifully create workflows or logic steps. Although descriptive enough, the simple difference between `Bind()` and `Map()` caught me unprepared and concerns were raised about how user friendly it would to OOP die-hard. We settled on predominantly having a `Then()` method with overloads for when it acted as a `bind` or `map`, and I cannot stress enough how pleasant is to write code with it. 

In parallel, I started to sporadically dabble into [Rust](https://www.rust-lang.org) and soon fell in love with the `no such thing as null` feature and its `Result` and `Option` types, which after so many `Object null exceptions` in csharp, it felt like a breeze of fresh air and paradoxically the [right way to handle not having a value](https://www.infoq.com/presentations/Null-References-The-Billion-Dollar-Mistake-Tony-Hoare).

This project is an attempt to slowly understand functional programming concepts while at the same time implementing a utility library I'll be comfortable using. Focusing on practicality on C# rather that functional purism, this will aim to bridge the gap between engineering and theory providing familiar constructs for the c# *connoisseur*.

> [!NOTE]
> This project ~~will~~ might not be exactly what a Category Theory/Monads expert expect. There is an excellent project, [language-ext](https://github.com/louthy/language-ext) that basically brings almost all FP paradigms to c#. 
> **Nomads** is a extremely low-fi version that looks to start as close as possible to C#, aiming to reduce ["agnosiophobia"](https://reddit.com/r/entp/comments/gg79kb/agnosiophobia) on the newcomers.

## Why "Nomads"?
I think like everyone, I struggled (and still do) with the concept of Monads. Misspelling it is my tribute to that sensation of feeling dumb while it seems everyone with an article on Monads is enlighten with a divine secret.

Also, it sounds kinda cute.

## Usage

### Functors (aka Generics)

Nomads provide implementations for the basic functional functors `Option<T>` and `Result<TValue, TError>`.

### Instancing
**Inheritance types Constructors**

```csharp
using Nomads;

Option<string> someOption = new Some<string>("Hi");
Option<string> noneOption = new None<string>();

Result<string, int> okResult = new Ok<string, int>("Ok");
Result<string, int> okResult = new Error<string, int>(-1);
```

**Static Constructors**
```csharp
using Nomads;

Option<string> someOption = Option.Some("Hi");
Option<string> noneOption = Option.None();

Result<string, int> okResult = Result.Ok("Ok");
Result<string, int> okResult = Result.Error(-1);
```

Adding a static using statement simplifies it (try `global usings`!)

```csharp
using Nomads;
using static Nomads.Option;
using static Nomads.Result;

Option<string> someOption = Some("Hi");
Option<string> noneOption = None();

Result<string, int> okResult = Ok("Ok");
Result<string, int> okResult = Error(-1);
```

**Implicit casting**
```csharp
using Nomads;
using Nomads.Primitives;

Option<string> someOption = "Hi";
Option<string> noneOption = new None();

Result<string, int> okResult = "Ok";
Result<string, int> okResult = -1;

// For results where value and error are of the same type,
// specific Ok() or Error() primitives must be used.
Result<string, string> sameTypeOkResult = new Ok("Ok");
Result<string, string> sameTypeErrorResult = new Error("Err");
```

### Reduce

To safely retrieve inner value (or error for Results), the `Reduce()` method allows to define a delegate so that:

- It can be used instead in cases where Option is empty
- Allows to handle the error scenario (or transform the result's value to another type)

```csharp
string value = Option
    .Some("Hey")
    .Reduce("???");

string result = Error<string, Exception>(new Exception("I failed you"))
    .Reduce(
        ok => ok,
        err => err.Message
    );
```

### Map (aka Select)

Both `Option` and `Result` functors can be "mapped" with function delegates using `Map()` extension methods.

```csharp
var option = Option
    .Some("hi")
    .Map(x => x.ToUpper());
Assert.Equal("HI", option.Value!);

var result = Result
    .Ok("bye")
    .Map(x => x.ToUpper());
Assert.Equal("BYE", result.Value!);
```

## Resources

- Monads for the Curious Programmer by [Bartosz Milewski](https://bartoszmilewski.com/about)
    - [Part 1](https://bartoszmilewski.com/2011/01/09/monads-for-the-curious-programmer-part-1)
    - [Part 2](https://bartoszmilewski.com/2011/03/14/monads-for-the-curious-programmer-part-2)
    - [Part 3](https://bartoszmilewski.com/2011/03/17/monads-for-the-curious-programmer-part-3)
- [Functors, Applicatives, And Monads In Pictures](https://www.adit.io/posts/2013-04-17-functors,-applicatives,_and_monads_in_pictures.html)
- [The "Map and Bind and Apply, Oh my!" series](https://fsharpforfunandprofit.com/series/map-and-bind-and-apply-oh-my/) by Scott Wlaschin


## License

This project is licensed with the [MIT license](LICENSE).

[^1]: [Railway Oriented Programming](https://fsharpforfunandprofit.com/posts/recipe-part2) by [Scott Wlaschin](https://twitter.com/ScottWlaschin)
