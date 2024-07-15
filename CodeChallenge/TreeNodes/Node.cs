namespace CodeChallenge.TreeNodes;

/// <summary>
/// Represent a strongly typed node.
/// </summary>
/// <typeparam name="T">The type of the element.</typeparam>
public class Node<T>
{
    /// <summary>
    /// The value of the node.
    /// </summary>
    public T Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Node{T}"/> class.
    /// </summary>
    /// <param name="value">Node value</param>
    /// <exception cref="ArgumentNullException">The specified value is null.</exception>
    public Node(T value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value));
        Value = value;
    }
}