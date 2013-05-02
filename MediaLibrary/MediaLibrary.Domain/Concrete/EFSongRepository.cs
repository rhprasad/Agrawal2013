using PirateThis.Domain.Abstract;
using PirateThis.Domain.Entities;
using System.Linq;

namespace PirateThis.Domain.Concrete
{
    public class EFSongRepository : ISongRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Song> Songs
        {
            get { return context.Songs; }
        }

        public void SaveSong(Song song)
        {
            if (song.SongID == 0)
            {
                context.Songs.Add(song);
            }
            else
            {
                Song dbEntry = context.Songs.Find(song.SongID);

                if (dbEntry != null)
                {
                    dbEntry.Title = song.Title;
                    dbEntry.Artist = song.Artist;
                    dbEntry.Album = song.Album;
                    dbEntry.Year = song.Year;
                    dbEntry.Description = song.Description;
                    dbEntry.Track = song.Track;
                    dbEntry.Genre = song.Genre;
                    dbEntry.ImageData = song.ImageData;
                    dbEntry.ImageMimeType = song.ImageMimeType;
                    dbEntry.MP3Data = song.MP3Data;
                    dbEntry.MP3MimeType = song.MP3MimeType;
                }
            }

            context.SaveChanges();

        }

        public Song DeleteSong(int songID)
        {
            Song dbEntry = context.Songs.Find(songID);
            if (dbEntry != null)
            {
                context.Songs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
