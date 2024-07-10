using System.Diagnostics;

namespace CodeChallenge.Geometry
{
    /// <summary>
    /// Represents a point in a cartesian coordinate system.
    /// </summary>
    [DebuggerDisplay("X:{X}, Y:{Y}")]
    public class Point : IEquatable<Point>
    {
        /// <summary>
        /// Initialized a new <see cref="Point"/> class with the given coordinates.
        /// </summary>
        /// <param name="x">X axis coordinate.</param>
        /// <param name="y">Y axis coordinate.</param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X axis coordinate.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Y axis coordinate.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Indicates whether the current point is located on the same axis to another point.
        /// </summary>
        /// <param name="other">The other point to compare with.</param>
        /// <returns>true if the current object is located on the same axis to the other parameter; otherwise, false.</returns>
        public bool IsOnTheSameAxis(Point other)
        {
            if (other == null)
            {
                return false;
            }
            return X == other.X || Y == other.Y;
        }

        /// <summary>
        /// Indicates whether the current point is equal to another point.
        /// </summary>
        /// <param name="other">The other point to compare with.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Point? other)
        {
            if (other is null)
            {
                return false;
            }
            return X == other.X && Y == other.Y;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object.
        /// </summary>
        /// <param name="other">The other object to compare with this.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Point);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}