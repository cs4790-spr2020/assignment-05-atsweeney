using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using BlabberApp.Services;

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class UserServiceTest
    {
        private UserServiceFactory _userServiceFactory = new UserServiceFactory();

        [TestMethod]
        public void TestCanary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void GetAllEmptyTest()
        {
            //Arrange
            UserService userService = _userServiceFactory.CreateUserService();
            ArrayList expected = new ArrayList();
            //Act
            IEnumerable actual = userService.GetAll();
            //Assert
            Assert.AreEqual(expected.Count, (actual as ArrayList).Count);
        }

        [TestMethod]
        public void TestCreateUser()
        {
            UserService userService = _userServiceFactory.CreateUserService();

            User expected = userService.CreateUser("tester@example.com");
            
            Assert.IsTrue(expected is User);
        }

        [TestMethod]
        public void AddNewUserSuccessTest()
        {
            //Arrange
            string email = "user@example.com"; 
            UserService userService = _userServiceFactory.CreateUserService();
            User expected = userService.CreateUser(email);
            userService.AddNewUser(email);
            //Act
            User actual = userService.FindUser(email);
            //Assert
            Assert.AreEqual(expected.Email, actual.Email);
        }

        [TestMethod]
        public void TestUserDoesNotMatch()
        {
            //Arrange
            string email = "user@example.com"; 
            UserService userService = _userServiceFactory.CreateUserService();
            userService.AddNewUser("tester@example.com");

            //Act
            User actual = userService.FindUser("tester@example.com");
            
            //Assert
            Assert.AreNotEqual(email, actual.Email);
        }

        [TestMethod]
        public void GetAll()
        {
            UserService userService = _userServiceFactory.CreateUserService();
            userService.AddNewUser("tester1@example.com");
            userService.AddNewUser("tester2@example.com");
            userService.AddNewUser("tester3@example.com");
            
            //Act
            IEnumerable users = userService.GetAll();
            
            //Assert
            Assert.AreEqual(3, (users as ArrayList).Count);
        }
        
    }
}
