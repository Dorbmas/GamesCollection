using Microsoft.VisualStudio.TestTools.UnitTesting;
using GamesCollection.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCollection.Classes.Tests
{
    [TestClass()]
    public class LoginPasswordCheckerTests
    {
        [TestMethod()]
        public void ValidateUserTestLength()
        {
            string login = "kirillov1";
            string password = "123456";

            bool actual = LoginPasswordChecker.ValidateUserLength(login, password);

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void ValidateUserTestTrue()
        {
            string login = "kirillov1";
            string password = "123456";

            bool actual = LoginPasswordChecker.ValidateUserLoginPassword(login, password);

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void ValidateUserTestIsLower()
        {
            string login = "kirillov1";
            string password = "123456";

            bool actual = LoginPasswordChecker.ValidateUserIsLower(login, password);

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void ValidateUserTestIsUpper()
        {
            string login = "kirillov1";
            string password = "123456";

            bool actual = LoginPasswordChecker.ValidateUserIsUpper(login, password);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void ValidateGamesAddEditRating()
        {
            float rating = 5.7f;

            bool actual = LoginPasswordChecker.ValidateGamesAddEdit(rating);

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void ValidateBackTrue()
        {
            bool click = true;

            bool actual = LoginPasswordChecker.ValidateBack(click);

            Assert.IsTrue(actual);
        }
    }
}