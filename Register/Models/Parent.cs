using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Register.Models
{
    public class Parent
    {
        [ForeignKey("User")]
        public string ParentID { get; set; }

        public string UserID { get; set; }
        public string RoleID { get; set; }
        //public string StudentID { get; set; }
        
        public virtual ApplicationUser User { get; set; }
        public virtual IdentityManager Role { get; set; }
        //public virtual Student Student { get; set; }
    }
}