using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateThis.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddSong(Song song)
        {
            CartLine line = lineCollection
                .Where(s => s.Song.SongID == song.SongID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Song = song });
            }
        }

        public void RemoveLine(Song song)
        {
            lineCollection.RemoveAll(l => l.Song.SongID == song.SongID);
        }

        public int ComputeTotalValue()
        {
            return lineCollection.Count();
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Song Song { get; set; }
    }

}

