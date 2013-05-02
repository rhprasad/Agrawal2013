using PirateThis.Domain.Abstract;
using PirateThis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PirateThis.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ISongRepository repository;

        public AdminController(ISongRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Songs);
        }

        public ViewResult Edit(int songID)
        {
            Song song = repository.Songs
                .FirstOrDefault(s => s.SongID == songID);
            return View(song);
        }

        [HttpPost]
        public ActionResult Edit(Song song, HttpPostedFileBase image, HttpPostedFileBase MP3)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    song.ImageMimeType = image.ContentType;
                    song.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(song.ImageData, 0, image.ContentLength);
                }

                if (MP3 != null)
                {
                    song.MP3MimeType = MP3.ContentType;
                    song.MP3Data = new byte[MP3.ContentLength];
                    MP3.InputStream.Read(song.MP3Data, 0, MP3.ContentLength);
                }

                repository.SaveSong(song);
                TempData["message"] = string.Format("{0} has been saved", song.Title);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with values
                return View(song);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Song());
        }

        [HttpPost]
        public ActionResult Delete(int songId)
        {
            Song deletedSong = repository.DeleteSong(songId);
            if (deletedSong != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedSong.Title);
            }
            return RedirectToAction("Index");
        }

    }
}
