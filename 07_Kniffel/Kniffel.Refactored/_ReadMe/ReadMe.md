# Kniffel.Refactored

A refactored console application that calculates the best scoring options for a given roll of five dice in the dice game **Kniffel** (also known as Yahtzee).

## Project Info

| Property       | Value         |
|----------------|---------------|
| Target Framework | .NET 9      |
| Output Type    | Console App   |
| Namespace      | `Kniffel.Refactored` |

## Architecture

The project follows the **Strategy Pattern**: each scoring rule is encapsulated in its own class derived from the abstract `ScoringRule` base class. The `ScoringService` aggregates all rules and evaluates them against a given `DiceRoll`.

```
DiceRoll
	└─► ScoringService
			└─► ScoringRule (abstract)
					├── CountRule          (Ones … Sixes)
					├── ThreeOfAKindRule
					├── FourOfAKindRule
					├── FullHouseRule
					├── SmallStraightRule
					├── LargeStraightRule
					├── KniffelRule
					└── ChanceRule
```

## Key Classes

| Class | Namespace | Description |
|---|---|---|
| `DiceRoll` | `Kniffel.Refactored` | Represents a roll of 5 dice. Can be created randomly or from explicit values. |
| `ScoringRule` | `Kniffel.Refactored.Scoring` | Abstract base class for all scoring rules. Defines `CalculateScore` and `IsApplicableTo`. |
| `Score` | `Kniffel.Refactored.Scoring` | Immutable result object holding `RuleName` and `Points`. |
| `ScoringService` | `Kniffel.Refactored.Scoring` | Evaluates all rules against a `DiceRoll` and returns applicable scores sorted by points descending. Rules are discovered via reflection or injected via constructor. |

## Scoring Rules

| Rule | Points |
|---|---|
| Ones – Sixes | Sum of matching dice faces |
| Three of a Kind | Sum of all dice (≥ 3 identical) |
| Four of a Kind | Sum of all dice (≥ 4 identical) |
| Full House | 25 pts (3 + 2 matching) |
| Small Straight | 30 pts (4 consecutive values) |
| Large Straight | 40 pts (5 consecutive values) |
| Kniffel | 50 pts (5 identical) |
| Chance | Sum of all dice (no condition) |

## Running the App

```bash
dotnet run --project 07_Kniffel/Kniffel.Refactored/Kniffel.Refactored.csproj
```

The app rolls 5 dice, prints all applicable scores sorted by points, and asks whether to roll again.

## Extensibility

New rules can be added by:
1. Creating a class that derives from `ScoringRule`.
2. Implementing `CalculateScore(DiceRoll)` and `IsApplicableTo(DiceRoll)`.
3. Providing a public parameterless constructor.

The `ScoringService` discovers new rules automatically via reflection — no registration required.

## Related Projects

| Project | Description |
|---|---|
| `Kniffel.Original` | Legacy monolithic implementation (before refactoring) |
| `Kniffel.Original.Tests` | Tests for the original code |
| `Kniffel.Refactored.Tests` | Tests for the refactored code |
