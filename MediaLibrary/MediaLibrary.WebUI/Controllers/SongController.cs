using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PirateThis.Domain.Abstract;
using PirateThis.Domain.Entities;
using PirateThis.WebUI.Models;

namespace PirateThis.WebUI.Controllers
{
    public class SongController : Controller
    {
        private ISongRepository repository;
        private int PageSize = 10;

        public SongController(ISongRepository songRepository)
        {
            this.repository = songRepository;
        }

        public ViewResult List(string artist, int page = 1)
        {
            SongsListViewModel model = new SongsListViewModel
            {
                Songs = repository.Songs
                .Where(s => artist == null || s.Artist == artist)
                .OrderBy(s => s.SongID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = artist == null ?
                        repository.Songs.Count() :
                        repository.Songs.Where(e => e.Artist == artist).Count()
                },
                CurrentArtist = artist
            };

            return View(model);
        }

        public FileContentResult GetImage(int songID)
        {
            Song song = repository.Songs.FirstOrDefault(s => s.SongID == songID);
            if (song != null)
            {
                return File(song.ImageData, song.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public FileContentResult GetMP3(int songID)
        {
            Song song = repository.Songs.FirstOrDefault(s => s.SongID == songID);
            if (song != null)
            {
                return File(song.MP3Data, song.MP3MimeType);
            }
            else
            {
                return null;
            }
        }

        public PartialViewResult ArtistSummary(Song song)
        {
            return PartialView(song);
        }

    }
}
