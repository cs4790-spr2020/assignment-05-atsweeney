using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class BlabTest
    {       
        private Blab harness;
        public BlabTest() 
        {
            harness = new Blab();
        }
        [TestMethod]
        public void TestSetGetMessage()
        {
            // Arrange
            string expected = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."; 
            harness.Message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
            // Act
            string actual = harness.Message;
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestId()
        {
            // Arrange
            Guid expected = harness.Id;
            // Act
            Guid actual = harness.Id;
            // Assert
            Assert.AreEqual(actual, expected);
        }
        
        [TestMethod]
        public void TestDTTM()
        {
            // Arrange
            Blab Expected = new Blab();
            // Act
            Blab Actual = new Blab();
            // Assert
            Assert.AreEqual(Expected.DTTM.ToString(), Actual.DTTM.ToString());
        }

        [TestMethod]
        public void TestConstructorWithMessage()
        {
            Blab blab = new Blab("Message 1");

            Assert.AreEqual(blab.Message, "Message 1");
        }

        [TestMethod]
        public void TestConstructorWithUser()
        {
            User user = new User("tester@example.com");
            Blab blab = new Blab(user);

            Assert.AreEqual(blab.User.Email, "tester@example.com");
        }

        [TestMethod]
        public void TestConstructorWithUserAndBlab()
        {
            User user = new User("tester@example.com");
            Blab blab = new Blab("blab blab blab", user);
            Assert.AreEqual(blab.User.Email, "tester@example.com");
            Assert.AreEqual(blab.Message, "blab blab blab");
        }

        [TestMethod]
        public void TestConstructorWithString()
        {
            Blab blab = new Blab("This is a blab");
            Assert.AreEqual(blab.Message, "This is a blab");
        }
    }
}
