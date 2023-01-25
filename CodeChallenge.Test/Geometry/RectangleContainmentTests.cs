using CodeChallenge.Geometry;
using Xunit;

namespace CodeChallenge.Test.Geometry
{
    public class RectangleContainmentTests
    {
        [Theory]
        [InlineData(1, 2, 2, 1, 0, 3, 3, 0)]
        [InlineData(0, 2, 2, 1, 0, 3, 3, 0)]
        [InlineData(1, 3, 2, 0, 0, 3, 3, 0)]
        public void Rectangle_IsFullyContainedOn_ReturnsTrue(int x1, int y1, int x2, int y2, int xx1, int yy1, int xx2, int yy2)
        {
            var rectangleAtopLeft = new Point(x1, y1);
            var rectangleArightBottom = new Point(x2, y2);
            var rectangleA = new Rectangle(rectangleAtopLeft, rectangleArightBottom);

            var rectangleBtopLeft = new Point(xx1, yy1);
            var rectangleBrightBottom = new Point(xx2, yy2);
            var rectangleB = new Rectangle(rectangleBtopLeft, rectangleBrightBottom);

            var result = rectangleA.IsFullyContainedOn(rectangleB);

            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 3, 3, 0, 1, 2, 2, 1)]
        [InlineData(0, 0, 0, 0, 1, 2, 2, 1)]
        [InlineData(-1, 2, 4, 1, 0, 3, 3, 0)]
        public void Rectangle_IsFullyContainedOn_ReturnsFalse(int x1, int y1, int x2, int y2, int xx1, int yy1, int xx2, int yy2)
        {
            var rectangleAtopLeft = new Point(x1, y1);
            var rectangleArightBottom = new Point(x2, y2);
            var rectangleA = new Rectangle(rectangleAtopLeft, rectangleArightBottom);

            var rectangleBtopLeft = new Point(xx1, yy1);
            var rectangleBrightBottom = new Point(xx2, yy2);
            var rectangleB = new Rectangle(rectangleBtopLeft, rectangleBrightBottom);

            var result = rectangleA.IsFullyContainedOn(rectangleB);

            Assert.False(result);
        }
    }
}