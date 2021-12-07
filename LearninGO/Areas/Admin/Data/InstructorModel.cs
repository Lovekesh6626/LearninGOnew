using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearninGO.Areas.Admin.Data
{
    public class InstructorModel:AcountModel
    {

      
        public Nullable<int> InstructorId { get; set; }

        public string InstructorFullName { get; set; }
        public long InstructorPhoneNumber { get; set; }
        public string InstructorAddress { get; set; }
        public string InstructorAbout { get; set; }
        public string InstructorImage { get; set; }
        public Nullable<System.DateTime> Time { get; set; }

        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseLevel { get; set; }
        public string Details { get; set; }
        public string Provider { get; set; }
        public string Tag { get; set; }
        public string Language { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public Nullable<int> Category { get; set; }
        public string CourseImageUrl { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public Nullable<int> CourseID { get; set; }
        public Nullable<int> ContentId { get; set; }
        public string ContentType { get; set; }
        public string Url { get; set; }

        public int sno { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> InstructorID { get; set; }
        public string StudentChat { get; set; }
        public string InstructorChat { get; set; }
        public Nullable<System.DateTime> chatmessagetime { get; set; }

        public virtual Account Account { get; set; }
    }
}