using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models.Tests
{
    [TestClass()]
    public class RomanNumberExtendTests
    {
        [TestMethod()]
        public void RomanNumberExtendTest()
        {
            RomanNumberExtend num = new("XV");
            int expected = 15;
            Assert.AreEqual(expected, num.ToInt());
        }
        [TestMethod()]
        public void RomanNumberExtendTest2()
        {
            RomanNumberExtend num = new("XXXIV");
            int expected = 34;
            Assert.AreEqual(expected, num.ToInt());
        }
        [TestMethod()]
        public void RomanNumberExtendTestWrong()
        {
            RomanNumberExtend num;
            Assert.ThrowsException<RomanNumberException>(() => num = new("XXXXIV"));
        }
        [TestMethod()]
        public void RomanNumberExtendTestWrong2()
        {
            RomanNumberExtend num;
            Assert.ThrowsException<RomanNumberException>(() => num = new("IVX"));
        }
    }
}