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
            Assert.AreEqual((10068347520), DifFact(49, 6));

        }





        long CalculateLotoOdds(int winNo, int catNum, int catDen)
        {
            //return (Comb(winNo, catNum)*Comb((catNum - winNo),(catDen - winNo)))/(Comb(catNum, catDen));
            return (Fact(catNum) * DifFact(catNum, winNo) * DifFact((catDen-catNum), (catNum-winNo)))/(DifFact(catDen, catNum)*Fact(catNum-winNo)*2);

        }

  
       
       
        long DifFact(int number1, int number2)
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
