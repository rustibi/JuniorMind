using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

        [TestMethod]
        public void CalculateFactFrequencyProductForThreeSameLetters()
        {
            Assert.AreEqual(6, CalculateFactFrequencyProduct("severe"));
        }



        int CalculateFactFrequencyProduct(string word)
        {
            //int count = 0;
            int finalCount = 1;
            string dictionary = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < dictionary.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < word.Length; j++)
                {
                    if (dictionary[i] == word[j])
                    {
                        count += 1;
                        finalCount = finalCount * count;

                    } 
                }
            }
           
         return finalCount;
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


