using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Classes;

namespace TravelTrip.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        Context c = new Context();
        public ActionResult Index()
        {

            var values = c.Blogs.Take(5).ToList();
            return View(values);
        }
        public ActionResult About()
        {
            var data = c.Abouts.ToList();
            return View(data);
        }

        public PartialViewResult Partial()
        {
            var values = c.Blogs.OrderByDescending(x => x.BlogId).Take(2).ToList();
            return PartialView(values);
        }
            public PartialViewResult Partial2()
        {
            var value = c.Blogs.Where(x => x.BlogId == 1).ToList();
            return PartialView(value);
        }
        public PartialViewResult Partial3()
        {
            var value = c.Blogs.ToList();
            return PartialView(value);
        }
        public PartialViewResult Partial4()
        {
            var value = c.Blogs.Take(3).ToList();
            return PartialView(value);
        }
        public PartialViewResult Partial5()
        {
            var value = c.Blogs.Take(3).OrderByDescending(x=>x.BlogId).ToList();
            return PartialView(value);
        }
    }
}