namespace CodeChallenge.TreeNodes;

/// <summary>
/// Represent a complete binary tree.
/// </summary>
/// <typeparam name="T"></typeparam>
public class FullBinaryTree<T> : BinaryTree<FullBinaryTree<T>, T>
     where T : IComparable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FullBinaryTree{T}"/> class.
    /// </summary>
    /// <param name="value">Node value.</param>
    /// <exception cref="ArgumentNullException">The specified value is null.</exception>
    public FullBinaryTree(T value)
        : base(value)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FullBinaryTree{T}"/> class with left and right node setted.
    /// </summary>
    /// <param name="value">Node value.</param>
    /// <param name="left">Node element.</param>
    /// <param name="right">Node element.</param>
    /// <exception cref="ArgumentNullException">The specified nodes or value are null.</exception>
    public FullBinaryTree(T value, FullBinaryTree<T> left, FullBinaryTree<T> right)
        : base(value)
    {
        SetLeftNode(left);
        SetRightNode(right);
    }
}