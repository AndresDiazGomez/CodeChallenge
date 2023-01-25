using CodeChallenge.Geometry;
using Xunit;

namespace CodeChallenge.Test.Geometry
{
    public class RectangleTests
    {
        [Theory]
        [InlineData(1, 2, 3, 0)]
        [InlineData(3, 0, 1, 2)]
        public void Rectangle_CreatePointsCorrectly(int x1, int y1, int x2, int y2)
        {
            var topLeft = new Point(x1, y1);
            var rightBottom = new Point(x2, y2);

            var rectangle = new Rectangle(topLeft, rightBottom);

            Assert.Equal(1, rectangle.PointA.X);
            Assert.Equal(2, rectangle.PointA.Y);
            Assert.Equal(3, rectangle.PointB.X);
            Assert.Equal(2, rectangle.PointB.Y);
            Assert.Equal(3, rectangle.PointC.X);
            Assert.Equal(0, rectangle.PointC.Y);
            Assert.Equal(1, rectangle.PointD.X);
            Assert.Equal(0, rectangle.PointD.Y);
        }

        [Theory]
        [InlineData(2, 1, false)]
        [InlineData(2, 3, false)]
        [InlineData(0, 3, false)]
        [InlineData(2, 2, true)]
        [InlineData(1, 1, true)]
        public void Rectangle_IsPointOnAnyAxis(int x1, int y1, bool expectedResult)
        {
            var topLeft = new Point(1, 2);
            var rightBottom = new Point(3, 0);
            var testPoint = new Point(x1, y1);
            var rectangle = new Rectangle(topLeft, rightBottom);

            var result = rectangle.IsPointOnAnyAxis(testPoint);

            Assert.Equal(expectedResult, result);
        }
    }
}