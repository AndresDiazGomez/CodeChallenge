using CodeChallenge.TreeNodes;
using System;
using Xunit;

namespace CodeChallenge.Test.TreeNodes;

public class NodeTest
{
    [Fact]
    public void Cannot_create_a_null_value_node()
    {
        Assert.Throws<ArgumentNullException>(() => new Node<string>(null!));
    }

    [Fact]
    public void Cannot_create_a_null_value_node_with_null_class()
    {
        Assert.Throws<ArgumentNullException>(() => new Node<int?>(null));
    }

    [Fact]
    public void Default_constructor_must_set_value_property()
    {
        var value = 1;

        var node = new Node<int>(value);

        Assert.Equal(node.Value, value);
    }
}
