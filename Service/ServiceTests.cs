using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void ShouldReturnSorted()
        {
            Case[] cases = new Case[] { new Case("Volvo", Priority.Low),
                                        new Case("Saab", Priority.High),
                                        new Case("Audi", Priority.Medium),
                                        new Case("Scania", Priority.Medium) };
            Case[] result = new Case[] { new Case("Saab", Priority.High),
                                         new Case("Audi", Priority.Medium),
                                         new Case("Scania", Priority.Medium),
                                         new Case("Volvo", Priority.Low) };
            CollectionAssert.AreEqual(result, Sort (cases));
        }


        public enum Priority
        {
            Low = 3,
            Medium = 2,
            High = 1
        }

        public struct Case
        {
            public string name;
            public Priority priority;
            public Case (string name, Priority priority)
            {
                this.name = name;
                this.priority = priority;
            }
        }

        public Case[] Sort (Case[] cases)
        {
            
            for (int i = 0; i < cases.Length; i++)
            {
                for (int j = 0; j < cases.Length-1; j++)
                {
                    if (cases[j].priority > cases[j + 1].priority)
                    {
                        var temp = cases[j];
                        cases[j] = cases[j + 1];
                        cases[j + 1] = temp;
                    }
                }   
            }
            return cases;
        }
        



    }
}
