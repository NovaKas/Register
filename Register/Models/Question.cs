using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Register.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string Content { get; set; }
        public string GoodAnswer { get; set; }
        public string BadAnswer { get; set; }
        public int Points { get; set; }

        public string TeacherID { get; set; }
        public int QuizID { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}