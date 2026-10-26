# Copilot Instructions

## Repository overview
- This solution currently contains two .NET 10 projects: `Kniffel.TestDrivenDesign` and `Kniffel.TestDrivenDesign.Tests`.
- The production code is a small scoring domain, not a layered app. Keep game logic in `Kniffel.TestDrivenDesign/Scoring/*`, not in `Program.cs`.
- `Program.cs` is only a minimal console entry point today; treat it as disposable shell code unless a task is explicitly about the CLI.

## Domain source of truth
- The authoritative scoring rules are documented in `Kniffel.TestDrivenDesign/.Docs/kniffel-regeln.md`.
- The code maps German game rules to English identifiers, for example:
  - `Einser` -> `ScoreCategory.Ones`
  - `Dreierpasch` -> `ScoreCategory.ThreeOfAKind`
  - `Kleine Straße` -> `ScoreCategory.SmallStraight`
- When implementing or changing scoring behavior, keep the enum names in English and align logic with the markdown rules.

## Code structure and patterns
- Centralize scoring behavior in `Kniffel.TestDrivenDesign/Scoring/KniffelScoreCalculator.cs`.
- `ScoreCategory` in `Kniffel.TestDrivenDesign/Scoring/ScoreCategory.cs` is the public rule list; add or rename categories there first.
- The current pattern is one public entry point (`CalculateScore`) plus small private helpers such as `SumByFace`, `HasOfAKind`, `IsFullHouse`, and straight-detection helpers.
- Validate inputs at the boundary before applying rule logic. Current invariants are exactly 5 dice and die values between 1 and 6.
- Prefer small pure methods and deterministic logic over stateful objects for this project.

## Testing conventions
- Tests use xUnit in `Kniffel.TestDrivenDesign.Tests`.
- Follow the existing test style in `Kniffel.TestDrivenDesign.Tests/KniffelScoreCalculatorTests.cs`: descriptive method names, `[Theory]` for repeated rule matrices, `[Fact]` for single scenarios.
- For scoring rules, add both positive and negative cases. For invalid input, assert the specific exception behavior.
- Keep test data explicit inline; the current suite favors readable dice arrays over shared builders.

## Build and test workflow
- Build the whole solution from the repo root with `dotnet build jarai.refactoring.csharp.sln`.
- Run the test project with `dotnet test Kniffel.TestDrivenDesign.Tests/Kniffel.TestDrivenDesign.Tests.csproj`.
- The test project already references `xunit`, `Microsoft.NET.Test.Sdk`, and `coverlet.collector`; reuse the existing setup instead of introducing another test framework.

## Project-specific conventions
- Main project nullable setting is `warnings`; test project uses nullable `enable`. Match the surrounding project style when adding code.
- Favor English identifiers in code even when the rule descriptions are German.
