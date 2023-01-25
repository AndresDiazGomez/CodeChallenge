using CodeChallenge.Geometry;
using Xunit;

namespace CodeChallenge.Test.Geometry
{
    public class RectangleAdjacentTests
    {
        [Fact]
        public void Rectangle_GetFirstProperAdjacent()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y2_X2Y0();
            var rectangleTwo = RectangleHelper.GetRectangle_X2Y2_X4Y0();

            var result = rectangleOne.GetAdjacent(rectangleTwo);

            Assert.Equal(Rectangle.AdjacentType.Proper, result);
        }

        [Fact]
        public void Rectangle_GetSecondProperAdjacent()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y1_X1Y0();
            var rectangleTwo = RectangleHelper.GetRectangle_X0Y2_X1Y1();

            var result = rectangleOne.GetAdjacent(rectangleTwo);

            Assert.Equal(Rectangle.AdjacentType.Proper, result);
        }

        [Fact]
        public void Rectangle_GetFirstSublineAdjacent()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y3_X3Y1();
            var rectangleTwo = RectangleHelper.GetRectangle_X1Y1_X2Y0();

            var result = rectangleOne.GetAdjacent(rectangleTwo);

            Assert.Equal(Rectangle.AdjacentType.Subline, result);
        }

        [Fact]
        public void Rectangle_GetSecondSublineAdjacent()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y3_X2Y1();
            var rectangleTwo = RectangleHelper.GetRectangle_X2Y2_X3Y1();

            var result = rectangleOne.GetAdjacent(rectangleTwo);

            Assert.Equal(Rectangle.AdjacentType.Subline, result);
        }

        [Fact]
        public void Rectangle_GetFirstPartialAdjacent()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y3_X1Y1();
            var rectangleTwo = RectangleHelper.GetRectangle_X1Y2_X2Y0();

            var result = rectangleOne.GetAdjacent(rectangleTwo);

            Assert.Equal(Rectangle.AdjacentType.Partial, result);
        }

        [Fact]
        public void Rectangle_GetSecondPartialAdjacent()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y2_X2Y1();
            var rectangleTwo = RectangleHelper.GetRectangle_X1Y1_X3Y0();

            var result = rectangleOne.GetAdjacent(rectangleTwo);

            Assert.Equal(Rectangle.AdjacentType.Partial, result);
        }

        [Fact]
        public void Rectangle_NoAdjacent()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y2_X2Y0();
            var rectangleTwo = RectangleHelper.GetRectangle_X3Y2_X5Y0();

            var result = rectangleOne.GetAdjacent(rectangleTwo);

            Assert.Equal(Rectangle.AdjacentType.None, result);
        }
    }
}