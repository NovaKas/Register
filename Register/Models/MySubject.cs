using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Register.Models
{
    public class MySubject
    {
        public int MySubjectID { get; set; }
        public string TeacherID { get; set; }
        public int SubjectID { get; set; }

        [ForeignKey("TeacherID")]
        [InverseProperty("MySubjects")]
        public virtual Teacher Teacher { get; set; }

        [ForeignKey("SubjectID")]
        [InverseProperty("MySubjects")]
        public virtual Subject Subject { get; set; }
    }
}