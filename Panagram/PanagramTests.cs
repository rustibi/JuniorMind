using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panagram
{
    [TestClass]
    public class PanagramTests
    {
        [TestMethod]
        public void CheckTruePanagram()
        {
            Assert.AreEqual(true, CalculatePanagram("the quick brown fox jumps over the lazy dog"));
        }

        [TestMethod]
        public void CheckFalsePanagram()
        {
            Assert.AreEqual(false, CalculatePanagram("the quic brown fox jumps over the lazy dog"));
        }



        bool CalculatePanagram(string IsPanagram)
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

            return (count == 26 ? true : false);

        }

       

        
    }
}
