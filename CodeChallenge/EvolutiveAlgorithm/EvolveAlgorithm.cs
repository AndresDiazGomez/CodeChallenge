using System.Text;

namespace CodeChallenge.EvolutiveAlgorithm;

/// <summary>
/// Responsible for resolving a text by using evolutive algorithm.
/// </summary>
public class EvolveAlgorithm
{
    private const string _validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
    private readonly static Random _random = new Random();

    /// <summary>
    /// Initializes a new instance of the <see cref="EvolveAlgorithm"/> class.
    /// </summary>
    /// <param name="targetText">Target text the evolutive algortihm is trying to solve.</param>
    public EvolveAlgorithm(string targetText)
        : this(targetText, 0.03m)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EvolveAlgorithm"/> class.
    /// </summary>
    /// <param name="targetText">Target text the evolutive algortihm is trying to solve.</param>
    /// <param name="changeRate">Indicate the rate chance of each character of each mutation.</param>
    public EvolveAlgorithm(string targetText, decimal changeRate)
    {
        TargetText = targetText ?? throw new ArgumentNullException(nameof(targetText));
        //TODO Check that each char of the target text can be found on the valid chars string.
        MaxScore = TargetText.Length;
        ChangeRate = changeRate;
    }

    /// <summary>
    /// Event handler that is fired each time a generation is created.
    /// </summary>
    public event EventHandler<OnGenerationCreatedArgs> OnNewGenerationCreated
    {
        add
        {
            lock (_onNewGenerationCreated)
            {
                _onNewGenerationCreated += value;
            }
        }
        remove
        {
            lock (_onNewGenerationCreated)
            {
                _onNewGenerationCreated -= value;
            }
        }
    }

    private event EventHandler<OnGenerationCreatedArgs> _onNewGenerationCreated = delegate { };

    /// <summary>
    /// Indicate the rate chance of each character of each mutation.
    /// </summary>
    public decimal ChangeRate { get; } = 0.03m;

    /// <summary>
    /// Describe the maximum score the the evolutive algorithm is able to achive.
    /// </summary>
    public int MaxScore { get; }

    /// <summary>
    /// Target text the evolutive algortihm is trying to solve.
    /// </summary>
    public string TargetText { get; }

    /// <summary>
    /// Retrieve all the generations the algorithm needed to solve the problem.
    /// </summary>
    /// <param name="generationSize">Define the number of mutations each generation can have.</param>
    /// <returns>Returns a collection of generations</returns>
    public List<Generation> Resolve(short generationSize)
    {
        if (generationSize <= 0)
            throw new ArgumentException("The generation size cannot be zero or negative.", nameof(generationSize));
        List<Generation> generations = new List<Generation>();
        var reference = GetRandomText(MaxScore);
        var score = 0;
        var iteration = 0;
        while (score < MaxScore)
        {
            iteration++;
            Generation generation = GetNewGeneration(generationSize, reference);
            Mutation bestMutation = generation.GetBestMatch();
            score = bestMutation.CurrentScore;
            reference = bestMutation.Current;
            generations.Add(generation);
            _onNewGenerationCreated(this, new OnGenerationCreatedArgs(iteration, bestMutation));
        }
        return generations;
    }

    private Generation GetNewGeneration(short generationSize, string baseText)
    {
        var generation = new Generation();
        for (int i = 0; i < generationSize; i++)
        {
            generation.Add(GetNewMutation(baseText), TargetText);
        }
        return generation;
    }

    private string GetNewMutation(string mutate)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < mutate.Length; i++)
        {
            var @char = mutate[i];
            int randomNumber = _random.Next(100);
            decimal chance = randomNumber / 100m;
            if (chance < ChangeRate)
            {
                @char = GetRandomChar();
            }
            builder.Append(@char);
        }
        return builder.ToString();
    }

    private char GetRandomChar()
    {
        return _validChars[_random.Next(_validChars.Length)];
    }

    private string GetRandomText(int lenght)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < lenght; i++)
        {
            builder.Append(GetRandomChar());
        }
        return builder.ToString();
    }
}
