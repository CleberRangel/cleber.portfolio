# Rules Overview

## How to use this reference

- Use this file to map a problem to the right rule or refactoring pattern.
- Read `rule-examples.md` when you need concrete C# before/after snippets.

## The 10 rules

1. Five lines - Keep methods at five lines or fewer.
2. Either call or pass, but not both - Do not mix orchestration with data manipulation in the same method.
3. If only at the start - Put `if` statements at the beginning of a method or use an early return.
4. Never use `if` with `else` - Prefer early returns or polymorphism.
5. Never use switch - Replace type-code branching with classes and polymorphism.
6. Only inherit from interfaces - Prefer interface implementation and composition over concrete inheritance.
7. Use pure conditions - Conditions should not assign, throw, or perform I/O.
8. No interface with only one implementation - Add an interface only when variation is real.
9. Do not use getters or setters - Move behavior into the object instead of exposing data.
10. Never have common affixes - Avoid noisy prefixes or suffixes that obscure responsibility.

## Named refactoring patterns

- Extract Method - Pull a block of code into a focused method.
- Replace Type Code with Classes - Replace string or enum branching with classes.
- Push Code into Classes - Move logic about an object into the object itself.
- Inline Method - Remove trivial pass-through methods.
- Specialize Method - Split a generic method into smaller, focused methods.
- Unify Similar Classes - Merge duplicated classes behind a shared abstraction.
- Combine Ifs - Merge compatible adjacent conditions into one boolean expression.
- Introduce Strategy Pattern - Extract varying behavior into a separate strategy.
- Extract Interface from Implementation - Pull the public contract out of a concrete class.
- Eliminate Getter or Setter - Move behavior inward instead of exposing data.
- Encapsulate Data - Group related fields into a dedicated type.
- Try Delete then Compile - Delete suspected dead code and let the compiler prove whether it is still used.

## Review guidance

- Prefer the smallest change that restores clarity.
- Quote the exact rule or pattern in feedback.
- Keep the compiler as the safety net when removing code.
