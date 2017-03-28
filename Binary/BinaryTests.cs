using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Binary
{
    [TestClass]
    public class BinaryTests
    {
        [TestMethod]
        public void DecimalBinary()
        {
            byte[] binar = { 0 };
            CollectionAssert.AreEqual(binar, DecimalToBinary(0));
        }

        List<byte> DecimalToBinary (int number)
        {
            List<byte> binar = new List<byte>();
          
            binar.Insert(0, 0);
            return binar;

        }
    }
}
