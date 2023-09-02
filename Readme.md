# Nomads

Exploring **monads** from the illiterate perspective of a software engineer that has no clue about hardcore mathematics, functional programming or category theory.

## Motivation

I'm mostly a C# developer, and OOP has been all I've known since the beginning ca. 2017. At work, I was introduced to *Railway Oriented Programming* [^1] by a colleague that created an internal library to chain and beautifully create workflows or logic steps. On the first PR review I stared at the amount of methods and overloads, could not understand the difference from something called `Bind()` and something else called `Map()` as they looked terribly similar. In all fairness, comments where very descriptive but without the theoretical background on monads and/or functional programming I feared we would struggle to introduce it as a company-wide pattern. Finally we settled on predominantly having a `Then()` method with overloads for when it acted as a `bind` or `map`, and I cannot stress enough how pleasant is to write code with it. 

In parallel, I started to sporadically dabble into [Rust](https://www.rust-lang.org) and soon fell in love with the `no such thing as null` feature and its `Result` and `Option` types, which after so many `Object null exceptions` in csharp, it felt like a breeze of fresh air and paradoxically the [right way to handle not having a value](https://www.infoq.com/presentations/Null-References-The-Billion-Dollar-Mistake-Tony-Hoare).

This project is an attempt to better understand all this jazz, trying to bridge the gap between engineering and theory providing familiar constructs for the c# *connoisseur*.

> [!NOTE]
> This project ~~will~~ might not be exactly what a Category Theory/Monads expert expect. There is an excellent project, [language-ext](https://github.com/louthy/language-ext) that basically brings almost all FP paradigms to c#. 
> **Nomads** is a extremely low-fi version that looks to start as close as possible to C#, aiming to reduce ["agnosiophobia"](https://reddit.com/r/entp/comments/gg79kb/agnosiophobia) on the newcomers.

## Why "Nomads"?
I think like everyone, I struggled (and still do) with the concept of Monads. Misspelling it is my tribute to that sensation of feeling dumb while it seems everyone with an article on Monads is enlighten with a divine secret.

Also, it sounds kinda cute.

## Usage

> [!WARNING]
> Big, massive TODO

## Resources

- Monads for the Curious Programmer by [Bartosz Milewski](https://bartoszmilewski.com/about)
    - [Part 1](https://bartoszmilewski.com/2011/01/09/monads-for-the-curious-programmer-part-1)
    - [Part 2](https://bartoszmilewski.com/2011/03/14/monads-for-the-curious-programmer-part-2)
    - [Part 3](https://bartoszmilewski.com/2011/03/17/monads-for-the-curious-programmer-part-3)
- [Functors, Applicatives, And Monads In Pictures](https://www.adit.io/posts/2013-04-17-functors,-applicatives,_and_monads_in_pictures.html)


## License

This project is licensed with the [MIT license](LICENSE).

[^1]: [Railway Oriented Programming](https://fsharpforfunandprofit.com/posts/recipe-part2) by [Scott Wlaschin](https://twitter.com/ScottWlaschin)
