using System.Diagnostics;

namespace CodeChallenge.Geometry
{
    /// <summary>
    /// Representation of a rectangle in a cartesian coordinate system.
    /// </summary>
    [DebuggerDisplay("({PointA.X}, {PointA.Y}) ({PointC.X}, {PointC.Y})")]
    public class Rectangle
    {
        /// <summary>
        /// Initialize a new <see cref="Rectangle"/> class with the top left and bottom right points information.
        /// </summary>
        /// <param name="topLeft">Top left point.</param>
        /// <param name="rightBottom">Right bottom point.</param>
        public Rectangle(Point topLeft, Point rightBottom)
        {
            int leftX = Math.Min(topLeft.X, rightBottom.X);
            int rightX = Math.Max(topLeft.X, rightBottom.X);
            int topY = Math.Max(topLeft.Y, rightBottom.Y);
            int bottomY = Math.Min(topLeft.Y, rightBottom.Y);

            PointA = new Point(leftX, topY);
            PointB = new Point(rightX, topY);
            PointC = new Point(rightX, bottomY);
            PointD = new Point(leftX, bottomY);
        }

        /// <summary>
        /// Indicate the adjacent type of the operation.
        /// </summary>
        public enum AdjacentType
        {
            /// <summary>
            /// Rectangles are not adjacent to each other.
            /// </summary>
            None,

            /// <summary>
            /// Rectangles are fully adjacent to each other.
            /// </summary>
            Proper,

            /// <summary>
            /// Share where one side of rectangle A is a line that exists as a set of points wholly contained on the other side of rectangle B.
            /// </summary>
            Subline,

            /// <summary>
            /// Some line segment on a side of rectangle A exists as a set of points on some side of rectangle B.
            /// </summary>
            Partial
        }

        /// <summary>
        /// True if the current rectangle has area; otherwise false.
        /// </summary>
        public bool HasArea => !PointA.IsOnTheSameAxis(PointC);

        /// <summary>
        /// Returns the height of the current rectangle
        /// </summary>
        public int Height => PointA.Y - PointC.Y;

        /// <summary>
        /// Left top corner point
        /// </summary>
        public Point PointA { get; }

        /// <summary>
        /// Right top corner point
        /// </summary>
        public Point PointB { get; }

        /// <summary>
        /// Right bottom corner point
        /// </summary>
        public Point PointC { get; }

        /// <summary>
        /// Left bottom corner point
        /// </summary>
        public Point PointD { get; }

        /// <summary>
        /// Returns the width of the current rectangle
        /// </summary>
        public int Width => PointC.X - PointA.X;

