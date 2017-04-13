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
            List<byte> list = new List<Byte> { 1, 1, 0, 0, 0, 1 };
            CollectionAssert.AreEqual(binar, NOT(list));
        }

        [TestMethod]
        public void DecimalBinary_OR_5_3()
        {
            byte[] binar = { 1, 1, 1 };
            List<byte> list1 = new List<byte> { 1, 0, 1 };
            List<byte> list2 = new List<byte> { 1, 1 };
            char operation = 'o';
            var result = AND_OR_XOR(list1, list2, operation);
            CollectionAssert.AreEqual(binar, result);
        }

        [TestMethod]
        public void DecimalBinary_AND_5_3()
        {
            byte[] binar = { 1 };
            List<byte> list1 = new List<byte> { 1, 0, 1 };
            List<byte> list2 = new List<byte> { 1, 1 };
            var result = And(list1, list2);
            CollectionAssert.AreEqual(binar, result);
        }

        [TestMethod]
        public void DecimalBinary_XOR_5_3()
        {
            byte[] binar = { 1, 1, 0 };
            List<byte> list1 = new List<byte> { 1, 0, 1 };
            List<byte> list2 = new List<byte> { 1, 1 };
            char operation = 'x';
            var result = AND_OR_XOR(list1, list2, operation);
            CollectionAssert.AreEqual(binar, result);
        }

        [TestMethod]
        public void DecimalBinary_LeftShift_1_3()
        {
            byte[] binar = { 1, 0, 0, 0 };
            List<byte> binarIn = new List<byte> { 1 };
            CollectionAssert.AreEqual(binar, LeftShift(binarIn, 3));
        }

        [TestMethod]
        public void DecimalBinary_RightShift_1_3()
        {
            byte[] binar = { 1 };
            List<byte> binarIn = new List<byte> { 1 };
            CollectionAssert.AreEqual(binar, RightShift(binarIn, 3));
        }

        [TestMethod]
        public void DecimalBinary_Add_127_15()
        {
            byte[] binar = { 1, 0, 0, 0, 1, 1, 1, 0 };
            List<byte> list1 = new List<byte> { 1, 1, 1, 1, 1, 1, 1 };
            List<byte> list2 = new List<byte> { 1, 1, 1, 1 };
            CollectionAssert.AreEqual(binar, AddBinary(list1, list2));
        }

        [TestMethod]
        public void DecimalBinary_Add_127_15_6()
        {
            byte[] binar = { 3, 5, 4 };
            List<byte> list1 = new List<byte> { 3, 3, 1 };
            List<byte> list2 = new List<byte> { 2, 3 };
            CollectionAssert.AreEqual(binar, AddBinary(list1, list2, 6));
        }

        [TestMethod]
        public void DecimalBinary_Substr_127_15_6()
        {
            byte[] binar = { 3, 0, 4 };
            List<byte> list1 = new List<byte> { 3, 3, 1 };
            List<byte> list2 = new List<byte> { 2, 3 };
            CollectionAssert.AreEqual(binar, SubstrBinary(list1, list2, 6));
        }


        [TestMethod]
        public void DecimalBinary_Add_22_88()
        {
            byte[] binar = { 1, 1, 0, 1, 1, 1, 0 };
            List<byte> list1 = new List<byte> { 1, 0, 1, 1, 0 };
            List<byte> list2 = new List<byte> { 1, 0, 1, 1, 0, 0, 0 };
            CollectionAssert.AreEqual(binar, AddBinary(list1, list2));
            CollectionAssert.AreEqual(new byte [] { 1, 0, 1, 1, 0 }, list1);
        }

        [TestMethod]
        public void DecimalBinary_Substraction_127_15()
        {
            byte[] binar = { 1, 1, 1, 0, 1 };
            List<byte> list1 = new List<byte> { 1, 0, 0, 0, 1, 1, 1, 0 };
            List<byte> list2 = new List<byte> { 1, 1, 1, 0, 0, 0, 1 };
            CollectionAssert.AreEqual(binar, SubstrBinary(list1, list2));
        }

        [TestMethod]
        public void MultiplyBinaryOld_11_10()
        {
            byte[] binar = { 1, 1, 0, 1, 1, 1, 0 };
            List<byte> list1 = new List<byte> { 1, 0, 1, 1 };
            List<byte> list2 = new List<byte> { 1, 0, 1, 0 };
            CollectionAssert.AreEqual(binar, MultiplyBinaryOld(list1, list2));
        }

        [TestMethod]
        public void LessThan_10_11()
        {
            List<byte> list1 = new List<byte> { 1, 0, 1, 0 };
            List<byte> list2 = new List<byte> { 1, 0, 1, 1 };
            Assert.AreEqual(true, LessThan(list1, list2));
        }
        
        [TestMethod]
        public void GraterThan_11_10()
        {
            List<byte> list1 = new List<byte> { 1, 0, 1, 1 };
            List<byte> list2 = new List<byte> { 1, 0, 1, 0 };
            Assert.AreEqual(true, GraterThan(list1, list2));
        }
        

        [TestMethod]
        public void Equal_11_11()
        {
            List<byte> list1 = new List<byte> { 1, 0, 1, 1 };
            List<byte> list2 = new List<byte> { 1, 0, 1, 1 };
            Assert.AreEqual(true, Equal(list1, list2));
        }

        [TestMethod]
        public void Equal_11_10()
        {
            List<byte> list1 = new List<byte> { 1, 0, 1, 1 };
            List<byte> list2 = new List<byte> { 1, 0, 1, 0 };
            Assert.AreEqual(false, Equal(list1, list2));
        }

        [TestMethod]
        public void NotEqual_11_10()
        {
            List<byte> list1 = new List<byte> { 1, 0, 1, 1 };
            List<byte> list2 = new List<byte> { 1, 0, 1, 0 };
            Assert.AreEqual(true, NotEqual(list1, list2));
        }

        [TestMethod]
        public void MultiplyBinary_11_10()
        {
            byte[] binar = { 1, 1, 0, 1, 1, 1, 0 };
            List<byte> list1 = new List<byte> { 1, 0, 1, 1 };
            List<byte> list2 = new List<byte> { 1, 0, 1, 0 };
            CollectionAssert.AreEqual(binar, MultiplyBinary(list1, list2));
        }

        [TestMethod]
        public void MultiplyBinary_39_10()
        {
            byte[] binar = { 1, 1, 0, 0, 0, 0, 1, 1, 0 };
            List<byte> list1 = new List<byte> { 1, 0, 0, 1, 1, 1 };
            List<byte> list2 = new List<byte> { 1, 0, 1, 0 };
            CollectionAssert.AreEqual(binar, MultiplyBinary(list1, list2));
        }

        [TestMethod]
        public void MultiplyBinary_12_11()
        {
            byte[] binar = { 1, 0, 0, 0, 0, 1, 0, 0 };
            List<byte> list1 = new List<byte> { 1, 1, 0, 0 };
            List<byte> list2 = new List<byte> { 1, 0, 1, 1 };
            CollectionAssert.AreEqual(binar, MultiplyBinary(list1, list2));
        }

        [TestMethod]
        public void MultiplyBinary_127_15_6()
        {
            byte[] binar = { 1, 2, 4, 5, 3 };
            List<byte> list1 = new List<byte> { 3, 3, 1 };
            List<byte> list2 = new List<byte> { 2, 3 };
            CollectionAssert.AreEqual(binar, MultiplyBinary(list1, list2, 6));
        }

        [TestMethod]
        public void DivideBinary_12_2()
        {
            byte[] binar = { 1, 1, 0 };
            List<byte> list1 = new List<byte> { 1, 1, 0, 0 };
            List<byte> list2 = new List<byte> { 1, 0 };
            CollectionAssert.AreEqual(binar, DivideBinary(list1, list2));
        }

        [TestMethod]
        public void DivideBinary_12_3()
        {
            byte[] binar = { 1, 0, 0 };
            List<byte> list1 = new List<byte> { 1, 1, 0, 0 };
            List<byte> list2 = new List<byte> { 1, 1 };
            CollectionAssert.AreEqual(binar, DivideBinary(list1, list2));
        }

        [TestMethod]
        public void DivideBinary_13_2()
        {
            byte[] binar = { 1, 1, 0 };
            List<byte> list1 = new List<byte> { 1, 1, 0, 1 };
            List<byte> list2 = new List<byte> { 1, 0 };
            CollectionAssert.AreEqual(binar, DivideBinary(list1, list2));
        }

        [TestMethod]
        public void DivideBinary_127_15_6()
        {
            byte[] binar = { 1, 2 };
            List<byte> list1 = new List<byte> { 3, 3, 1 };
            List<byte> list2 = new List<byte> { 2, 3 };
            CollectionAssert.AreEqual(binar, DivideBinary(list1, list2, 6));
        }


        [TestMethod]
        public void GetAt_returns_the_reversed_index_position()
        {
            var list = new List<byte> { 2, 1, 0 };
            Assert.AreEqual(0, GetAt(list, 0));
            Assert.AreEqual(1, GetAt(list, 1));
            Assert.AreEqual(2, GetAt(list, 2));
            Assert.AreEqual(0, GetAt(list, 10));
        }

        [TestMethod]
        public void Factorial_49()
        {
            CollectionAssert.AreEqual(DecimalToBinary(49), DivideBinary(FactorialBinary(DecimalToBinary(49)), FactorialBinary(DecimalToBinary(48))));
        }



        private int GetAt(List<byte> list, int index)
        {
            return list.Count > index ? list[list.Count - 1 - index] : 0;
        }


        List<byte> DivideBinary(List<byte> a, List<byte> b, int radix = 2)
        {
            DeleteZeroToLists(a);
            DeleteZeroToLists(b);
            List<byte> resultList = new List<byte>();
            List<byte> contor = new List<byte>();
            List<byte> unit = new List<byte>() { 1 };
            while (GraterThan(SubstrBinary(a, resultList, radix),b)||Equal(SubstrBinary(a, resultList, radix), b))
            {
                resultList = AddBinary(b, resultList, radix);
                contor = AddBinary(contor, unit, radix);
            }
            return contor;
        }


        List<byte> FactorialBinary(List<byte> a)
        {
            DeleteZeroToLists(a);
            List<byte> resultList = new List<byte>() { 1 };
            List<byte> unit = new List<byte>() { 1 };
            for (var temp = unit; LessThan(temp, a)||Equal(temp, a); temp = AddBinary(temp, unit))
            {
                resultList = MultiplyBinary(resultList, temp);
            }
            return resultList;
        }


        List<byte> MultiplyBinary(List<byte> a, List<byte> b, int radix = 2)
        {
            DeleteZeroToLists(a);
            DeleteZeroToLists(b);
            List<byte> resultList = new List<byte>();
            List<byte> unit = new List<byte>(){ 1 };
            for (var temp = new List<byte>(); LessThan(temp, b); temp = AddBinary(temp, unit, radix))
            {
                resultList = AddBinary(resultList, a, radix);
            }
            return resultList;
        }


        bool NotEqual(List<byte> a, List<byte> b)
        {
            return LessThan(a, b) || LessThan(b, a);
        }

        bool Equal(List<byte> a, List<byte> b)
        {
            return !LessThan(a, b) && !LessThan(b, a);
        }
        
        bool GraterThan(List<byte> a, List<byte> b)
        {
            return LessThan(b, a);
        }
        
        bool LessThan(List<byte> a, List<byte> b)
        {
            DeleteZeroToLists(a);
            DeleteZeroToLists(b);
            if (a.Count != b.Count)
                return a.Count < b.Count;   
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                    return a[i] < b[i];      
            }
            return false;   
        }


        List<byte> MultiplyBinaryOld(List<byte> firstList, List<byte> secondList)
        {
            List<byte> tempList = new List<byte>();
            List<byte> resultList = new List<byte>();
            int temp = 0;
            int contor = -1;
            for (int i = secondList.Count - 1; i >= 0; i--)
            {
                contor = contor + 1;
                temp = contor;
                for (int j = firstList.Count - 1; j >= 0; j--)
                {
                    tempList.Add((byte)(secondList[i] * firstList[j]));
                }
                tempList.Reverse();
                while (temp > 0)
                {
                    tempList.Add(0);
                    temp--;
                }
                InsertZeroToLists(resultList, tempList);
                resultList = AddBinary(tempList, resultList);
                tempList.Clear();
            }
            DeleteZeroToLists(resultList);
            return resultList;
        }


        List<byte> SubstrBinary(List<byte> firstList, List<byte> secondList, int radix = 2) // consider that number1 is allways greater then number2
        {
            InsertZeroToLists(firstList, secondList);
            List<byte> resultList = new List<byte>();
            var carry = 0;
            for (int i = firstList.Count - 1; i >= 0; i--)
            {
                resultList.Add((byte)((firstList[i] < secondList[i]) ? (radix + firstList[i] + carry - secondList[i]) : (firstList[i] + carry - secondList[i])));
                carry = (firstList[i] < secondList[i]) ? -1 : 0;
            }
            resultList.Reverse();
            DeleteZeroToLists(resultList);
            return resultList;
        }


        List<byte> AddBinary(List<byte> firstList, List<byte> secondList, int radix = 2)
        {
            List<byte> resultList = new List<byte>();
            int carry = 0;
            var max = Math.Max(firstList.Count, secondList.Count);
            for (int i = 0; i < max; i++)
            {
                var result = GetAt(firstList, i) + GetAt(secondList, i) + carry;
                resultList.Add((byte)(result % radix));
                carry = result / radix;
            }
            resultList.Reverse();
            if (carry == 1)
                resultList.Insert(0, 1);
            return resultList;
        }


        List<byte> RightShift(List<byte> resultList, int noOfPositions)
        {
            while (noOfPositions > 0)
            {
                resultList.Insert(0, 0);
                noOfPositions --;
            }
            DeleteZeroToLists(resultList);
            return resultList;
        }


        List<byte> LeftShift(List<byte> resultList, int noOfPositions)
        {
            while (noOfPositions > 0)
            {
                resultList.Add(0);
                noOfPositions--;
            }
            DeleteZeroToLists(resultList);
            return resultList;
        }


        void InsertZeroToLists(List<byte> first, List<byte> second)
        {
            while (first.Count != second.Count)
            {
                if (first.Count < second.Count)
                    first.Insert(0, 0);
                else
                    second.Insert(0, 0);
            }
            return;
        }


        void DeleteZeroToLists(List<byte> first)
        {
            while (first.Count > 0)
            {
                if (first.First() == 0)
                    first.Remove(0);
                else
                    break;
            }
            return;
        }

        List<byte> And(List<byte> first, List<byte> second)
        {
            return AND_OR_XOR(first, second, 'a');
        }

        List<byte> AND_OR_XOR(List<byte> first, List<byte> second, char operation)
        {
            List<byte> result = new List<byte>();
            InsertZeroToLists(first, second);
            for (int i = 0; i < first.Count; i++)
            {
                result.Add(AndOrXor(operation, first[i], second[i]));
            }
            DeleteZeroToLists(result);
            return result;
        }

        private byte AndOrXor(char operation, byte a, byte b)
        {
            switch (operation)
            {
                case 'a':
                    return And(a, b);
                case 'o':
                    return Or(a, b);
                default:
                    return Xor(a, b);
            }
        }

        private byte Xor(byte a, byte b)
        {
            return (byte)(a != b ? 1 : 0);
        }

        private static byte And(byte a, byte b)
        {
            return (byte)(a == 1 && b == 1 ? 1 : 0);
        }

        private static byte Or(byte a, byte b)
        {
            return (byte)(a == 1 || b == 1 ? 1 : 0);
        }


        List<byte> NOT(List<byte> binarList)
        {
            for (int i = 0; i < binarList.Count; i++)
            {
                if (binarList[i] == 0)
                    binarList[i] = 1;
                else
                    binarList[i] = 0;
            }
            return binarList;
        }


        List<byte> DecimalToBinary(int number)
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
