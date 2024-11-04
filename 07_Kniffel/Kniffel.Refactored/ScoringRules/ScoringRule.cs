namespace Kniffel.Refactored.ScoringRules;

public abstract class ScoringRule
{
    /// <summary>
    ///     Default Construktor needed for Moq mocking
    /// </summary>
    public ScoringRule()
    {
        Name = string.Empty;
    }

    protected ScoringRule(ScoreId scoreId, string name)
    {
        Name = name;
        ScoreId = scoreId;
    }

    public string Name { get; private set; }

    public ScoreId ScoreId { get; private set; }


    public abstract int CalculateScore(Wurf wurf);

    public abstract bool CanCalculateScore(Wurf wurf);
}