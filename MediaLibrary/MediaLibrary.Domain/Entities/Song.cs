using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PirateThis.Domain.Entities
{
    public class Song
    {
        [HiddenInput(DisplayValue = false)]
        public int SongID { get; set; }

        [Required(ErrorMessage = "Enter a title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter an artist.")]
        public string Artist { get; set; }

        [Required(ErrorMessage = "Enter an album title.")]
        public string Album { get; set; }

        [Required(ErrorMessage = "Enter a year.")]
        [Range(1900, 2100, ErrorMessage = "Enter a valid year.")]
        public int Year { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter a track number.")]
        [Range(1, 30, ErrorMessage = "Enter a valid track number.")]
        public int Track { get; set; }

        [Required(ErrorMessage = "Enter a genre.")]
        public string Genre { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public byte[] MP3Data { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string MP3MimeType { get; set; }

    }
}
