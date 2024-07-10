using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodeChallenge.Test;

public class WordFinderTests
{
    [Fact]
    public void Constructor_ValidMatrix_ShouldInitializeCorrectly()
    {
        // Arrange
        var matrix = new List<string> { "abcd", "efgh", "ijkl", "mnop" };

        // Act
        var wordFinder = new WordFinder(matrix);

        // Assert
        Assert.Equal(4, wordFinder.Rows);
        Assert.Equal(4, wordFinder.Cols);
        Assert.Equal('a', wordFinder[0, 0]);
        Assert.Equal('d', wordFinder[0, 3]);
        Assert.Equal('m', wordFinder[3, 0]);
        Assert.Equal('p', wordFinder[3, 3]);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(4)]
    public void Matriz_RowOutOfRange_ThrowsArgumentOutOfRangeException(int row)
    {
        // Arrange
        var matrix = new List<string> { "abcd", "efgh", "ijkl", "mnop" };

        // Act
        var wordFinder = new WordFinder(matrix);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => wordFinder[row, 0]);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(4)]
    public void Matriz_ColOutOfRange_ThrowsArgumentOutOfRangeException(int col)
    {
        // Arrange
        var matrix = new List<string> { "abcd", "efgh", "ijkl", "mnop" };

        // Act
        var wordFinder = new WordFinder(matrix);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => wordFinder[0, col]);
    }

    [Fact]
    public void Constructor_NullMatrix_ShouldThrowArgumentNullException()
    {
        // Arrange
        List<string> matrix = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new WordFinder(matrix));
    }

    [Fact]
    public void Constructor_ExceedsMaxSizeRows_ShouldThrowArgumentException()
    {
        // Arrange
        var matrix = Enumerable.Range(0, WordFinder.MaxSize + 1)
            .Select(i => "a")
            .ToList();

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new WordFinder(matrix));
        Assert.StartsWith(WordFinder.SizeError, exception.Message);
    }

    [Fact]
    public void Constructor_ExceedsMaxSizeCols_ShouldThrowArgumentException()
    {
        // Arrange
        var matrix = new List<string>
        {
            new string('a', WordFinder.MaxSize + 1)
        };

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new WordFinder(matrix));
        Assert.StartsWith(WordFinder.SizeError, exception.Message);
    }

    [Fact]
    public void Constructor_MatrixWithDifferentLengths_ShouldInitializeCorrectly()
    {
        // Arrange
        var matrix = new List<string> { "abc", "de", "f" };

        // Act
        var wordFinder = new WordFinder(matrix);

        // Assert
        Assert.Equal(3, wordFinder.Rows);
        Assert.Equal(3, wordFinder.Cols);
        Assert.Equal('a', wordFinder[0, 0]);
        Assert.Equal('c', wordFinder[0, 2]);
        Assert.Equal('d', wordFinder[1, 0]);
        Assert.Equal('e', wordFinder[1, 1]);
        // Means null
        Assert.Equal('\0', wordFinder[1, 2]);
        Assert.Equal('f', wordFinder[2, 0]);
        // Means null
        Assert.Equal('\0', wordFinder[2, 1]);
        // Means null
        Assert.Equal('\0', wordFinder[2, 2]);
    }

    [Fact]
    public void FindFromPdfExample_ReturnsCorrectly()
    {
        // Arrange
        var finder = new WordFinder([
            "abcdc",
            "rgwio",
            "chill",
            "pqnsd",
            "uvdxy",
        ]);

        // Act
        var results = finder.Find([
            "cold",
            "wind",
            "snow",
            "chill"
        ]);

        // Assert
        Assert.Collection(results,
            cold => Assert.Equal("cold", cold),
            wind => Assert.Equal("wind", wind),
            chill => Assert.Equal("chill", chill)
        );
    }

    [Fact]
    public void FindColdAppearTwice_ReturnsCorrectly()
    {
        // Arrange
        var finder = new WordFinder([
            "coldc",
            "rgwio",
            "chill",
            "pqnsd",
            "uvdxy",
        ]);

        // Act
        var results = finder.Find([
            "wind",
            "snow",
            "chill",
            "cold",
            "cold",
        ]);

        // Assert
        Assert.Collection(results,
            cold => Assert.Equal("cold", cold),
            wind => Assert.Equal("wind", wind),
            chill => Assert.Equal("chill", chill)
        );
    }

    [Fact]
    public void FindColdAppearThreeTimes_AndWindTwo_ReturnsCorrectly()
    {
        // Arrange
        var finder = new WordFinder([
            "acoldc",
            "bogwio",
            "clhill",
            "ddqnsd",
            "windyx",
        ]);

        // Act
        var results = finder.Find([
            "chill",
            "snow",
            "wind",
            "cold",
        ]);

        // Assert
        Assert.Collection(results,
            cold => Assert.Equal("cold", cold),
            wind => Assert.Equal("wind", wind)
        );
    }

    [Fact]
    public void Find_ALotOfElements_ReturnsNoMoreThan10Results()
    {
        // Arrange
        var finder = new WordFinder([
            "acoldc",
            "bogwio",
            "clhill",
            "ddqnsd",
            "windyx",
        ]);

        // Act
        var results = finder.Find(["a", "b", "c", null!, "d", "e", "f", "g", "h", "i", "w", "x", "y", "n"]);

        // Assert
        Assert.Collection(results,
             letter => Assert.Equal("d", letter),
             letter => Assert.Equal("c", letter),
             letter => Assert.Equal("i", letter),
             letter => Assert.Equal("w", letter),
             letter => Assert.Equal("n", letter),
             letter => Assert.Equal("a", letter),
             letter => Assert.Equal("b", letter),
             letter => Assert.Equal("g", letter),
             letter => Assert.Equal("h", letter),
             letter => Assert.Equal("x", letter)
         );
    }

    [Fact]
    public void Find_PassNullElement_ReturnsEmptyArray()
    {
        // Arrange
        var finder = new WordFinder([
            "acoldc",
            "bogwio",
            "clhill",
            "ddqnsd",
            "windyx",
        ]);

        // Act
        var results = finder.Find(null!);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Find_NoStreamPassed_ReturnsEmptyArray()
    {
        // Arrange
        var finder = new WordFinder([
            "acoldc",
            "bogwio",
            "clhill",
            "ddqnsd",
            "windyx",
        ]);

        // Act
        var results = finder.Find([]);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Find_NotFoundElemnts_ReturnsEmptyArray()
    {
        // Arrange
        var finder = new WordFinder([
            "acoldc",
            "bogwio",
            "clhill",
            "ddqnsd",
            "windyx",
        ]);

        // Act
        var results = finder.Find(["NotAnElement"]);

        // Assert
        Assert.Empty(results);
    }
}