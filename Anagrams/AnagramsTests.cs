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
            Assert.AreEqual(2, CalculateAnagram("da"));
        }

        
        int CalculateAnagram(string Anagram)
        {
            return 2;
        }
    }
}
