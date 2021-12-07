using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearninGO.Areas.Admin.Data
{
    public class StudentModel:AcountModel
    {
        public Nullable<int> Id { get; set; }
        public string StudentFullName { get; set; }
        public long PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }

        public int sno { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> InstructorID { get; set; }
        public string StudentChat { get; set; }
        public string InstructorChat { get; set; }
        public Nullable<System.DateTime> chatmessagetime { get; set; }


        public virtual Account Account { get; set; }
    }
}