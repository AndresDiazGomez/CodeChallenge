using System.Text;

namespace CodeChallenge.TreeNodes;

/// <summary>
/// Represent a strongly type tree, with left and right nodes.
/// </summary>
/// <typeparam name="TNode">Node type.</typeparam>
/// <typeparam name="TValue">Node value type.</typeparam>
public abstract class BinaryTree<TNode, TValue> : Tree<TNode, TValue>
    where TValue : IComparable
    where TNode : BinaryTree<TNode, TValue>
{
    private bool findElement;

    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryTree{TNode, TValue}"/> class.
    /// </summary>
    /// <param name="value">Node value.</param>
    /// <exception cref="ArgumentNullException">The specified value is null.</exception>
    public BinaryTree(TValue value)
       : base(value)
    {
    }

    /// <summary>
    /// Indicates the number of childs nodes, including the current node.
    /// </summary>
    public int Count
    {
        get
        {
            return NodeCount(this);
        }
    }

    /// <summary>
    /// Indicates if the node have a left element.
    /// </summary>
    public bool HasLeft => Left is not null;

    /// <summary>
    /// Indicates if the node have a right element.
    /// </summary>
    public bool HasRight => Right is not null;

    /// <summary>
    /// Left node element.
    /// </summary>
    public TNode? Left { get; private set; }

    /// <summary>
    /// Right node element.
    /// </summary>
    public TNode? Right { get; private set; }

    /// <summary>
    /// Determines whether an element is in the tree object.
    /// </summary>
    /// <param name="value">The value to locate in the tree object.</param>
    /// <returns>True if item is found in the tree object; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">The specified value is null.</exception>
    public virtual bool Contains(TValue value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        findElement = false;
        SearchElement(this, value);
        return findElement;
    }

    /// <summary>
    /// Detach left node tree.
    /// </summary>
    public void DetachLeftNode()
    {
        if (Left != null)
        {
            Left.Parent = null;
        }
        Left = null;
    }

    /// <summary>
    /// Detach right node tree.
    /// </summary>
    public void DetachRightNode()
    {
        if (Right != null)
        {
            Right.Parent = null;
        }
        Right = null;
    }

    /// <summary>
    /// Set the left node element.
    /// </summary>
    /// <param name="node">Node element.</param>
    /// <exception cref="ArgumentNullException">The specified node is null.</exception>
    protected void SetLeftNode(TNode node)
    {
        if (node == null)
            throw new ArgumentNullException(nameof(node));
        DetachLeftNode();
        Left = node;
        Left.Parent = this as TNode;
    }

    /// <summary>
    /// Set the right node element.
    /// </summary>
    /// <param name="node">Node element.</param>
    /// <exception cref="ArgumentNullException">The specified node is null.</exception>
    protected void SetRightNode(TNode node)
    {
        ArgumentNullException.ThrowIfNull(node);
        DetachRightNode();
        Right = node;
        Right.Parent = this as TNode;
    }

    private int NodeCount(BinaryTree<TNode, TValue> element)
    {
        int quantity = 1;
        if (element.HasLeft)
        {
            quantity += NodeCount(element.Left);
        }
        if (element.HasRight)
        {
            quantity += NodeCount(element.Right);
        }
        return quantity;
    }

    private void SearchElement(BinaryTree<TNode, TValue> element, TValue value)
    {
        if (element.Value.CompareTo(value) == 0)
        {
            findElement = true;
        }
        if (element.HasLeft && !findElement)
        {
            SearchElement(element.Left, value);
        }
        if (element.HasRight && !findElement)
        {
            SearchElement(element.Right, value);
        }
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return ToString(this, "-");
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <param name="separator">Node separator.</param>
    /// <returns>A string that represents the current object.</returns>
    public virtual string ToString(string separator)
    {
        return ToString(this, separator);
    }

    private static string ToString(BinaryTree<TNode, TValue> element, string separator)
    {
        var toString = new StringBuilder($"{element.Value}");
        if (element.HasLeft)
        {
            toString.Append($" {separator} {ToString(element.Left, separator)}");
        }
        if (element.HasRight)
        {
            toString.Append($" {separator} {ToString(element.Right, separator)}");
        }
        return toString.ToString();
    }
}