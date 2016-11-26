using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Data.Intefaces;
using PhotoShare.Data.Mocking;
using PhotoShare.Models;

namespace PhotoShare.Test
{
    [TestClass]
   public class UploadProfilePictureTest
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
        public void Test_UploadPicture_ShouldReturnLenghtOfBytesMoreThanZero()
        {
            //Arrange
            byte[] bytes;
            using (StreamReader reader = new StreamReader("index.jpg"))
            {

                using (var memstream = new MemoryStream())
                {
                    reader.BaseStream.CopyTo(memstream);
                    bytes = memstream.ToArray();
                }
            }

           
            //Act
            User user = new User() {Username = "user", ProfilePicture = bytes};

            //Assert
            Assert.AreNotEqual(0, user.ProfilePicture.Length);
        }
    }
}
