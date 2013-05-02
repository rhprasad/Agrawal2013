using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PirateThis.Domain.Entities
{
    public class Comment
    {
        [HiddenInput(DisplayValue = false)]
        public int CommentID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int SongID { get; set; }
        [Required(ErrorMessage = "Enter your name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter a comment.")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
    }
}
