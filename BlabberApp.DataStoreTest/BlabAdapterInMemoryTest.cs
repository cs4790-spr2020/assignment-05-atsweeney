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
    public class BlabAdapter_InMemory_UnitTests
    {
        //Attributes
         private BlabAdapter harness;


        //Constructor
         public BlabAdapter_InMemory_UnitTests()
        {
            this.harness = new BlabAdapter(new InMemory());
        }


        //Methods
        [TestMethod]
        public void TestGetByUserID()
        {
            //Arrange
            User user = new User("tester@example.com");
            Blab expected = new Blab("I'm a blab", user);
            expected.DTTM = System.DateTime.Now;
            this.harness.Add(expected);

            //Act
            Blab actual = (Blab)this.harness.GetByUserId("tester@example.com");

            //Assert
            Assert.AreEqual(actual, null);
            Assert.IsTrue(expected.IsValid());
        }
    }
}
