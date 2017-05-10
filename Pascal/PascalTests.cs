using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Pascal
{
    [TestClass]
    public class PascalTests
    {
        [TestMethod]
        public void ShouldReturnPascalNumber()
        {
            Assert.AreEqual(3, PascalNumber(4, 2));
        }

        [TestMethod]
        public void ShouldReturnPascalRaw5()
        {
            int[] result = { 1, 4, 6, 4, 1 };
            CollectionAssert.AreEqual(result, PascalRow(5));
        }

        [TestMethod]
        public void ShouldReturnPascalRaw6()
        {
            int[] result = { 1, 5, 10, 10, 5, 1 };
            CollectionAssert.AreEqual(result, PascalRow(6));
        }

        [TestMethod]
        public void ShouldReturnPascalRaw0()
        {
            int[] result = { 1 };
            CollectionAssert.AreEqual(result, PascalRow(0));
        }

        [TestMethod]
        public void ShouldReturnPascalTriangle()
        {
            int[][] result = PascalTriangle(4);
            Assert.AreEqual(1, result[1][1]);
            Assert.AreEqual(3, result[3][1]);
        }


        int PascalNumber(int row, int column)
        {
            if (row == 0 || column == 0 || row == column + 1)
                return 1;
            return PascalNumber(row - 1, column - 1) + PascalNumber(row - 1, column);
        }


        int[] PascalRow(int rowNumber)
        {
            int[] numbersForRowNumber = new int[rowNumber];
            if (rowNumber == 0)
                numbersForRowNumber = new int[] { 1 };
            for (int i = 0; i < rowNumber; i++)
                numbersForRowNumber[i] = PascalNumber(rowNumber, i);
            return numbersForRowNumber;
        }


        int[][] PascalTriangle(int numberOfRows)
        {
            int[][] numbers = new int[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                numbers[i] = PascalRow(i+1);
            }
            return numbers;
        }
    }
}
