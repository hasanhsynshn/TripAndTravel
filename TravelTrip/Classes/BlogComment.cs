using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTrip.Classes
{

    public class BlogComment
    {
        public IEnumerable<Blog> BlogValue { get; set; }
        public IEnumerable<Comment>CommentValue { get; set; }
        public IEnumerable<Blog> Value3 { get; set; }
    }
}