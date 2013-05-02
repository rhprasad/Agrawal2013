using PirateThis.Domain.Abstract;
using PirateThis.Domain.Entities;
using System.Linq;

namespace PirateThis.Domain.Concrete
{
    public class EFCommentRepository : ICommentRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Comment> Comments
        {
            get { return context.Comments; }
        }

        public void AddComment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public Comment DeleteComment(int commentID)
        {
            Comment dbEntry = context.Comments.Find(commentID);
            if (dbEntry != null)
            {
                context.Comments.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
