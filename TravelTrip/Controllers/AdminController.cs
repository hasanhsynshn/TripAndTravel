using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Classes;

namespace TravelTrip.Controllers
{
    public class AdminController : Controller
    {
   
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var data = c.Blogs.ToList();
            return View(data);
        }
        public ActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBlog(Blog model)
        {
            c.Blogs.Add(model);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogRemove(int id)
        {

            var data = c.Blogs.Find(id);
            c.Blogs.Remove(data);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult GetBlog(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("GetBlog",bl);
        }
        [HttpPost]
        public ActionResult ModifiedBlog(Blog model)
        {
            var data = c.Blogs.Find(model.BlogId);
            data.BlogId = model.BlogId;
            data.Description = model.Description;
            data.Title = model.Title;
            data.BlogImage = model.BlogImage;
            data.Date = model.Date;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CommentList()
        {
            var comments=c.Comments.ToList();
            return View(comments);
        }
        public ActionResult CommentRemove(int id)
        {
            var data = c.Comments.Find(id);
            c.Comments.Remove(data);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetComment(int id)
        {
            var data = c.Comments.Find(id);
            return View("GetComment", data);
        }
        [HttpPost]
        public ActionResult CommentModify(Comment comment)
        {
            var result = c.Comments.Find(comment.CommentId);


            result.CommentId = comment.CommentId;
            result.UserName = comment.UserName;
            result.Mail = comment.Mail;
            result.Comments = comment.Comments;
            
            c.SaveChanges();
            return RedirectToAction("CommentList");
        }
    }
}