using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MediaLibrary.Domain.Abstract;
using MediaLibrary.Domain.Entities;
using MediaLibrary.WebUI.Controllers;
using MediaLibrary.WebUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MediaLibrary.UnitTests
{
    [TestClass]
    public class Pagination
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<ISongRepository> mock = new Mock<ISongRepository>();
            mock.Setup(m => m.Songs).Returns(new Song[]
            {
                new Song {SongID = 1, Title = "S1"},
                new Song {SongID = 2, Title = "S2"},
                new Song {SongID = 3, Title = "S3"},
                new Song {SongID = 4, Title = "S4"},
                new Song {SongID = 5, Title = "S5"},
                new Song {SongID = 6, Title = "S6"},
                new Song {SongID = 7, Title = "S7"},
                new Song {SongID = 8, Title = "S8"},
                new Song {SongID = 9, Title = "S9"},
                new Song {SongID = 10, Title = "S10"}
            }.AsQueryable());

            SongController controller = new SongController(mock.Object);
            //controller.PageSize = 3;

            //IEnumerable<Song> result = (IEnumerable<Song>)controller.List(2).Model;
            SongsListViewModel result = (SongsListViewModel)controller.List(2).Model;

            Song[] songArray = result.Songs.ToArray();
            Assert.IsTrue(songArray.Length == 5);
            Assert.AreEqual(songArray[0].Title, "S6");
            Assert.AreEqual(songArray[1].Title, "S7");
        }
    }
}
