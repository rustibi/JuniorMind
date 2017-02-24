using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panagram
{
    [TestClass]
    public class PanagramTests
    {
        [TestMethod]
        public void CountEqualLetters()
        {
            Assert.AreEqual(26, CalculatePanagram("the quick brown fox jumps over the lazy dog"));
        }

        int CalculatePanagram(string IsPanagram)
        {
            string dictionary = "abcdefghijklmnopqrstuvwxyz";
            int count = 0;
      
            for (int i = 0; i < dictionary.Length; i++)
            {
                for (int j = 0; j < IsPanagram.Length; j++)
                {
                    if (dictionary[i] == IsPanagram[j])
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;

        }


    }
}
