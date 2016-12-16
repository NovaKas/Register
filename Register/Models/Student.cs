using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Register.Models
{
    public class Student
    {
        [ForeignKey("User")]
        public string StudentID { get; set; }

        public string UserID { get; set; }
        public string RoleID { get; set; }
        public int SClassID { get; set; }
        //public int GradeID { get; set; }
        //public string ParentID { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual IdentityManager Role { get; set; }
        public virtual SClass SClass { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        //public virtual Parent Parent { get; set; }
    }
}