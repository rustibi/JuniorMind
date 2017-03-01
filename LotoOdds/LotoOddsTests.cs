using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace LotoOdds
{
    [TestClass]
    public class LotoOddsTests
    {
         [TestMethod]
         public void SixWinningNumbers649()
         {
             Assert.AreEqual(1/13983816, CalculateLotoOdds(6, 6, 49));

         }


         [TestMethod]
         public void FiveWinningNumbers649()
         {
             Assert.AreEqual(1/54201, CalculateLotoOdds(5, 6, 49));

         }
         

        [TestMethod]
        public void FactorialFunction()
        {
            Assert.AreEqual(720, Fact(6));
        }


        [TestMethod]
        public void FactorialDif()
        {
            Assert.AreEqual(10068347520, DifFact(49, 6));

        }

        [TestMethod]
        public void FiveWinningNumbers540()
        {
            Assert.AreEqual(1/658008, CalculateLotoOdds(5, 5, 40));

        }





        long CalculateLotoOdds(int winNo, int catNum, int catDen)
        // returneaza sansele de castig in functie de joc si numere castigatoare
        // winNo - numere castigatoare
        // catNum - numere maxim castigatoare din catDen
        // catDen - toate numere care se joaca
        {
            return (Fact(catNum) * DifFact(catNum, winNo) * DifFact((catDen-catNum), (catNum-winNo)))/(DifFact(catDen, catNum)*Fact(catNum-winNo)*2);
        }

  
       
       
        long DifFact(int number1, int number2)
        //returneaza factorial din number1 pana la diferenta dintre number1-number2, exclusiv
        {
            long result = 1;
            int total = number1 - number2;
            if (total == number1)
                result = 1;
            while (number1 > total)
            {
                result *= number1;
                number1--;
            }
            return result;
        }

        
        long Fact (int number)
        //returneaza factorial dintr-un numar
        {
            int fact = 1;
        if (number == 0)
            fact = 1; 

        while (number > 0) {
            fact = fact * number;
            number--; 
            }
        return fact;
        }
    }
}
