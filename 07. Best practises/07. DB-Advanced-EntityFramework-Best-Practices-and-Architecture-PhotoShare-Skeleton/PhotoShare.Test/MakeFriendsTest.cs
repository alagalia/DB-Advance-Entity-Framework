using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PhotoShare.Data.Intefaces;
using PhotoShare.Data.Mocking;
using PhotoShare.Models;

namespace PhotoShare.Test
{
    [TestClass]
    public class MakeFriendsTest
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
        public void Test_Friends_Count_AddOneFriend_ShouldReturn1()
        {
            //Arrange
            User user1 = new User() {Username = "userName1"};
            User user2 = new User() {Username = "userName2"};
            
            //Act
            unit.Users.Add(user1);
            unit.Users.Add(user2);
            user1.Friends.Add(user2);
            user2.Friends.Add(user1);
            
            //Assert
            Assert.AreEqual(1, unit.Users.FirstOrDefaultWhere(u=>u.Username == "userName1").Friends.Count);
        }

        [TestMethod]
        public void Test_Friends_AddOneFriend_ShouldReturnFriendName()
        {

            //Arrange
            User user1 = new User() { Username = "userName1" };
            User user2 = new User() { Username = "userName2" };
            
            //Act
            unit.Users.Add(user1);
            unit.Users.Add(user2);
            user1.Friends.Add(user2);
            user2.Friends.Add(user1);
            
            //Assert
            Assert.AreEqual("userName2", unit.Users.FirstOrDefaultWhere(u => u.Username == "userName1").Friends.ToArray()[0].Username);
            Assert.AreEqual("userName1", unit.Users.FirstOrDefaultWhere(u => u.Username == "userName2").Friends.ToArray()[0].Username);
        }
    }
}
