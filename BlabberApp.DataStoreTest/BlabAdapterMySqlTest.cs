using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabAdapter_MySql_UnitTests
    {
        private BlabAdapter harness;

        [TestInitialize]
        public void Setup()
        {
            this.harness = new BlabAdapter(new MySqlBlab());
            this.harness.RemoveAll();
        }

        [TestCleanup]
        public void TearDown()
        {
            this.harness.RemoveAll();
        }

        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetBlab()
        {
            //Arrange
            string email = "tester@example.com";
            User mockUser = new User(email);
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            
            //Act
            this.harness.Add(blab);
            ArrayList actual = (ArrayList)this.harness.GetByUserId(email);
            
            //Assert
            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void TestAddAndRemoveBlab()
        {
            //Arrange
            string email = "tester@example.com";
            User mockUser = new User(email);
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            this.harness.Add(blab);

            //Act
            this.harness.Remove(blab);
            ArrayList allBlabs = (ArrayList)this.harness.GetAll();
            
            //Assert
            Assert.AreEqual(0, allBlabs.Count);
        }

        [TestMethod]
        public void TestReadByID()
        {
            //Arrange
            string email = "tester@example.com";
            User mockUser = new User(email);
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            this.harness.Add(blab);

            //Act
            Blab actual = this.harness.GetById(blab.Id);
            
            //Assert
            Assert.AreEqual(blab.Id, actual.Id);
        }

        [TestMethod]
        public void TestReadByEmail()
        {
            //Arrange
            string email = "tester@example.com";
            User mockUser = new User(email);
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            this.harness.Add(blab);
            this.harness.Add(blab);
            this.harness.Add(blab);
            this.harness.Add(blab);

            //Act
            ArrayList actual = (ArrayList)this.harness.GetByUserId(mockUser.Email);

            //Assert
            Assert.AreEqual(4, actual.Count);
        }

        [TestMethod]
        public void TestBlabUpdate()
        {
            //Arrange
            string email = "tester@example.com";
            User mockUser = new User(email);
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            this.harness.Add(blab);

            //Act
            string message = "I'm saying something new!";
            blab.Message = message;
            this.harness.Update(blab);
            Blab updated = this.harness.GetById(blab.Id);

            //Assert
            Assert.AreEqual(blab.Id, updated.Id);
            Assert.AreEqual(blab.Message, blab.Message);
        }

        [TestMethod]
        public void TestGetAllBlabs()
        {
            //Arrange
            string email = "tester@example.com";
            User mockUser = new User(email);
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            this.harness.Add(blab);
            this.harness.Add(blab);
            this.harness.Add(blab);
            this.harness.Add(blab);

            //Act
            ArrayList actual = (ArrayList)this.harness.GetAll();

            //Assert
            Assert.AreEqual(4, actual.Count);
        }
    }
}
