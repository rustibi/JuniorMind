using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intersection
{
    [TestClass]
    public class IntersectionTests
    {
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

        [TestMethod]
        public void ShouldGetOneDirection()
        {
            Directions directions = Directions.E;
            Point a = new Point(1, 0);
            Assert.AreEqual(a, GetDirections(directions));
        }

        Point GetDirections(Directions directions)
        {
            Point intersection = new Point(0, 0);
            if (directions == Directions.N)
                intersection.y += 1;
            else if (directions == Directions.S)
                intersection.y -= 1;
            else if (directions == Directions.V)
                intersection.x -= 1;
            else if (directions == Directions.E)
                intersection.x += 1;
            return intersection;
        }

        Point MoveAround(Directions[] directions)
        {
            Point intersection = new Point(0, 0);
            Point[] coordFound = new Point[directions.Length];
            for (int i = 0; i < directions.Length; i++)
            {
                intersection = GetDirections(directions[i]);
                for (int j = 0; j < coordFound.Length; j++)
                {
                    if ((intersection.x == coordFound[j].x) && (intersection.y == coordFound[j].y))
                        return intersection;
                }
                coordFound[i].x = intersection.x;
                coordFound[i].y = intersection.y;
            }
            return new Point(0, 0);
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
        }
    }
}
