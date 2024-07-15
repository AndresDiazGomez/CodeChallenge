namespace CodeChallenge.EvolutiveAlgorithm;

/// <summary>
/// Mutation class.
/// </summary>
public class Mutation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Generation"/> class.
    /// </summary>
    /// <param name="current">Current mutation text.</param>
    /// <param name="target">The target text the mutation is trying to achieve.</param>
    public Mutation(string current, string target)
    {
        Current = current ?? throw new ArgumentNullException(nameof(current));
        Target = target ?? throw new ArgumentNullException(nameof(target));
        if (Current.Length != Target.Length) throw new InvalidOperationException($@"The lenght of {nameof(current)} and {nameof(target)} don't match.");
        CalculateScore();
        MaxScore = Target.Length;
    }

    /// <summary>
    /// Current mutation text.
    /// </summary>
    public string Current { get; }
    /// <summary>
    /// The target text the mutation is trying to achieve.
    /// </summary>
    public string Target { get; }
    /// <summary>
    /// The current text score.
    /// </summary>
    public int CurrentScore { get; private set; }
    /// <summary>
    /// The maximun achiavable score the mutation can have.
    /// </summary>
    public int MaxScore { get; }
    /// <summary>
    /// Mutation percentage sucess rate.
    /// </summary>
    public double SucessRate => CurrentScore * 1d / MaxScore;

    private void CalculateScore()
    {
        for (int i = 0; i < Current.Length; i++)
        {
            if (Current[i].Equals(Target[i]))
            {
                CurrentScore++;
            }
        }
    }
}
