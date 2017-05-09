using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reverse_String
{
    [TestClass]
    public class Reverse_StringTests
    {
        [TestMethod]
        public void ShouldReverseString3letters()
        {
            Assert.AreEqual("cba", ReverseString("abc"));
        }

        [TestMethod]
        public void ShouldReverseString6letters()
        {
            Assert.AreEqual("fedcba", ReverseString("abcdef"));
        }

        string ReverseString (string toReverse)
        {
            string reversed = null;
            if (toReverse.Length == 0)
                return reversed;
            return toReverse[toReverse.Length-1] + ReverseString(toReverse.Substring(0, toReverse.Length-1));
        }
    }
}
