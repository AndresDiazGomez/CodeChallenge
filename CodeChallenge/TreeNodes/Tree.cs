namespace CodeChallenge.TreeNodes;

/// <summary>
/// Represent a strongly type tree.
/// </summary>
/// <typeparam name="TNode">Node type.</typeparam>
/// <typeparam name="TValue">Node value type.</typeparam>
public class Tree<TNode, TValue> : Node<TValue>
    where TNode : Tree<TNode, TValue>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Tree{TNode, TValue}"/> class.
    /// </summary>
    /// <param name="value">Node value.</param>
    /// <exception cref="ArgumentNullException">The specified value is null.</exception>
    public Tree(TValue value)
        : base(value)
    {
    }

    /// <summary>
    /// Determines whether the node is the root of the tree.
    /// </summary>
    public bool IsRoot => Parent is null;

    /// <summary>
    /// Get the parent node element.
    /// </summary>
    public TNode? Parent
    {
        get;
        protected set;
    }
}