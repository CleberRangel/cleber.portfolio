---
name: five-lines-of-code
description: Use when refactoring and reviewing code. This skill is based on Christian Clausen's Five Lines of Code approach.
---

# Five Lines of Code Refactoring

Use this skill when the user wants code reviewed or refactored using Christian Clausen's Five Lines of Code approach.

## How to work

1. Identify the specific rule or pattern being violated.
2. Prefer the smallest change that restores clarity.
3. Use the compiler as a safety net when deleting dead code.
4. Favor adding focused methods or classes over broad rewrites.
5. Keep examples and fixes in C#.

## Load references when needed

- Read `references/rules-overview.md` for the full rule map and the high-level rule-to-pattern mapping.
- Read `references/rule-examples.md` when you need bad and good C# examples for a specific rule or pattern.

## Quick guidance

- Use the rule overview to identify which principle applies.
- Use the examples file to generate or explain C# fixes.
- Keep reviews short and specific, and prefer compiler-led deletion for dead code.

## Response style

- Quote the rule or pattern name the code violates.
- Prefer short, direct explanations.
- Show a corrected C# snippet.
- If the user wants a broader review, group findings by rule.
- Mention compiler-driven deletion when dead code is suspected.