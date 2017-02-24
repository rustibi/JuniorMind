using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessBoard
{
    [TestClass]
    public class ChessBoardTests
    {
        [TestMethod]
        public void SquaresOnATwoByTwoBoard()
        {
            Assert.AreEqual(5, CalculateSquares(2, 2));
        }

        int CalculateSquares(int length, int width)
        {
            return length * width + 1;
        }
    }
}
