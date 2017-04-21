using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingCart
{
    [TestClass]
    public class JuniorMindTests
    {
        [TestMethod]
        public void ShouldCalculateShoppingCartSum()
        {
            var shoppingCart = new ShoppingCart[] { new ShoppingCart("Tomatoes", 10), new ShoppingCart("Butter", 15) };
            Assert.AreEqual(25, CalculateTotalCartCost(shoppingCart));
        }

        [TestMethod]
        public void ShouldCalculateCheapestCartProduct()
        {
            var shoppingCart = new ShoppingCart[] { new ShoppingCart("Tomatoes", 10), new ShoppingCart("Butter", 15), new ShoppingCart("Potatoes", 5) };
            Assert.AreEqual("Potatoes", CalculateCheapestCartProduct(shoppingCart));
        }

        [TestMethod]
        public void ShouldCalculateAverageCartCost()
        {
            var shoppingCart = new ShoppingCart[] { new ShoppingCart("Tomatoes", 10), new ShoppingCart("Butter", 15), new ShoppingCart("Potatoes", 5) };
            Assert.AreEqual(10, CalculateAverageCartCost(shoppingCart));
        }

        [TestMethod]
        public void ShouldAddNewProductInCart()
        {
            var shoppingCart = new ShoppingCart[] { new ShoppingCart("Tomatoes", 10), new ShoppingCart("Butter", 15), new ShoppingCart("Potatoes", 5) };
            AddNewProductInCart(shoppingCart, "Oranges", 1);
            Assert.AreEqual("Oranges", shoppingCart[3].productName);
        }

        [TestMethod]
        public void ShouldDeleteFirstProductFromCart()
        {
            var shoppingCart = new ShoppingCart[] { new ShoppingCart("Tomatoes", 10), new ShoppingCart("Butter", 15), new ShoppingCart("Potatoes", 5) };
            var shoppingCartTest = new ShoppingCart[] { new ShoppingCart("Butter", 15), new ShoppingCart("Potatoes", 5) };
            DeleteFirstProductFromCart(shoppingCart);
            Assert.AreEqual("Butter", shoppingCart[0].productName);
        }


        public void DeleteFirstProductFromCart(ShoppingCart[] shoppingCart)
        {
            ShoppingCart[] shoppingCartNew = new ShoppingCart[shoppingCart.Length - 1];
            for (int i = 1; i < shoppingCart.Length; i++)
            {
                shoppingCartNew[i - 1] = shoppingCart[i];
            }
            shoppingCart = shoppingCartNew;

        }

        public void AddNewProductInCart(ShoppingCart[] shoppingCart, string name, double price)
        {

            ShoppingCart[] shoppingCartNew = new ShoppingCart[shoppingCart.Length + 1];

            for (int i = 0; i < shoppingCart.Length; i++)
            {
                shoppingCartNew[i] = shoppingCart[i];
            }
            shoppingCartNew[shoppingCartNew.Length - 1].productName = name;
            shoppingCartNew[shoppingCartNew.Length - 1].productCost = price;
            shoppingCart = shoppingCartNew;
        }



        double CalculateAverageCartCost(ShoppingCart[] shoppingCart)
        {
            double averageCost = 0;
            for (int i = 0; i < shoppingCart.Length; i++)
            {
                averageCost += shoppingCart[i].productCost;
            }
            return averageCost / shoppingCart.Length;
        }

        string CalculateCheapestCartProduct(ShoppingCart[] shoppingCart)
        {
            double cheapest = shoppingCart[0].productCost;
            int index = 0;
            for (int i = 1; i < shoppingCart.Length; i++)
            {
                if (shoppingCart[i].productCost < cheapest)
                    cheapest = shoppingCart[i].productCost;
                    index = i;
            }
            return shoppingCart[index].productName;
        }


        double CalculateTotalCartCost(ShoppingCart[] shoppingCart)
        {
            double sum = 0;
            for (int i = 0; i < shoppingCart.Length; i++)
            {
                sum += shoppingCart[i].productCost;
            }
            return sum;
        }   
    }


        public struct ShoppingCart{
            public string productName;
            public double productCost;

            public ShoppingCart(string productName, double productCost)
            {
                this.productName = productName;
                this.productCost = productCost;


            }
        }

}






