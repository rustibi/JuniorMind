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

        [TestMethod]
        public void SquaresOnAThreeByThreeBoard()
        {
            Assert.AreEqual(14, CalculateSquares(3, 3));
        }




        int CalculateSquares(int length, int width)
        {
            int squaresNo = 1;
            while (length-1 > 0)
            {
                squaresNo += length * length;
                length -= 1;
            }
            
            return squaresNo;
        }
    }
}
