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
            Assert.AreEqual(5, CalculateSquares(2));
        }

        [TestMethod]
        public void SquaresOnAThreeByThreeBoard()
        {
            Assert.AreEqual(14, CalculateSquares(3));
        }


        [TestMethod]
        public void SquaresOnAEightByEightBoard()
        {
            Assert.AreEqual(204, CalculateSquares(8));
        }




        int CalculateSquares(int length)
        {
            //conditia este ca "length" sa fie mare mare sau egal cu 1
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
