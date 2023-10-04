# Design guidelines

The main goal of this project is to provide a free space to test how far my understanding on functional programming can go within the context of C#, while at the same time create a set of tools I'm personally happy to use.

This document contains principles and guidelines made as we go, hoping to serve as context for certain design decisions.

## Forgiving use
Warnings > Errors.
Things should not be doable but help user at compile time instead of throwing exceptions at runtime.

## Good defaults
Should be easy to start using, with good global using statements.

## Pragmatism vs purism

Familiar to the C# lingo and ecosystem, instead of pushing FP terms down the throat.