using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HanoiTowers
{
    [TestClass]
    public class HanoiTowersTests
    {
        [TestMethod]
        public void ShouldMoveThreeDisks()
        {
            int[] result = { 1, 2, 3 };
            CollectionAssert.AreEqual(result, HanoiTowers(3, new int[] { 1, 2, 3 }, new int[3], new int[3]));
        }

        [TestMethod]
        public void ShouldMoveTenDisks()
        {
            int[] result = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            CollectionAssert.AreEqual(result, HanoiTowers(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                new int[10], new int[10]));
        }

        public int[] HanoiTowers(int diskNumbers, int[] A, int[] B, int[] C)
        {
            if (diskNumbers == 1)
                Move(diskNumbers, A, C);
            else
            {
                HanoiTowers(diskNumbers - 1, A, B, C);
                Move(diskNumbers, A, C);
                HanoiTowers(diskNumbers - 1, B, C, A);
            }
            return C;
        }

        public int[] Move(int disk, int[] from, int[] to)
        {
            to[disk - 1] = from[disk - 1];
            Array.Resize(ref from, from.Length - 1);
            return from;
        }
    }
}
