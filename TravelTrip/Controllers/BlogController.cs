using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Classes;

namespace TravelTrip.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogComment bc = new BlogComment();

        public ActionResult Index()
        {
            bc.BlogValue = c.Blogs.ToList();
            bc.Value3 = c.Blogs.OrderByDescending(x=>x.BlogId).Take(3).ToList();
            return View(bc);
        }
        public ActionResult BlogDetail(int id)
        {
            bc.BlogValue = c.Blogs.Where(x => x.BlogId == id).ToList();
            bc.CommentValue = c.Comments.Where(x => x.BlogId == id).ToList();
            return View(bc);
        }

        public PartialViewResult Comment(int id)
        {
            ViewBag.value = id;
            return PartialView();
        }
        [HttpPost]
       public PartialViewResult Comment(Comment model)
        {
            c.Comments.Add(model);
            c.SaveChanges();
            return PartialView();
        }
    }
}