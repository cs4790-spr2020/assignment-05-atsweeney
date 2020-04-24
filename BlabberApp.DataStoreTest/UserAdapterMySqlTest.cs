using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_MySql_UnitTests
    {
        //Attributes
        private User user;
        private UserAdapter harness;
        private readonly string email = "tester@example.com";

        //Setup and TearDown
        [TestInitialize]
        public void Setup()
        {
            this.user = new User(this.email);
            this.harness = new UserAdapter(new MySqlUser());
            this.harness.RemoveAll();
        }

        [TestCleanup]
        public void TearDown()
        {
            User user = new User(this.email);
            this.harness.RemoveAll();
        }

        //Methods
        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetUser()
        {
            //Arrange
            this.user.RegisterDTTM =DateTime.Now;
            this.user.LastLoginDTTM = DateTime.Now;

            //Act
            this.harness.Add(this.user);
            User actual = this.harness.GetById(this.user.Id);

            //Assert
            Assert.AreEqual(this.user.Id, actual.Id);
        }

        [TestMethod]
        public void TestAddAndGetAll()
        {
            //Arrange
            this.user.RegisterDTTM =DateTime.Now;
            this.user.LastLoginDTTM = DateTime.Now;
            this.harness.Add(this.user);

            //Act
            ArrayList users = (ArrayList)this.harness.GetAll();
            User actual = (User)users[0];

            //Assert
            Assert.AreEqual(this.user.Id.ToString(), actual.Id.ToString());
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            //Arrange
            this.user = new User(this.email);
            this.harness.Add(user);

            //Act
            this.harness.Remove(this.user);
            ArrayList users = (ArrayList)this.harness.GetAll();

            //Assert
            Assert.AreEqual(0, users.Count);        
        }

        [TestMethod]
        public void TestReadByEmail()
        {
            //Arrange
            this.user = new User(this.email);
            this.harness.Add(this.user);

            //Act
            User actual = this.harness.GetByEmail(this.email);

            //Assert
            Assert.AreEqual(this.user.Email, actual.Email);
        }

        [TestMethod]
        public void TestReadByID()
        {
            //Arrange
            this.user = new User(this.email);
            this.harness.Add(this.user);

            //Act
            User actual = this.harness.GetById(this.user.Id);

            //Assert
            Assert.AreEqual(this.user.Email, actual.Email);
        }

        [TestMethod]
        public void TestUserUpdate()
        {
            //Arrange
            this.user = new User(this.email);
            this.harness.Add(user);

            //Act
            this.user.ChangeEmail("tester2@example.com");
            this.harness.Update(this.user);
            User actual = this.harness.GetById(this.user.Id);

            //Assert
            Assert.AreEqual(this.user.Email, actual.Email);
        }
    }
}
