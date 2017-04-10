using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
        public void DecimalBinary_10()
        {
            byte[] binar = { 1, 0, 1, 0 };
            CollectionAssert.AreEqual(binar, DecimalToBinary(10));
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
            byte[] binar = { 1, 1, 1 };
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

        [TestMethod]
        public void DecimalBinary_LeftShift_1_3()
        {
            byte[] binar = { 1, 0, 0, 0 };
            CollectionAssert.AreEqual(binar, LeftShift(1, 3));
        }

        [TestMethod]
        public void DecimalBinary_RightShift_1_3()
        {
            byte[] binar = { 0, 0, 0, 1 };
            CollectionAssert.AreEqual(binar, RightShift(8, 3));
        }

        [TestMethod]
        public void DecimalBinary_Add_127_15()
        {
            byte[] binar = { 1, 0, 0, 0, 1, 1, 1, 0 };
            CollectionAssert.AreEqual(binar, AddBinary(127, 15));
        }

        [TestMethod]
        public void DecimalBinary_Substraction_127_15()
        {
            byte[] binar = { 0, 0, 0, 1, 1, 1, 0, 1 };
            CollectionAssert.AreEqual(binar, SubstrBinary(142, 113));
        }

        [TestMethod]
        public void AddListBinary_0_1()
        {
            byte[] binar = { 1, 1, 0, 1, 1, 1, 0 };
            List<byte> list1 = new List<byte>{ 0, 0, 1, 0, 1, 1, 0 };
            List<byte> list2 = new List<byte>{ 1, 0, 1, 1, 0, 0, 0 };
            CollectionAssert.AreEqual(binar, AddListBinary(list1, list2));
        }

        [TestMethod]
        public void DecimalBinary_MultiplyBinary_11_10()
        {
            byte[] binar = { 1, 1, 0, 1, 1, 1, 0};
            CollectionAssert.AreEqual(binar, MultiplyBinary(11, 10));
        }



        List<byte> MultiplyBinary(int number1, int number2)
        {
            List<byte> binarList1 = new List<byte>();
            List<byte> binarList2 = new List<byte>();
            binarList1 = DecimalToBinary(number1);
            binarList2 = DecimalToBinary(number2);
            InsertZeroToLists(binarList1, binarList2);
            List<byte> binarList3 = new List<byte>();
            List<byte> binarList4 = new List<byte>();
            //InsertZeroToLists(binarList1, binarList4);
            //InsertZeroToLists(binarList1, binarList3);
            int k;
            int contor = -1;

            for (int i = binarList2.Count-1; i >= 0; i--)
            {
                //k = k + 1;
                contor = contor + 1;
                k = contor;
                for (int j = binarList1.Count-1; j >= 0; j--)
                {
                    binarList3.Add((byte)(binarList2[i]*binarList1[j]));
                }
                binarList3.Reverse();
                while (k > 0)
                {
                    binarList3.Add(0);
                    k--;   
                }
                InsertZeroToLists(binarList4, binarList3);
                binarList4 = AddListBinary(binarList3, binarList4);
                binarList3.Clear();
            }
            return binarList4;
        }


        List<byte> AddListBinary(List<byte>binarList1, List<byte>binarList2)
        {
            List<byte> binarList3 = new List<byte>();
            byte carry = 0;

            for (int i = binarList1.Count - 1; i >= 0; i--)
            {
                if ((binarList1[i] == 1 && binarList2[i] == 0) || (binarList1[i] == 0 && binarList2[i] == 1))
                {
                    binarList3.Add((byte)(carry == 1 ? 0 : 1));
                    carry = (byte)(carry == 1 ? 1 : 0);
                }
                else
                {
                    binarList3.Add((byte)(carry == 1 ? 1 : 0));
                    carry = (byte)(binarList1[i] == 1 ? 1 : 0);
                }
            }
            binarList3.Reverse();
            if (carry == 1)
                binarList3.Insert(0, 1);
            return binarList3;
        }


        List<byte> SubstrBinary(int number1, int number2) // consider that number1 is allways greater then number2
        {
            List<byte> binarList1 = new List<byte>();
            List<byte> binarList2 = new List<byte>();
            binarList1 = DecimalToBinary(number1);
            binarList2 = DecimalToBinary(number2);
            InsertZeroToLists(binarList1, binarList2);
            List<byte> binarList3 = new List<byte>();
            var carry = 0; // transportul
            var p = 2; // baza

            for (int i = binarList1.Count - 1; i >= 0; i--)
            {
                if (binarList1[i] < binarList2[i])
                {
                    binarList3.Add((byte)(p + binarList1[i] + carry - binarList2[i]));
                    carry = -1;
                }
                else
                {
                    binarList3.Add((byte)(binarList1[i] + carry - binarList2[i]));
                    carry = 0;
                }
            }
            binarList3.Reverse();
            return binarList3;
        }


        List<byte> AddBinary(int number1, int number2)
        {
            List<byte> binarList1 = new List<byte>();
            List<byte> binarList2 = new List<byte>();
            binarList1 = DecimalToBinary(number1);
            binarList2 = DecimalToBinary(number2);
            InsertZeroToLists(binarList1, binarList2);
            List<byte> binarList3 = new List<byte>();
            byte carry = 0;

            for (int i = binarList1.Count-1; i >= 0; i--)
            {
                if ((binarList1[i] == 1 && binarList2[i] == 0) || (binarList1[i] == 0 && binarList2[i] == 1))
                {
                    binarList3.Add((byte)(carry == 1 ? 0 : 1));
                    carry = (byte)(carry == 1 ? 1 : 0);
                }
                else
                {
                    binarList3.Add((byte)(carry == 1 ? 1 : 0));
                    carry = (byte)(binarList1[i] == 1 ? 1 : 0);
                }
            }
            binarList3.Reverse();
            binarList3.Insert(0, (byte)(carry == 1 ? 1 : 0));
            return binarList3;
        }


        List<byte> RightShift(int number, int noOfPositions)
        {
            List<byte> binarList1 = new List<byte>();
            binarList1 = DecimalToBinary(number);
            while (noOfPositions > 0)
            {
                number /= 2;
                noOfPositions -= 1;
            }
            List<byte> binarList2 = new List<byte>();
            binarList2 = DecimalToBinary(number);

            while (binarList2.Count < binarList1.Count)
            {
                binarList2.Insert(0, 0);
            }
            return binarList2;
        }


        List<byte> LeftShift(int number, int noOfPositions)
        {
            List<byte> binarList = new List<byte>();
            while (noOfPositions > 0)
            {
                number *= 2;
                noOfPositions -= 1;
            }
            binarList = DecimalToBinary(number);
            return binarList;
        }


        void InsertZeroToLists(List<byte> binarList1, List<byte> binarList2)
        {
            while (binarList1.Count != binarList2.Count)
            {
                if (binarList1.Count < binarList2.Count)
                    binarList1.Insert(0, 0);
                else
                    binarList2.Insert(0, 0);
            }
            return;
        }


        List<byte> XOR(int number1, int number2)
        {
            List<byte> binarList1 = new List<byte>();
            List<byte> binarList2 = new List<byte>();
            List<byte> binarList3 = new List<byte>();
            binarList1 = DecimalToBinary(number1);
            binarList2 = DecimalToBinary(number2);

            InsertZeroToLists(binarList1, binarList2);

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

            InsertZeroToLists(binarList1, binarList2);

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

            InsertZeroToLists(binarList1, binarList2);
            
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
