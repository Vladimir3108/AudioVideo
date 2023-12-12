using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Tests
{
    [TestClass()]
    public class UserTestTests
    {
        [TestMethod()]
        public void ValidatedUserTest()
        {
            string Password = "password";
            string Login = "feofan2003";
            bool assert = UserTest.ValidatedUser(Login, Password);
            Assert.IsFalse(assert);
        }
        [TestMethod()]
        public void ValidatedUserTest2()
        {
            string Password = "65603";
            string Login = "feofan2003";
            bool assert = UserTest.ValidatedUser(Login, Password);
            Assert.IsTrue(assert);
        }
        [TestMethod()]
        public void ValidatedUserTest3()
        {
            string Password = "";
            string Login = "feofan2003";
            bool assert = UserTest.ValidatedUser(Login, Password);
            Assert.IsFalse(assert);
        }
        [TestMethod()]
        public void ValidatedUserTest4()
        {
            bool click_on = true;

            bool actual = UserTest.ValidateBack(click_on);
            Assert.IsTrue(actual);
        }
    }
}