using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Data.Intefaces;
using PhotoShare.Data.Mocking;
using PhotoShare.Models;

namespace PhotoShare.Test
{
    [TestClass]
    public class RegisterUserTest
    {
        private IRepository<Tag> tagRepo;
        private UowMock unit;

        [TestInitialize]
        public void Init()
        {
            this.tagRepo = new RepositoryMock<Tag>();
            this.unit = new UowMock();
        }

        [TestMethod]
        public void Test_RegisterUser_Count_ShouldReturn1()
        {
            //Arrange
            User user1 = new User() { Username = "userName1" };
            User user2 = new User() { Username = "userName2" };

            //Act
            unit.Users.Add(user1);
            
            //Assert
            Assert.AreEqual(1, unit.Users.GetAll().Count());
        }

        [TestMethod]
        public void Test_RegisterUser_GetFirstUser_ShouldReturn_userName1()
        {
            //Arrange
            User user1 = new User() { Username = "userName1" };
            User user2 = new User() { Username = "userName2" };

            //Act
            unit.Users.Add(user1);
            unit.Users.Add(user2);

            //Assert
            Assert.AreEqual("userName1", unit.Users.GetAll().ToArray()[0].Username);
        }
    }
}
