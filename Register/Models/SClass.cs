using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Register.Models
{
    public class SClass
    {
        [ForeignKey("Teacher")]
        public string SClassID { get; set; }
        public string Name { get; set; }

        //public string StudentID { get; set; }
        public string TeacherID { get; set; }
        //public int SubjectID { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}