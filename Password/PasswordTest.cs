using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Password
{
    [TestClass]
    public class PasswordTest
    {
        [TestMethod]
        public void GeneratePasswordTest1()
        {
            Assert.AreEqual("abc", GeneratePassword(3));
        }


        string GeneratePassword(int x)
        {
            string valid = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789!@$?_-";
            char[] result = new char[x];
            Random random = new Random();
            for (int i = 0; i < x; i ++)
            {
                result[i] = valid[random.Next(valid.Length)];

            }
            return new string(result);
                
        }



    }
}
