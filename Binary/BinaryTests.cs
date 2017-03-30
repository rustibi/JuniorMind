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

        [TestMethod]
        public void DecimalBinary_NOT_49()
        {
            byte[] binar = { 0, 0, 1, 1, 1, 0 };
            CollectionAssert.AreEqual(binar, NOT(49));
        }

        [TestMethod]
        public void DecimalBinary_OR_5_3()
        {
            byte[] binar = { 1, 1, 1};
            CollectionAssert.AreEqual(binar, OR(5, 3));
        }

        [TestMethod]
        public void DecimalBinary_AND_5_3()
        {
            byte[] binar = { 0, 0, 1 };
            CollectionAssert.AreEqual(binar, AND(5, 3));
        }

        [TestMethod]
        public void DecimalBinary_XOR_5_3()
        {
            byte[] binar = { 1, 1, 0 };
            CollectionAssert.AreEqual(binar, XOR(5, 3));
        }


        List<byte> XOR(int number1, int number2)
        {
            List<byte> binarList1 = new List<byte>();
            List<byte> binarList2 = new List<byte>();
            List<byte> binarList3 = new List<byte>();
            binarList1 = DecimalToBinary(number1);
            binarList2 = DecimalToBinary(number2);

            while (binarList1.Count != binarList2.Count)
            {
                if (binarList1.Count < binarList2.Count)
                    binarList1.Insert(0, 0);
                else
                    binarList2.Insert(0, 0);
            }

            for (int i = 0; i < binarList1.Count; i++)
            {
                if ((binarList1[i] == 1 && binarList2[i] == 0) || (binarList1[i] == 0 && binarList2[i] == 1))
                    binarList3.Add(1);
                else
                    binarList3.Add(0);
            }
            return binarList3;
        }


        List<byte> AND(int number1, int number2)
        {
            List<byte> binarList1 = new List<byte>();
            List<byte> binarList2 = new List<byte>();
            List<byte> binarList3 = new List<byte>();
            binarList1 = DecimalToBinary(number1);
            binarList2 = DecimalToBinary(number2);

            while (binarList1.Count != binarList2.Count)
            {
                if (binarList1.Count < binarList2.Count)
                    binarList1.Insert(0, 0);
                else
                    binarList2.Insert(0, 0);
            }

            for (int i = 0; i < binarList1.Count; i++)
            {
                if (binarList1[i] == 1 && binarList2[i] == 1)
                    binarList3.Add(1);
                else
                    binarList3.Add(0);
            }
            return binarList3;
        }


        List<byte> OR (int number1, int number2)
        {
            List<byte> binarList1 = new List<byte>();
            List<byte> binarList2 = new List<byte>();
            List<byte> binarList3 = new List<byte>();
            binarList1 = DecimalToBinary(number1);
            binarList2 = DecimalToBinary(number2);

            while (binarList1.Count != binarList2.Count)
            {
                if (binarList1.Count < binarList2.Count)
                    binarList1.Insert(0, 0);
                else
                    binarList2.Insert(0, 0);
            }

            for (int i = 0; i < binarList1.Count; i++)
            {
                if (binarList1[i] == 1 || binarList2[i] == 1)
                    binarList3.Add(1);
                else
                    binarList3.Add(0);
            }
            return binarList3;
        }

   
        List<byte> NOT (int number)
        {
            List<byte> binarList = new List<byte>();
            binarList = DecimalToBinary(number);
            for (int i = 0; i < binarList.Count; i++) 
            {
                if (binarList[i] == 0)
                    binarList[i] = 1;
                else    
                    binarList[i] = 0;
            }
            return binarList;
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
