using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderWordsByFrequency
{
    [TestClass]
    public class OrderWordsByFrequencyTests
    {
        [TestMethod]
        public void ShouldReturnAnArrayStructGroupedByWordFrequency()
        {
            var text = "ana are mere si pere si mere si prune si mere si pere";
            var function = FindOutWordFrequency(text);
            Frequency[] result = {  new Frequency("ana", 1),
                                    new Frequency("are", 1),
                                    new Frequency("mere", 3),
                                    new Frequency("si", 5),
                                    new Frequency("pere", 2),
                                    new Frequency("prune", 1) };
            CollectionAssert.AreEqual(result, function);
        }

        [TestMethod]
        public void ShouldReturnASortedArrayByAppearance()
        {
            var text = "ana are mere si pere si mere si prune si mere si pere";
            var function = Sort(text);
            Frequency[] result = {  new Frequency("si", 5),
                                    new Frequency("mere", 3),
                                    new Frequency("pere", 2),
                                    new Frequency("ana", 1),
                                    new Frequency("are", 1),
                                    new Frequency("prune", 1) };
            CollectionAssert.AreEqual(result, function);
        }






        public struct Frequency
        {
            public string word;
            public int frequency;
            public Frequency(string word, int frequency)
            {
                this.word = word;
                this.frequency = frequency;
            }


        } 

        public Frequency[] FindOutWordFrequency(string text)
        {
            string[] word = text.Split(' ');
            Frequency[] list = new Frequency[0];
            
            string[] keepUnicWordsFromWord = new string[word.Length];
            int FrequencyListCounter = -1;

            for (int i = 0; i < word.Length-1; i++)
            {
                int unic = Array.IndexOf(keepUnicWordsFromWord, word[i]);
                if (unic == -1)
                {
                    keepUnicWordsFromWord[i] = word[i];
                    FrequencyListCounter++;
                    int counter = 1;
                    for (int j = i + 1; j < word.Length; j++)
                    {
                        if (word[i] == word[j])
                        {
                            counter++;
                        }
                        else
                            continue;
                    }
                    Array.Resize(ref list, list.Length + 1);
                    list[FrequencyListCounter] = new Frequency(word[i], counter);
                    
                }
                
            }
            return list; 
        }


        public Frequency[] Sort (string text)
        {
            Frequency[] list = FindOutWordFrequency(text);
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 0; j < list.Length - 1; j++)
                {
                    if (list[j].frequency < list[j + 1].frequency)
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
            return list;
        }
    }



    }

