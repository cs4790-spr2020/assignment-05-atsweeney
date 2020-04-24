using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_InMemory_UnitTests 
    {
        //Attributes
         private UserAdapter harness;


        //Constructor
         public UserAdapter_InMemory_UnitTests()
        {
            this.harness = new UserAdapter(new InMemory());
        }


        //Methods
        [TestMethod]
        public void TestAddAndGetAllUsers()
        {
            //Arrange
            this.harness.Add(new User("tester1@example.com"));
            this.harness.Add(new User("tester2@example.com"));
            this.harness.Add(new User("tester3@example.com"));
            this.harness.Add(new User("tester4@example.com"));
            
            //Act
            ArrayList allUsers = (ArrayList)this.harness.GetAll();

            //Assert
            Assert.AreEqual(4, allUsers.Count);
        }

        [TestMethod]
        public void TestUserUpdate()
        {
            //Arrange
            User user = new User("tester@example.com");
            this.harness.Add(user);

            //Act
            user.ChangeEmail("newTester@example.com");
            this.harness.Update(user);

            //Assert
            Assert.AreEqual(user.Email, this.harness.GetById(user.Id).Email);
        }

        [TestMethod]
        public void TestReadByUserID()
        {
            //Arrange
            User user = new User("tester@example.com");
            this.harness.Add(user);

            //Act
            User actual = this.harness.GetById(user.Id);

            //Assert
            Assert.AreEqual(user.Email, actual.Email);
        }
    }
}
