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
        private BlabAdapter _harness;
        private User _user = new User("foobar@example.com");
        private string _message = "Now is the time for, blabs...";

        [TestInitialize]
        public void Setup()
        {
            _harness = new BlabAdapter(new MySqlBlab());
            _harness.RemoveAll();
        }
        [TestCleanup]
        public void TearDown()
        {
            User user = new User("foobar@example.com");
            _harness.RemoveAll();
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
            Blab blab = new Blab(_message, _user);
            //Act
            _harness.Add(blab);
            ArrayList actual = (ArrayList)_harness.GetByUserId(_user.Email);
            //Assert
            Assert.AreEqual(1, actual.Count);
        }
        [TestMethod]
        public void TestAddAndGetAll()
        {
            //Arrange
            Blab blab = new Blab(_message, _user);
            User mockUser = new User("testme@test.net");
            Blab blabTwo = new Blab(_message, mockUser);
            //Act
            _harness.Add(blab);
            _harness.Add(blabTwo);
            ArrayList actual = (ArrayList)_harness.GetAll();
            //Assert
            Assert.AreEqual(2, actual.Count);
        }
        [TestMethod]
        public void TestReadById()
        {
            //Arrange
            Blab blab = new Blab(_message, _user);
            //Act
            _harness.Add(blab);
            Blab actual = _harness.GetById(blab.Id);
            //Assert
            Assert.AreEqual(blab.Id.ToString(), actual.Id.ToString());
        }
        [TestMethod]
        public void TestBlabUpdate()
        {
            //Arrange
            Blab blab = new Blab(_message, _user);
            //Act
            _harness.Add(blab);
            blab.Message = "This is a new message";
            _harness.Update(blab);
            ArrayList actual = (ArrayList)_harness.GetByUserId(_user.Email);
            Blab mockBlab = (Blab)actual[0];
            //Assert
            Assert.AreEqual(blab.Message.ToString(), mockBlab.Message.ToString());
        }
        [TestMethod]
        public void TestBlabDelete()
        {
            //Arrange
            BlabAdapter actual = _harness;
            Blab blab = new Blab(_message, _user);
            //Act
            _harness.Add(blab);
            _harness.Remove(blab);
            //Assert
            Assert.AreEqual(_harness.ToString(), actual.ToString());
        }
        [TestMethod]
        public void TestRemoveAll()
        {
            //Arrange
            BlabAdapter actual = _harness;
            Blab blab = new Blab(_message, _user);
            User mockUser = new User("testme@test.net");
            Blab blabTwo = new Blab(_message, mockUser);
            //Act
            _harness.Add(blab);
            _harness.Add(blabTwo);
            _harness.RemoveAll();
            //Assert
            Assert.AreEqual(_harness.ToString(), actual.ToString());
        }
    }
}
