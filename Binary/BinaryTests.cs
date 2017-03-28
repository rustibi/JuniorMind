using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Binary
{
    [TestClass]
    public class BinaryTests
    {
        [TestMethod]
        public void DecimalBinary_0()
        {
            byte[] binar = { 0 };
            CollectionAssert.AreEqual(binar, DecimalToBinary(0));
        }


        [TestMethod]
        public void DecimalBinary_3()
        {
            byte[] binar = { 1, 1 };
            CollectionAssert.AreEqual(binar, DecimalToBinary(3));
        }


        [TestMethod]
        public void DecimalBinary_5()
        {
            byte[] binar = { 1, 0, 1 };
            CollectionAssert.AreEqual(binar, DecimalToBinary(5));
        }


        [TestMethod]
        public void DecimalBinary_49()
        {
            byte[] binar = { 1, 1, 0, 0, 0, 1 };
            CollectionAssert.AreEqual(binar, DecimalToBinary(49));
        }



        List<byte> DecimalToBinary (int number)
        {
            List<byte> binar = new List<byte>();

            if (number == 0)
            {
                binar.Insert(0, 0);
            }
            
            while (number > 0)
            {
                binar.Insert(0, (byte)(number % 2));
                number = number / 2;
            }
            return binar;
        }
    }
}
