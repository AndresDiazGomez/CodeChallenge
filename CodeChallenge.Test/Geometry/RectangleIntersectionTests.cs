using Xunit;

namespace CodeChallenge.Test.Geometry
{
    public class RectangleIntersectionTests
    {
        [Fact]
        public void Rectangle_GetFirstIntersection()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X1Y2_X3Y0();
            var rectangleTwo = RectangleHelper.GetRectangle_X0Y3_X2Y1();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(1, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetSecondIntersection()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y3_X2Y1();
            var rectangleTwo = RectangleHelper.GetRectangle_X1Y2_X3Y0();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(1, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetThirdIntersection()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X1Y3_X3Y1();
            var rectangleTwo = RectangleHelper.GetRectangle_X0Y2_X2Y0();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(1, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetFourthIntersection()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y2_X2Y0();
            var rectangleTwo = RectangleHelper.GetRectangle_X1Y3_X3Y1();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(1, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetFifthIntersection()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y2_X2Y0();
            var rectangleTwo = RectangleHelper.GetRectangle_X2Y2_X4Y0();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(0, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetSixthIntersection()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y3_X3Y1();
            var rectangleTwo = RectangleHelper.GetRectangle_X1Y2_X2Y0();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(1, item.Y);
                },
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(1, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetSeventhIntersection()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y2_X3Y1();
            var rectangleTwo = RectangleHelper.GetRectangle_X1Y3_X2Y0();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(2, item.Y);
                },
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(1, item.Y);
                },
                item =>
                {
                    Assert.Equal(1, item.X);
                    Assert.Equal(1, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetEighthIntersection()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y8_X10Y0();
            var rectangleTwo = RectangleHelper.GetRectangle_X2Y9_X7Y3();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.True(intersection.Result);
            Assert.Collection(intersection.Intersections,
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(8, item.Y);
                },
                item =>
                {
                    Assert.Equal(7, item.X);
                    Assert.Equal(8, item.Y);
                }
            );
        }

        [Fact]
        public void Rectangle_GetNoIntersection()
        {
            var rectangleOne = RectangleHelper.GetRectangle_X0Y2_X2Y0();
            var rectangleTwo = RectangleHelper.GetRectangle_X3Y2_X5Y0();

            var intersection = rectangleOne.GetIntersection(rectangleTwo);

            Assert.NotNull(intersection);
            Assert.False(intersection.Result);
        }
    }
}