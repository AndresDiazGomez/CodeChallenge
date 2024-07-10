namespace CodeChallenge;

/// <summary>
/// Provides functionality to find words in a given matrix.
/// Currently it only has enabled horizontal (from left to right) and vertical (from top to bottom) searches.
/// </summary>
public class WordFinder
{
    /// <summary>
    /// The maximum size of the matrix.
    /// </summary>
    public const short MaxSize = 64;

    private readonly int _cols;

    private readonly char[,] _matrix;

    private readonly int _rows;

    // The reason for having these two as private fields at the class level is to reduce the memory allocation when calling the find method.
    private readonly HashSet<string> _iteratedWords = new HashSet<string>();
    private readonly Dictionary<string, int> _wordFrequency = new Dictionary<string, int>();

    /// <summary>
    /// Initializes a new instance of the <see cref="WordFinder"/> class with the specified matrix.
    /// </summary>
    /// <param name="matrix">The matrix of characters to search within.</param>
    /// <exception cref="ArgumentNullException">Thrown when the matrix is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the matrix exceeds the maximum size.</exception>
    public WordFinder(IEnumerable<string> matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix);

        int rowCount = 0;
        int colCount = 0;
        foreach (var row in matrix)
        {
            rowCount++;
            if (row.Length > colCount)
            {
                colCount = row.Length;
            }
        }

        if (rowCount > MaxSize || colCount > MaxSize)
        {
            throw new ArgumentException(SizeError, nameof(matrix));
        }

        _rows = rowCount;
        _cols = colCount;
        _matrix = new char[_rows, _cols];

        int i = 0;
        foreach (var row in matrix)
        {
            for (int j = 0; j < row.Length; j++)
            {
                _matrix[i, j] = row[j];
            }
            i++;
        }
    }

    /// <summary>
    /// Gets the number of columns in the matrix.
    /// </summary>
    public int Cols => _cols;

    /// <summary>
    /// Gets the character matrix.
    /// </summary>
    public char this[int row, int col]
    {
        get
        {
            if (row < 0 || row >= _rows)
            {
                throw new ArgumentOutOfRangeException(nameof(row));
            }
            if (col < 0 || col >= _cols)
            {
                throw new ArgumentOutOfRangeException(nameof(col));
            }
            return _matrix[row, col];
        }
    }


    /// <summary>
    /// Gets the number of rows in the matrix.
    /// </summary>
    public int Rows => _rows;

    /// <summary>
    /// Gets the error message when the matrix exceeds the maximum size.
    /// </summary>
    public static string SizeError => $"The matrix cannot exceed the max size of {MaxSize}";

    /// <summary>
    /// Finds the words from the word stream in the matrix and returns the top 10 most frequent words.
    /// </summary>
    /// <param name="wordStream">The stream of words to search for. Null elements will not be considered</param>
    /// <returns>An enumerable of the top 10 most frequent words found in the matrix.</returns>
    public IEnumerable<string> Find(IEnumerable<string> wordStream)
    {
        if (wordStream is null)
        {
            return [];
        }
        foreach (var word in wordStream)
        {
            if (!_iteratedWords.Contains(word) && !string.IsNullOrWhiteSpace(word))
            {
                int times = SearchWord(word.AsSpan());

                if (times > 0)
                {
                    _wordFrequency[word] = times;
                }

                _iteratedWords.Add(word);
            }
        }

        return _wordFrequency.OrderByDescending(kvp => kvp.Value)
            .Take(10)
            .Select(kvp => kvp.Key);
    }

    /// <summary>
    /// Searches for the specified word in the matrix and returns the number of times it were found.
    /// </summary>
    /// <param name="word">The word to search for.</param>
    /// <returns>The number of times the word is found in the matrix.</returns>
    private int SearchWord(ReadOnlySpan<char> word)
    {
        int found = 0;
        var wordLength = word.Length;

        // Search horizontally
        // Set the row position to look at
        for (int i = 0; i < _rows; i++)
        {
            // Set the col position to start looking at
            for (int j = 0; j <= _cols - wordLength; j++)
            {
                int k;
                for (k = 0; k < wordLength; k++)
                {
                    // Check if the characters match horizontally
                    if (_matrix[i, j + k] != word[k])
                    {
                        // Break if characters don't match
                        break;
                    }
                }
                if (k == wordLength)
                {
                    // Increment found count if full word is found
                    found++;
                }
            }
        }

        // Search vertically
        for (int i = 0; i <= _rows - wordLength; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                int k;
                for (k = 0; k < wordLength; k++)
                {
                    // Check if the characters match vertically
                    if (_matrix[i + k, j] != word[k])
                    {
                        // Break if characters don't match
                        break;
                    }
                }
                if (k == wordLength)
                {
                    // Increment found count if full word is found
                    found++;
                }
            }
        }

        // Return the total number of times the word was found
        return found;
    }
}