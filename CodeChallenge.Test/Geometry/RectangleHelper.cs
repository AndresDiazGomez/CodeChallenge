using CodeChallenge.Geometry;
using Xunit;

namespace CodeChallenge.Test.Geometry
{
    public static class RectangleHelper
    {
        public static Rectangle GetRectangle_X1Y2_X3Y0()
        {
            var pointA = new Point(1, 2);
            var pointC = new Point(3, 0);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X0Y3_X2Y1()
        {
            var pointA = new Point(0, 3);
            var pointC = new Point(2, 1);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X1Y3_X3Y1()
        {
            var pointA = new Point(1, 3);
            var pointC = new Point(3, 1);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X0Y2_X2Y0()
        {
            var pointA = new Point(0, 2);
            var pointC = new Point(2, 0);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X2Y2_X4Y0()
        {
            var pointA = new Point(2, 2);
            var pointC = new Point(4, 0);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X3Y2_X5Y0()
        {
            var pointA = new Point(3, 2);
            var pointC = new Point(5, 0);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X0Y3_X3Y1()
        {
            var pointA = new Point(0, 3);
            var pointC = new Point(3, 1);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X1Y2_X2Y0()
        {
            var pointA = new Point(1, 2);
            var pointC = new Point(2, 0);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X0Y2_X3Y1()
        {
            var pointA = new Point(0, 2);
            var pointC = new Point(3, 1);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X1Y3_X2Y0()
        {
            var pointA = new Point(1, 3);
            var pointC = new Point(2, 0);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X0Y8_X10Y0()
        {
            var pointA = new Point(0, 8);
            var pointC = new Point(10, 0);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X2Y9_X7Y3()
        {
            var pointA = new Point(2, 9);
            var pointC = new Point(7, 3);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X1Y1_X2Y0()
        {
            var pointA = new Point(1, 1);
            var pointC = new Point(2, 0);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X1Y3_X4Y2()
        {
            var pointA = new Point(1, 3);
            var pointC = new Point(4, 2);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X0Y1_X1Y0()
        {
            var pointA = new Point(0, 1);
            var pointC = new Point(1, 0);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X0Y2_X1Y1()
        {
            var pointA = new Point(0, 2);
            var pointC = new Point(1, 1);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X2Y2_X3Y1()
        {
            var pointA = new Point(2, 2);
            var pointC = new Point(3, 1);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X0Y3_X1Y1()
        {
            var pointA = new Point(0, 3);
            var pointC = new Point(1, 1);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X0Y2_X2Y1()
        {
            var pointA = new Point(0, 2);
            var pointC = new Point(2, 1);
            return new Rectangle(pointA, pointC);
        }

        public static Rectangle GetRectangle_X1Y1_X3Y0()
        {
            var pointA = new Point(1, 1);
            var pointC = new Point(3, 0);
            return new Rectangle(pointA, pointC);
        }
    }
}