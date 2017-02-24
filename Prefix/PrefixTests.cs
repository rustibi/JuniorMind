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



      
        string ComparePrefix(string a, string b)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i])
                    builder.Append(a[i]);
                else
                    break;
            }
            return builder.ToString();
                        
         }              
   }
}
    

