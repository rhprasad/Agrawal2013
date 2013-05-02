using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PirateThis.Domain.Abstract;
using PirateThis.Domain.Entities;
using PirateThis.WebUI.Models;

namespace PirateThis.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private ICommentRepository repository;

        public CommentController(ICommentRepository commentRepository)
        {
            this.repository = commentRepository;
        }

        public ViewResult List(int songID)
        {
            CommentsListViewModel model = new CommentsListViewModel
            {
                Comments = repository.Comments
                .Where(c => c.SongID == songID)
                .OrderBy(c => c.CommentID)
            };
            
            return View(model);
        }

        public ViewResult Add(int songId)
        {
            ViewBag.SongID = songId;
            return View(new Comment());
        }

        //[HttpPost]
        //public ActionResult Add(Comment comment, int SongID2)
        //{
        //    comment.SongID = SongID2;
        //    if (ModelState.IsValid)
        //    {
        //        repository.AddComment(comment);
        //        ViewBag.Processed = true;
        //        return View();
        //    }
        //    else
        //    {
        //        return View(comment);
        //    }
        //}

        [HttpPost]
        public ActionResult Add(string name, string remark, int songid)
        {
            Comment newComment = new Comment();
            newComment.Name = name;
            newComment.Remark = remark;
            newComment.SongID = songid;

            repository.AddComment(newComment);

            return Redirect(Request.UrlReferrer.ToString() + "#Comment-" + songid);
        }

    }
}
