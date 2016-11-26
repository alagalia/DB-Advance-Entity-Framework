using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoShare.Data.Intefaces;
using PhotoShare.Data.Mocking;
using PhotoShare.Models;

namespace PhotoShare.Test
{
    [TestClass]
    public class AddTagToTest
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
        public void TestAddAlbum()
        {
            
            //Arrange
            Album album = new Album() { Name = "Summer" };
            Tag tag = new Tag() { Name = "#mockSummertag" };


            //Act
            album.Tags.Add(tag);
            unit.Albums.Add(album);


            //Assert
            Assert.AreEqual("Summer", unit.Albums.FirstOrDefault().Name);
        }

        [TestMethod]
        public void TestAddTagToAlbum()
        {

            //Arrange
            Album album = new Album() { Name = "Summer" };
            Tag tag = new Tag() { Name = "#mockSummertag" };
            Tag tag1 = new Tag() { Name = "#mockSummertag1" };


            //Act
            album.Tags.Add(tag);
            album.Tags.Add(tag1);
            unit.Albums.Add(album);


            //Assert
            Assert.AreEqual("#mockSummertag1", unit.Albums.FirstOrDefault().Tags.Skip(1).First().Name);
        }

    }
}
