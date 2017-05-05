using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intersection
{
    [TestClass]
    public class IntersectionTests
    {
        [TestMethod]
        public void ShouldIntersectAtPoint00()
        {
            Directions[] directions = { Directions.V, Directions.N, Directions.E, Directions.S };
            Point a = new Point(0, 0);
            Assert.AreEqual(a, MoveAround(directions));
        }

        [TestMethod]
        public void ShouldNotIntersect()
        {
            Directions[] directions = { Directions.V, Directions.N, Directions.E };
            Assert.IsNull(MoveAround(directions));
        }

        [TestMethod]
        public void ShouldIntersectAtPoint01()
        {
            Directions[] directions = { Directions.N, Directions.N, Directions.E, Directions.E,
                Directions.S, Directions.V, Directions.V};
            Point a = new Point(0, 1);
            Assert.AreEqual(a, MoveAround(directions));           
        }

        [TestMethod]
        public void ShouldIntersectAtPoint10()
        {
            Directions[] directions = { Directions.E, Directions.S, Directions.E, Directions.N,
                Directions.V};
            Point a = new Point(1, 0);
            Assert.AreEqual(a, MoveAround(directions));
        }


        Point Move(Point point, Directions direction)
        {
            if (direction == Directions.N)
                point.y += 1;
            else if (direction == Directions.S)
                point.y -= 1;
            else if (direction == Directions.V)
                point.x -= 1;
            else if (direction == Directions.E)
                point.x += 1;
            return point;
        }

        Point? MoveAround(Directions[] directions)
        {
            Point intersection = new Point(0, 0);
            Point[] coordFound = new Point[directions.Length];
            for (int i = 0; i < directions.Length; i++)
            {
                intersection = Move(intersection, directions[i]);
                if (ContainsPoint(intersection, coordFound))
                    return intersection;
                coordFound[i] = intersection;
            }
            return null;
        }

        private static bool ContainsPoint(Point toFind, Point[] points)
        {
            foreach (var point in points)
            {
                if (point.Equals(toFind))
                    return true;
            }

            return false;
        }


        public enum Directions { N, S, V, E}

        struct Point
        {
            public int x;
            public int y;
            public Point (int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public bool IsEqual(Point other)
            {
                return x == other.x && y == other.y;
            }
        }
    }
}
