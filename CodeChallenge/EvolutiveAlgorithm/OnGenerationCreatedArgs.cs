namespace CodeChallenge.EvolutiveAlgorithm;

/// <summary>
/// Represents the class that contain event data, and provides a value to use for OnNewGenerationCreated.
/// </summary>
public class OnGenerationCreatedArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OnGenerationCreatedArgs"/> class.
    /// </summary>
    /// <param name="iteration">Iteration number</param>
    /// <param name="mutation">The best mutation in the created generation.</param>
    public OnGenerationCreatedArgs(int iteration, Mutation mutation)
    {
        Iteration = iteration;
        Mutation = mutation;
    }

    /// <summary>
    /// Represent the best mutation in the created generation.
    /// </summary>
    public Mutation Mutation { get; }

    /// <summary>
    /// The number of the generation.
    /// </summary>
    public int Iteration { get; }
}
