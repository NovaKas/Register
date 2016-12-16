using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Register.Models
{
    public class Teacher
    {
        [ForeignKey("User")]
        public string TeacherID { get; set; }

        public string UserID { get; set; }
        public string RoleID { get; set; }
        //public int NewsID { get; set; }
        //public int QuestionID { get; set; }
        //public int MySubjectIS { get; set; }
        public int? SClassID { get; set; } 
        //public int GradeID { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual IdentityManager Role { get; set; }
        public virtual ICollection<News> Newses { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<MySubject> MySubjects { get; set; }
        public virtual SClass SClass { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}