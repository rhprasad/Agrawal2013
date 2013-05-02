using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PirateThis.Domain.Entities;

namespace PirateThis.Domain.Abstract
{
    public interface ISongRepository
    {
        IQueryable<Song> Songs { get; }

        void SaveSong(Song song);

        Song DeleteSong(int songID);
    }
}
