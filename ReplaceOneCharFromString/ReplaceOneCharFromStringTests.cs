using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReplaceOneCharFromString
{
    [TestClass]
    public class ReplaceOneCharFromStringTests
    {
        [TestMethod]
        public void ShouldReplaceACharWithAString1()
        {
            string result = "Ana are mere";
            string input = "Ana are x";
            Assert.AreEqual(result, ReplaceOneCharFromString(input, 'x', "mere"));
        }

        [TestMethod]
        public void ShouldReplaceACharWithAString2()
        {
            string result = "Ana are mere si mere";
            string input = "Ana are x si x";
            Assert.AreEqual(result, ReplaceOneCharFromString(input, 'x', "mere"));
        }

        [TestMethod]
        public void ShouldReturnTheInputString()
        {
            string result = "Ana are x";
            string input = "Ana are x";
            Assert.AreEqual(result, ReplaceOneCharFromString(input, 'y', "mere"));
        }


        public string ReplaceOneCharFromString(string input, char toBeReplaced, string insteadOftoBeReplaced)
        {
            int index = input.IndexOf(toBeReplaced);
            if (index < 0)
                return input;
            return input.Substring(0, index) + insteadOftoBeReplaced +
                ReplaceOneCharFromString(input.Substring(index + 1), toBeReplaced, insteadOftoBeReplaced);
        }
    }
}
