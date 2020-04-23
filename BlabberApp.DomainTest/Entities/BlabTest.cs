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
        public void TestCreateBlab()
        {
            // Arrange
            Blab actual = new Blab();
            // Assert
            Assert.AreEqual(actual.Message.ToString(), harness.Message.ToString());
        }
        [TestMethod]
        public void TestCreateBlabWithMessage()
        {
            // Arrange
            Blab actual = new Blab("This is a test");
            //Act
            harness.Message = actual.Message;
            // Assert
            Assert.AreEqual(actual.Message.ToString(), harness.Message.ToString());
        }
        [TestMethod]
        public void TestCreateBlabWithUser()
        {
            // Arrange
            User user = new User("testuser@example.com");
            Blab actual = new Blab(user);
            //Act
            harness.User = actual.User;
            // Assert
            Assert.AreEqual(actual.ToString(), harness.ToString());
        }
        [TestMethod]
        public void TestCreateBlabWithMessageAndUser()
        {
            // Arrange
            User user = new User("testuser@example.com");
            Blab actual = new Blab("This is a test", user);
            //Act
            harness.User = actual.User;
            harness.Message = actual.Message;
            // Assert
            Assert.AreEqual(actual.ToString(), harness.ToString());
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
        public void TestChangeMessage()
        {
            // Arrange
            Blab actual = new Blab("this is a test message");
            // Act
            actual.Message = harness.Message;
            // Assert
            Assert.AreEqual(actual.Message, harness.Message);
        }

        [TestMethod]
        public void TestId()
        {
            // Arrange
            Guid expected = harness.Id;
            // Act
            Guid actual = harness.Id;//
            // Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(true, harness.Id is Guid);
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
    }
}
