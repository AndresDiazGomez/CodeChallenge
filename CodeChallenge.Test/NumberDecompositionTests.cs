using Xunit;

namespace CodeChallenge.Test
{
    public class NumberDecompositionTests
    {
        [Fact]
        public void NumberDecomposition_With3()
        {
            var result = NumberDecomposition.Decompose(3);

            Assert.Single(result);
            Assert.Collection(result,
                first =>
                {
                    Assert.Equal(2, first[0]);
                    Assert.Equal(1, first[1]);
                });
        }

        [Fact]
        public void NumberDecomposition_With4()
        {
            var result = NumberDecomposition.Decompose(4);

            Assert.Single(result);
            Assert.Collection(result,
                first =>
                {
                    Assert.Equal(3, first[0]);
                    Assert.Equal(1, first[1]);
                });
        }

        [Fact]
        public void NumberDecomposition_With5()
        {
            var result = NumberDecomposition.Decompose(5);

            Assert.Equal(2, result.Count);
            Assert.Collection(result,
                first =>
                {
                    Assert.Equal(4, first[0]);
                    Assert.Equal(1, first[1]);
                },
                second =>
                {
                    Assert.Equal(3, second[0]);
                    Assert.Equal(2, second[1]);
                });
        }

        [Fact]
        public void NumberDecomposition_With6()
        {
            var result = NumberDecomposition.Decompose(6);

            Assert.Equal(3, result.Count);
            Assert.Collection(result,
                first =>
                {
                    Assert.Equal(5, first[0]);
                    Assert.Equal(1, first[1]);
                },
                second =>
                {
                    Assert.Equal(4, second[0]);
                    Assert.Equal(2, second[1]);
                },
                third =>
                {
                    Assert.Equal(3, third[0]);
                    Assert.Equal(2, third[1]);
                    Assert.Equal(1, third[2]);
                });
        }

        [Fact]
        public void NumberDecomposition_With7()
        {
            var result = NumberDecomposition.Decompose(7);

            Assert.Equal(4, result.Count);
            Assert.Collection(result,
                first =>
                {
                    Assert.Equal(6, first[0]);
                    Assert.Equal(1, first[1]);
                },
                second =>
                {
                    Assert.Equal(5, second[0]);
                    Assert.Equal(2, second[1]);
                },
                third =>
                {
                    Assert.Equal(4, third[0]);
                    Assert.Equal(3, third[1]);
                },
                fourth =>
                {
                    Assert.Equal(4, fourth[0]);
                    Assert.Equal(2, fourth[1]);
                    Assert.Equal(1, fourth[2]);
                });
        }

        [Fact]
        public void NumberDecomposition_With10()
        {
            var result = NumberDecomposition.Decompose(10);

            Assert.Equal(9, result.Count);
            Assert.Collection(result,
                item =>
                {
                    Assert.Equal(9, item[0]);
                    Assert.Equal(1, item[1]);
                },
                item =>
                {
                    Assert.Equal(8, item[0]);
                    Assert.Equal(2, item[1]);
                },
                item =>
                {
                    Assert.Equal(7, item[0]);
                    Assert.Equal(3, item[1]);
                },
                item =>
                {
                    Assert.Equal(7, item[0]);
                    Assert.Equal(2, item[1]);
                    Assert.Equal(1, item[2]);
                },
                item =>
                {
                    Assert.Equal(6, item[0]);
                    Assert.Equal(4, item[1]);
                },
                item =>
                {
                    Assert.Equal(6, item[0]);
                    Assert.Equal(3, item[1]);
                    Assert.Equal(1, item[2]);
                },
                item =>
                {
                    Assert.Equal(5, item[0]);
                    Assert.Equal(4, item[1]);
                    Assert.Equal(1, item[2]);
                },
                item =>
                {
                    Assert.Equal(5, item[0]);
                    Assert.Equal(3, item[1]);
                    Assert.Equal(2, item[2]);
                },
                item =>
                {
                    Assert.Equal(4, item[0]);
                    Assert.Equal(3, item[1]);
                    Assert.Equal(2, item[2]);
                    Assert.Equal(1, item[3]);
                });
        }

        [Fact]
        public void NumberDecomposition_With11()
        {
            var result = NumberDecomposition.Decompose(11);

            Assert.Equal(11, result.Count);
            Assert.Collection(result,
                item =>
                {
                    Assert.Equal(10, item[0]);
                    Assert.Equal(1, item[1]);
                },
                item =>
                {
                    Assert.Equal(9, item[0]);
                    Assert.Equal(2, item[1]);
                },
                item =>
                {
                    Assert.Equal(8, item[0]);
                    Assert.Equal(3, item[1]);
                },
                item =>
                {
                    Assert.Equal(8, item[0]);
                    Assert.Equal(2, item[1]);
                    Assert.Equal(1, item[2]);
                },
                item =>
                {
                    Assert.Equal(7, item[0]);
                    Assert.Equal(4, item[1]);
                },
                item =>
                {
                    Assert.Equal(7, item[0]);
                    Assert.Equal(3, item[1]);
                    Assert.Equal(1, item[2]);
                },
                item =>
                {
                    Assert.Equal(6, item[0]);
                    Assert.Equal(5, item[1]);
                },
                item =>
                {
                    Assert.Equal(6, item[0]);
                    Assert.Equal(4, item[1]);
                    Assert.Equal(1, item[2]);
                },
                item =>
                {
                    Assert.Equal(6, item[0]);
                    Assert.Equal(3, item[1]);
                    Assert.Equal(2, item[2]);
                },
                item =>
                {
                    Assert.Equal(5, item[0]);
                    Assert.Equal(4, item[1]);
                    Assert.Equal(2, item[2]);
                },
                item =>
                {
                    Assert.Equal(5, item[0]);
                    Assert.Equal(3, item[1]);
                    Assert.Equal(2, item[2]);
                    Assert.Equal(1, item[3]);
                });
        }
    }
}