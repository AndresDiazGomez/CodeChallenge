using CodeChallenge.TreeNodes;
using System;
using Xunit;

namespace CodeChallenge.Test.TreeNodes;

public class BinaryTreeTest
{
    private BinaryTreeSpec GetTree()
    {
        //root
        var root = new BinaryTreeSpec(1);

        //left tree
        var firstLvlLeftNode = new BinaryTreeSpec(2);
        var secondLvlLeftNodeLeft = new BinaryTreeSpec(2);
        var secondLvlLeftNodeRight = new BinaryTreeSpec(4);
        var thirdLvlLeftNode = new BinaryTreeSpec(5);

        root.SetLeft(firstLvlLeftNode);
        firstLvlLeftNode.SetLeft(secondLvlLeftNodeLeft);
        firstLvlLeftNode.SetRigth(secondLvlLeftNodeRight);
        secondLvlLeftNodeLeft.SetLeft(thirdLvlLeftNode);

        //right tree
        var firstLvlRightNode = new BinaryTreeSpec(3);
        var secondLvlRightNodeRight = new BinaryTreeSpec(7);
        var thirdLvlRightNode = new BinaryTreeSpec(10);

        root.SetRigth(firstLvlRightNode);
        firstLvlRightNode.SetRigth(secondLvlRightNodeRight);
        secondLvlRightNodeRight.SetLeft(thirdLvlRightNode);

        return root;
    }


    [Fact]
    public void Set_left_and_right_nodes_must_set_correct_parent()
    {
        var root = GetTree();

        Assert.True(root.IsRoot);
        Assert.False(root!.Left!.IsRoot);
        Assert.False(root!.Left!.Left!.IsRoot);
        Assert.False(root!.Left!.Right!.IsRoot);
        Assert.False(root!.Left!.Left!.Left!.IsRoot);
        Assert.False(root!.Right!.IsRoot);
        Assert.False(root!.Right!.Right!.IsRoot);
        Assert.False(root!.Right!.Right!.Left!.IsRoot);

        Assert.Equal(1, root!.Left!.Parent!.Value);
        Assert.Equal(2, root!.Left!.Left!.Parent!.Value);
        Assert.Equal(2, root!.Left!.Right!.Parent!.Value);
        Assert.Equal(2, root!.Left!.Left!.Left.Parent!.Value);
        Assert.Equal(1, root!.Right!.Parent!.Value);
        Assert.Equal(3, root!.Right!.Right!.Parent!.Value);
        Assert.Equal(7, root!.Right!.Right!.Left!.Parent!.Value);
    }

    [Fact]
    public void Set_left_node_must_set_HasLeft_property_true()
    {
        var root = new BinaryTreeSpec(1);
        var left = new BinaryTreeSpec(2);

        root.SetLeft(left);

        Assert.True(root.HasLeft);
    }

    [Fact]
    public void Set_right_node_must_set_HasRight_property_true()
    {
        var root = new BinaryTreeSpec(1);
        var right = new BinaryTreeSpec(3);

        root.SetRigth(right);

        Assert.True(root.HasRight);
    }

    [Fact]
    public void Set_null_value_to_left_node_must_throw_ArgumentNullException()
    {
        var root = new BinaryTreeSpec(1);

        Assert.Throws<ArgumentNullException>(() => root.SetLeft(null!));
    }

    [Fact]
    public void Set_null_value_to_right_node_must_throw_ArgumentNullException()
    {
        var root = new BinaryTreeSpec(1);

        Assert.Throws<ArgumentNullException>(() => root.SetRigth(null!));
    }

    [Fact]
    public void Detach_left_node_must_clear_relationship_in_both_ways()
    {
        var root = new BinaryTreeSpec(1);
        var left = new BinaryTreeSpec(2);

        root.SetLeft(left);
        root.DetachLeftNode();

        Assert.False(root.HasLeft);
        Assert.True(left.IsRoot);
    }

    [Fact]
    public void Detach_right_node_must_clear_relationship_in_both_ways()
    {
        var root = new BinaryTreeSpec(1);
        var right = new BinaryTreeSpec(3);

        root.SetRigth(right);
        root.DetachRightNode();

        Assert.False(root.HasLeft);
        Assert.True(right.IsRoot);
    }

    [Fact]
    public void Detach_not_set_node_must_not_throw_an_expetion()
    {
        var root = new BinaryTreeSpec(1);

        root.DetachLeftNode();
        root.DetachRightNode();

        Assert.False(root.HasLeft);
    }

    [Fact]
    public void Reset_a_left_node_must_detach_older_one()
    {
        var root = new BinaryTreeSpec(1);
        var left = new BinaryTreeSpec(2);
        var left2 = new BinaryTreeSpec(3);

        root.SetLeft(left);
        root.SetLeft(left2);

        Assert.Null(left.Parent);
        Assert.Equal(root!.Left!.Value, left2.Value);
    }

    [Fact]
    public void Reset_a_right_node_must_detach_older_one()
    {
        var root = new BinaryTreeSpec(1);
        var right = new BinaryTreeSpec(2);
        var right2 = new BinaryTreeSpec(3);

        root.SetRigth(right);
        root.SetRigth(right2);

        Assert.Null(right.Parent);
        Assert.Equal(root!.Right!.Value, right2.Value);
    }

    [Fact]
    public void Binary_tree_must_know_about_contained_elements()
    {
        var root = GetTree();

        var containsTen = root.Contains(10);
        var containsMinusOne = root.Contains(-1);

        Assert.True(containsTen);
        Assert.False(containsMinusOne);
    }

    [Fact]
    public void A_root_is_only_one_element()
    {
        var root = new BinaryTreeSpec(1);

        Assert.Equal(1, root.Count);
    }

    [Fact]
    public void A_tree_must_know_about_the_quantity_of_the_elements()
    {
        var root = GetTree();

        Assert.Equal(8, root.Count);
    }

    [Fact]
    public void ToString_with_the_root_must_return_only_the_value()
    {
        var root = new BinaryTreeSpec(1);

        Assert.Equal("1", root.ToString());
    }

    [Fact]
    public void ToString_must_values_separate_by_a_dash()
    {
        var root = new BinaryTreeSpec(1);
        var left = new BinaryTreeSpec(2);
        var right = new BinaryTreeSpec(3);

        root.SetLeft(left);
        root.SetRigth(right);

        Assert.Equal("1 - 2 - 3", root.ToString());
    }

    [Fact]
    public void Full_tree_ToString_must_values_separate_by_a_dash()
    {
        var root = GetTree();

        Assert.Equal("1 - 2 - 2 - 5 - 4 - 3 - 7 - 10", root.ToString());
    }

    [Fact]
    public void Full_tree_ToString_must_values_separate_by_a_specified_separator()
    {
        var root = GetTree();

        Assert.Equal("1 + 2 + 2 + 5 + 4 + 3 + 7 + 10", root.ToString("+"));
    }

    public class BinaryTreeSpec : BinaryTree<BinaryTreeSpec, int>
    {
        public BinaryTreeSpec(int value)
            : base(value)
        {

        }

        public void SetLeft(BinaryTreeSpec node)
        {
            SetLeftNode(node);
        }

        public void SetRigth(BinaryTreeSpec node)
        {
            SetRightNode(node);
        }
    }
}
