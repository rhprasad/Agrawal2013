using System.Collections.Generic;
using PirateThis.Domain.Entities;

namespace PirateThis.WebUI.Models
{
    public class CommentsListViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
    }
}