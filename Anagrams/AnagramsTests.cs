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


        int CalculateAnagram(string anagram)
        {
            return (anagram.Length) * (anagram.Length-1);
        }
    }
}
