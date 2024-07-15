using CodeChallenge.TreeNodes;
using Xunit;

namespace CodeChallenge.Test.TreeNodes;

public class TreeTest
{
    [Fact]
    public void Create_a_root_node_must_have_not_a_parent()
    {
        var root = new TreeSpec(5);

        Assert.True(root.IsRoot);
    }

    [Fact]
    public void Set_a_parent_must_change_is_root_value()
    {
        var root = new TreeSpec(5);
        var leaf = new TreeSpec(5);

        leaf.SetParent(root);

        Assert.True(root.IsRoot);
        Assert.False(leaf.IsRoot);
    }

    public class TreeSpec : Tree<TreeSpec, int>
    {
        public TreeSpec(int value)
            : base(value)
        {

        }

        public void SetParent(TreeSpec parent)
        {
            Parent = parent;
        }
    }
}
