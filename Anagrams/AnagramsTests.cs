using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams
{
    [TestClass]
    public class AnagramsTests
    {
        [TestMethod]
        public void TwoLettersWord()
        {
            Assert.AreEqual(2, CalculateAnagram("no"));
        }

        [TestMethod]
        public void ThreeLettersWord()
        {
            Assert.AreEqual(6, CalculateAnagram("yes"));
        }

        [TestMethod]
        public void FourLettersWord()
        {
            Assert.AreEqual(24, CalculateAnagram("sure"));
        }

       


        int CalculateAnagram(string anagram)
        {
            int countAnagrams = 1;
            int length = anagram.Length;
            while (length >= 1) 
            {
                countAnagrams *= length;
                length -= 1;

            }
            return countAnagrams;
            
        }
    }
}
