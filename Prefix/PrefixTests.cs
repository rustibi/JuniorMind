using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Prefix
{
    [TestClass]
    public class PrefixTests
    {
        [TestMethod]
        public void CalculatePrefix1()
        {
            Assert.AreEqual("aa", ComparePrefix("aab", "aac"));
        }


        [TestMethod]
        public void CalculatePrefix2()
        {
            Assert.AreEqual("aac", ComparePrefix("aacb", "aac"));
        }


        string ComparePrefix(string a, string b)
        {
            //var builder = new StringBuilder();
            string builder = "";
            for (int i = 0; i < CompareStringsLength(a, b).Length-1; i++)
            {
                if (a[i] == b[i])
                    builder = builder + (CompareStringsLength(a, b)[i]);
                else
                    break;
            }
            return builder;


        }
        
        string CompareStringsLength(string a, string b)
        {
            return (a.Length > b.Length) ? a : b;
        }              
   }
}
    

