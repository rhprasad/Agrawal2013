using System.Collections.Generic;
using PirateThis.Domain.Entities;

namespace PirateThis.WebUI.Models
{
    public class SongsListViewModel
    {
        public IEnumerable<Song> Songs { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentArtist { get; set; }
    }
}