using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using System;
using System.Collections;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_InMemory_UnitTests 
    {
        private InMemory _harness = new InMemory();

        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddUser()
        {
            //Arrange
            User user = new User("test@example.com");
            //Act
            _harness.Create(user);
            User actual = (User)_harness.ReadByUserEmail(user.Email);
            //Assert
            Assert.AreEqual(user.ToString(), actual.ToString());
        }
        [TestMethod]
        public void TestAddBlab()
        {
            //Arrange
            User user = new User("test@example.com");
            Blab blab = new Blab("this is a blab",user);
            //Act
            _harness.Create(blab);
            Blab actual = (Blab)_harness.ReadById(blab.Id);
            //Assert
            Assert.AreEqual(blab.ToString(), actual.ToString());
        }
        [TestMethod]
        public void TestCreaateAndReadAll()
        {
            //Arrange
            User user = new User("test@example.com");
            Blab blab = new Blab("this is a blab",user);
            //Act
            _harness.Create(blab);
            _harness.Create(user);
            ArrayList actual = (ArrayList)_harness.ReadAll();
            //Assert
            Assert.AreEqual(2, actual.Count);
        }
        [TestMethod]
        public void TestReadById()
        {
            //Arrange
            User user = new User("test@example.com");
            //Act
            _harness.Create(user);
            User actual = (User)_harness.ReadById(user.Id);
            //Assert
            Assert.AreEqual(user.Id.ToString(), actual.Id.ToString());
        }
        [TestMethod]
        public void TestReadByUserEmail()
        {
            //Arrange
            User user = new User("test@example.com");
            //Act
            _harness.Create(user);
            User actual = (User)_harness.ReadByUserEmail(user.Email);
            //Assert
            Assert.AreEqual(user.Email.ToString(), actual.Email.ToString());
        }
        [TestMethod]
        public void TestUserUpdate()
        {
            //Arrange
            User user = new User("test@example.com");
            //Act
            _harness.Create(user);
            user.ChangeEmail("foobar@test.net");
            _harness.Update(user);
            User actual = (User)_harness.ReadByUserEmail(user.Email);
            //Assert
            Assert.AreEqual(user.Email.ToString(), actual.Email.ToString());
        }
        [TestMethod]
        public void TestBlabUpdate()
        {
            //Arrange
            User user = new User("test@example.com");
            Blab blab = new Blab("this is a blab",user);
            //Act
            _harness.Create(blab);
            blab.Message = "new message";
            _harness.Update(blab);
            Blab actual = (Blab)_harness.ReadById(blab.Id);
            //Assert
            Assert.AreEqual(blab.Message.ToString(),actual.Message.ToString());
        }
        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            User user = new User("test@example.com");
            InMemory actual = _harness;
            //Act
            _harness.Create(user);
            _harness.Delete(user);
            //Assert
            Assert.AreEqual(_harness.ToString(), actual.ToString());
        }
        [TestMethod]
        public void TestDeleteAll()
        {
            //Arrange
            User user = new User("test@example.com");
            Blab blab = new Blab("this is a blab",user);
            //Act
            _harness.Create(blab);
            _harness.Create(user);
            _harness.DeleteAll();
            ArrayList actual = (ArrayList)_harness.ReadAll();
            //Assert
            Assert.AreEqual(0, actual.Count);
        }
    }
}
