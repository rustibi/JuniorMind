using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Collections.Generic;

namespace Password
{
    [TestClass]
    public class PasswordTest
    {
        [TestMethod]
        public void GenerateChar_a()
        {
            Assert.AreEqual('a', GenerateChar('a', 'b'));
        }

        [TestMethod]
        public void GenerateStringTestWithoutSimilarChars()
        {
            Assert.AreEqual("aa", GenerateString(2, 'a', 'b', true));
        }

        [TestMethod]
        public void GenerateStringLengthTest()
        {
            Assert.AreEqual(2, GenerateString(2, 'a', 'b', false).Length);
        }

        [TestMethod]

        public void GenerateSymbolsLengthTest()
        {
            Assert.AreEqual(3, GenerateSymbols(3, true).Length);
        }

        [TestMethod]
        public void GeneratePasswordLengthTest()
        {
            Password password = new Password(3, 3, 3, 3, true, true);
            Assert.AreEqual(12, GetPassword(password).Length);
        }

        [TestMethod]
        public void CountElements()
        {
            List<int> results = new List<int> { 3, 3, 3, 3 };
            var a = CountElements("strSTR123$$$");
            CollectionAssert.AreEqual(results, a);
        }

        [TestMethod]
        public void GeneratePasswordLengthTestforEachCategory()
        {
            Password password = new Password(3, 4, 5, 6, false, false);
            List<int> results = new List<int> { 3, 4, 5, 6 };
            string result = GetPassword(password);
            var a = CountElements(result);
            CollectionAssert.AreEqual(results, a);
        }



        List<int> CountElements(string password)
        {
            int countUpper = 0, countLower = 0, countNumber = 0, countSymbols = 0;
            List<int> results = new List<int>();
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsLower(password[i]))
                {
                    countLower++;
                }
                else if (char.IsUpper(password[i]))
                {
                    countUpper++;
                }
                else if (char.IsNumber(password[i]))
                {
                    countNumber++;
                }
                else
                {
                    countSymbols++;
                }
            }
            results.Add(countLower);
            results.Add(countUpper);
            results.Add(countNumber);
            results.Add(countSymbols);
            return results;
        }



        Random random = new Random();
        public char GenerateChar(char start, char end)
        {
            return (char)random.Next(start, end);
        }



        public string GenerateString(int count, char start, char end, bool ignoreSimilarChars)
        {
            char[] result = new char[count];
            string similarChars = "l1Io0O";

            int i = 0;
            while (i < count)
            {
                var randomChar = GenerateChar(start, end);
                if (!ignoreSimilarChars || !similarChars.Contains(randomChar.ToString()))
                    result[i++] = randomChar;
            }
            return new string(result);
        }



        public string GenerateSymbols(int count, bool ignoreAmbigChars)
        {
            char[] result = new char[count];
            string allSymbols = "?!@#$%^&*_+=-|\";:/.>,<~`()\\[{]}'";
            string acceptedSymbols = "?!@#$%^&*_+=-|";
            int i = 0;
            while (i < count)
            {
                result[i++] = ignoreAmbigChars
                    ? acceptedSymbols[random.Next(0, acceptedSymbols.Length - 1)]
                    : allSymbols[random.Next(0, allSymbols.Length - 1)];
            }
            return new string(result);
        }



        string GetPassword(Password password)
        {
            string pass = null;
            pass = pass + GenerateString(password.lowerCaseNo, 'a', 'z', password.ignoreSimilarChars);
            pass = pass + GenerateString(password.upperCaseNo, 'A', 'Z', password.ignoreSimilarChars);
            pass = pass + GenerateString(password.numbersNo, '0', '9', password.ignoreSimilarChars);
            pass = pass + GenerateSymbols(password.symbolsNo, password.ignoreAmbigChars);
            return pass;
        }


        public struct Password
        {
            public int lowerCaseNo;
            public int upperCaseNo;
            public int numbersNo;
            public int symbolsNo;
            public bool ignoreSimilarChars;
            public bool ignoreAmbigChars;
            public Password(int lowerCase, int upperCase, int numbers, int symbols, bool ignoreSimilar, bool ignoreAmbig)
            {
                this.lowerCaseNo = lowerCase;
                this.upperCaseNo = upperCase;
                this.numbersNo = numbers;
                this.symbolsNo = symbols;
                this.ignoreSimilarChars = ignoreSimilar;
                this.ignoreAmbigChars = ignoreAmbig;
            }
        }
    }
}
