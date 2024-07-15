using CodeChallenge.TreeNodes;
using System;
using Xunit;

namespace CodeChallenge.Test.TreeNodes;

public class BinarySearchTreeTest
{
    [Fact]
    public void Cannot_add_duplicate_values()
    {
        var tree = new BinarySearchTree<int>(4);

        Assert.Throws<InvalidOperationException>(() => tree.AddValue(4));
    }

    [Fact]
    public void Cannot_add_null_values()
    {
        var tree = new BinarySearchTree<string>("4");

        Assert.Throws<ArgumentNullException>(() => tree.AddValue(null!));
    }

    [Fact]
    public void Tree_must_know_about_contained_elements()
    {
        var tree = new BinarySearchTree<int>(4);

        tree.AddValue(2);
        tree.AddValue(1);
        tree.AddValue(3);
        tree.AddValue(5);
        tree.AddValue(7);
        tree.AddValue(10);
        tree.AddValue(9);

        Assert.True(tree.Contains(4));
        Assert.True(tree.Contains(2));
        Assert.True(tree.Contains(1));
        Assert.True(tree.Contains(3));
        Assert.True(tree.Contains(5));
        Assert.True(tree.Contains(7));
        Assert.True(tree.Contains(10));
        Assert.True(tree.Contains(9));
        Assert.False(tree.Contains(-1));
    }

    [Fact]
    public void Add_a_lower_value_must_go_to_left_side()
    {
        var valueToAdd = 2;
        var tree = new BinarySearchTree<int>(4);

        tree.AddValue(valueToAdd);

        Assert.Equal(tree!.Left!.Value, valueToAdd);
    }

    [Fact]
    public void Add_two_lower_values_must_go_to_left_bottom_root()
    {
        var valueToAdd = 1;
        var tree = new BinarySearchTree<int>(4);

        tree.AddValue(2);
        tree.AddValue(valueToAdd);

        Assert.Equal(valueToAdd, tree!.Left!.Left!.Value);
    }

    [Fact]
    public void Add_three_lower_values_must_go_to_left_bottom_root()
    {
        var valueToAdd = 1;
        var tree = new BinarySearchTree<int>(4);

        tree.AddValue(3);
        tree.AddValue(2);
        tree.AddValue(valueToAdd);

        Assert.Equal(valueToAdd, tree!.Left!.Left!.Left!.Value);
    }

    [Fact]
    public void Add_a_higher_value_must_go_to_right_side()
    {
        var valueToAdd = 5;
        var tree = new BinarySearchTree<int>(4);

        tree.AddValue(valueToAdd);

        Assert.Equal(valueToAdd, tree!.Right!.Value);
    }

    [Fact]
    public void Add_two_higher_values_must_go_to_right_bottom_root()
    {
        var valueToAdd = 6;
        var tree = new BinarySearchTree<int>(4);

        tree.AddValue(5);
        tree.AddValue(valueToAdd);

        Assert.Equal(valueToAdd, tree!.Right!.Right!.Value);
    }

    [Fact]
    public void Add_three_higher_values_must_go_to_right_bottom_root()
    {
        var valueToAdd = 7;
        var tree = new BinarySearchTree<int>(4);

        tree.AddValue(5);
        tree.AddValue(6);
        tree.AddValue(valueToAdd);

        Assert.Equal(valueToAdd, tree!.Right!.Right!.Right!.Value);
    }

    [Fact]
    public void Interchange_higher_and_lower_values_must_go_to_a_correct_position()
    {
        var tree = new BinarySearchTree<int>(4);

        tree.AddValue(2);
        tree.AddValue(1);
        tree.AddValue(3);
        tree.AddValue(5);
        tree.AddValue(7);
        tree.AddValue(10);
        tree.AddValue(9);

        Assert.Equal(2, tree!.Left!.Value);
        Assert.Equal(1, tree!.Left!.Left!.Value);
        Assert.Equal(3, tree!.Left!.Right!.Value);
        Assert.Equal(5, tree!.Right!.Value);
        Assert.Equal(7, tree!.Right!.Right!.Value);
        Assert.Equal(10, tree!.Right!.Right!.Right!.Value);
        Assert.Equal(9, tree!.Right!.Right!.Right!.Left!.Value);
    }

    [Fact]
    public void Adding_values_to_the_tree_must_set_the_parent_element()
    {
        var tree = new BinarySearchTree<int>(4);

        tree.AddValue(2);
        tree.AddValue(1);
        tree.AddValue(3);
        tree.AddValue(5);
        tree.AddValue(7);
        tree.AddValue(10);
        tree.AddValue(9);

        Assert.Null(tree.Parent);
        Assert.Equal(4, tree!.Left!.Parent!.Value);
        Assert.Equal(2, tree!.Left!.Left!.Parent!.Value);
        Assert.Equal(2, tree!.Left!.Right!.Parent!.Value);
        Assert.Equal(4, tree!.Right!.Parent!.Value);
        Assert.Equal(5, tree!.Right!.Right!.Parent!.Value);
        Assert.Equal(7, tree!.Right!.Right!.Right!.Parent!.Value);
        Assert.Equal(10, tree!.Right!.Right!.Right!.Left!.Parent!.Value);
    }
}
