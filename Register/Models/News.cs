using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Register.Models
{
    public class News
    {
        public int NewsID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string TeacherID { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}