using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PirateThis.Domain.Entities;

namespace PirateThis.Domain.Abstract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }

        void AddComment(Comment comment);

        Comment DeleteComment(int commentID);
    }
}
