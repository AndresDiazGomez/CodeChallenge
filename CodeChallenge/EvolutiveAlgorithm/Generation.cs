namespace CodeChallenge.EvolutiveAlgorithm;

/// <summary>
/// Represent a list of mutations. Provides methods as add and find best match.
/// </summary>
public class Generation
{
    private List<Mutation> _mutations = new List<Mutation>();

    /// <summary>
    /// Initializes a new instance of the <see cref="Generation"/> class.
    /// </summary>
    public Generation()
    {
    }

    /// <summary>
    /// Return the number of mutation the generation has.
    /// </summary>
    public int Count => _mutations.Count;

    /// <summary>
    /// Identifies all the mutations the generation has.
    /// </summary>
    public IReadOnlyCollection<Mutation> Mutations => _mutations;

    /// <summary>
    /// Add a new mutation to the generation.
    /// </summary>
    /// <param name="current">Current mutation text.</param>
    /// <param name="target">The target text the mutation is trying to achieve.</param>
    public void Add(string current, string target)
    {
        var mutation = new Mutation(current, target);
        _mutations.Add(mutation);
    }

    /// <summary>
    /// Retrieve the mutation that has the maximum score within the generation. 
    /// </summary>
    /// <returns>The mutation that has the maximum score within the generation.</returns>
    public Mutation GetBestMatch()
    {
        var maxScore = _mutations.Max(mutation => mutation.CurrentScore);
        return _mutations.First(mutation => mutation.CurrentScore == maxScore);
    }
}