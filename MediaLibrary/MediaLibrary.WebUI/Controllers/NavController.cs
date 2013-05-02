using PirateThis.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PirateThis.WebUI.Controllers
{
    public class NavController : Controller
    {
        private ISongRepository repository;

        public NavController(ISongRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string artist = null)
        {
            ViewBag.SelectedArtist = artist;
            
            IEnumerable<string> artists = repository.Songs
                                            .Select(x => x.Artist)
                                            .Distinct()
                                            .OrderBy(x => x);

            return PartialView(artists);
        }
    }
}