        /// <summary>
        /// Indicate wether or not if the current rectangle is intersected with the given rectangle.
        /// </summary>
        /// <param name="other">Other rectangle to compare with.</param>
        /// <returns>true if rectangles are intersected; otherwise, false.</returns>
        public bool AreIntersected(Rectangle other)
        {
            if (other == null)
            {
                return false;
            }

            // if rectangles have no area
            if (!HasArea || !other.HasArea)
            {
                return false;
            }

            // If one rectangle is located on left side of the other
            if (PointA.X > other.PointC.X || other.PointA.X > PointC.X)
            {
                return false;
            }

            // If one rectangle is located above the other
            if (PointC.Y > other.PointA.Y || other.PointC.Y > PointA.Y)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get the adjacent result for the adjacent operation of the current and the given rectangle.
        /// </summary>
        /// <param name="other">The other rectangle to compare with.</param>
        /// <returns>An <see cref="AdjacentType"/> enum type.</returns>
        public AdjacentType GetAdjacent(Rectangle other)
        {
            if (!IsAdjacentTo(other))
            {
                return AdjacentType.None;
            }

            var rectangle = GetRectangleFromIntersection(other);

            if ((Width == rectangle.Width && other.Width == rectangle.Width) ||
                (Height == rectangle.Height && other.Height == rectangle.Height))
            {
                return AdjacentType.Proper;
            }

            if (Width == rectangle.Width ||
                Height == rectangle.Height ||
                other.Width == rectangle.Width ||
                other.Height == rectangle.Height)
            {
                return AdjacentType.Subline;
            }

            return AdjacentType.Partial;
        }

        /// <summary>
        /// Get an intersection result comparing the current to another rectangle.
        /// </summary>
        /// <param name="other">Other rectangle to compare with.</param>
        /// <returns>A IntersectionResult with the points of intersection.</returns>
        public IntersectionResult GetIntersection(Rectangle other)
        {
            if (!AreIntersected(other))
            {
                return IntersectionResult.NoIntersection;
            }
            var rectangle = GetRectangleFromIntersection(other);
            var points = new List<Point>();
            if (IsPointOnAnyAxis(rectangle.PointA) && other.IsPointOnAnyAxis(rectangle.PointA))
            {
                points.Add(rectangle.PointA);
            }
            if (IsPointOnAnyAxis(rectangle.PointB) && other.IsPointOnAnyAxis(rectangle.PointB))
            {
                points.Add(rectangle.PointB);
            }
            if (IsPointOnAnyAxis(rectangle.PointC) && other.IsPointOnAnyAxis(rectangle.PointC))
            {
                points.Add(rectangle.PointC);
            }
            if (IsPointOnAnyAxis(rectangle.PointD) && other.IsPointOnAnyAxis(rectangle.PointD))
            {
                points.Add(rectangle.PointD);
            }
            return new IntersectionResult(points.Distinct());
        }

        /// <summary>
        /// Indicates whether or not if the current rectangle is adjacent to the given rectangle.
        /// Rectangles with no area always cause a false result.
        /// </summary>
        /// <param name="other">The other rectangle to compare with.</param>
        /// <returns>True if the current rectangle is adjacent to the given rectangle; otherwise false.</returns>
        public bool IsAdjacentTo(Rectangle other)
        {
            // if rectangles have no area
            if (!HasArea || !other.HasArea)
            {
                return false;
            }

            if (Math.Abs(PointA.X - other.PointC.X) == 0 || Math.Abs(PointC.X - other.PointA.X) == 0)
            {
                return !(PointA.Y < other.PointC.Y || other.PointA.Y < PointC.Y);
            }

            if (Math.Abs(PointA.Y - other.PointC.Y) == 0 || Math.Abs(PointC.Y - other.PointA.Y) == 0)
            {
                return !(PointC.X < other.PointA.X || other.PointC.X < PointA.X);
            }

            return false;
        }

        /// <summary>
        /// Indicates whether or not if the current rectangle is fully contained in the given rectangle.
        /// Rectangles with no area always cause a false result.
        /// </summary>
        /// <param name="other">The other rectangle to compare with.</param>
        /// <returns>True if the current rectangle is contained in the given rectangle; otherwise false</returns>
        public bool IsFullyContainedOn(Rectangle other)
        {
            if (other == null)
            {
                return false;
            }

            // if rectangles have no area
            if (!HasArea || !other.HasArea)
            {
                return false;
            }

            // If current rectangle has larger X axis than the other
            if (PointA.X < other.PointA.X || PointC.X > other.PointC.X)
            {
                return false;
            }

            // If current rectangle has larger Y axis than the other
            if (PointA.Y > other.PointA.Y || PointC.Y < other.PointC.Y)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Indicates whether the given point is on the axis of the current rectangle.
        /// </summary>
        /// <param name="point">The point to compare with.</param>
        /// <returns>true if the point is on any axis; otherwise, false.</returns>
        public bool IsPointOnAnyAxis(Point point)
        {
            return PointA.IsOnTheSameAxis(point) || PointC.IsOnTheSameAxis(point);
        }

        private Rectangle GetRectangleFromIntersection(Rectangle other)
        {
            var pointA = new Point(Math.Max(PointA.X, other.PointA.X), Math.Min(PointA.Y, other.PointA.Y));
            var pointC = new Point(Math.Min(PointC.X, other.PointC.X), Math.Max(PointC.Y, other.PointC.Y));
            return new Rectangle(pointA, pointC);
        }

        /// <summary>
        /// Represents the result of an intersection of two rectangles.
        /// It contains the information of the found points.
        /// </summary>
        public class IntersectionResult
        {
            /// <summary>
            /// No intersection result.
            /// </summary>
            public static IntersectionResult NoIntersection = new IntersectionResult();

            /// <summary>
            /// Initialized a new <see cref="IntersectionResult"/> class with the given points.
            /// </summary>
            /// <param name="interesectionPoints">The set of intersection points</param>
            public IntersectionResult(IEnumerable<Point> interesectionPoints)
            {
                Intersections = interesectionPoints ?? new List<Point>();
            }

            private IntersectionResult()
            {
                Intersections = new List<Point>();
            }

            /// <summary>
            /// List of intersections points.
            /// </summary>
            public IEnumerable<Point> Intersections { get; }

            /// <summary>
            /// Indicate wether or not the result is an intersection.
            /// </summary>
            public bool Result => Intersections.Any();
        }
    }
}