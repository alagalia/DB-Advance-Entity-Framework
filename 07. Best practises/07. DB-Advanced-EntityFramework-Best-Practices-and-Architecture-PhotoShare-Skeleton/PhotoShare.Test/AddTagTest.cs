using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoShare.Data.Intefaces;
using PhotoShare.Data.Mocking;
using PhotoShare.Models;

namespace PhotoShare.Test
{
   
    [TestClass]
    public class AddTagTest
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
        public void TestTagCount()
        {
            //Arrange
            Tag tag = new Tag() {Name = "mock"};
            int countStart = unit.Tags.GetAll().Count();

            //Act
            unit.Tags.Add(tag);
            int countEnd = unit.Tags.GetAll().Count();

            //Assert
            Assert.AreNotEqual(countStart,countEnd );
        }
    }
}
