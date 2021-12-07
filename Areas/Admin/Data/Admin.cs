using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearninGO.Areas.Admin.Data
{
    public class Admin : Areas.Instructor.Data.Instructor
    {
       

        public string Name { get; set; }
        public string IconUrl { get; set; }
        public Nullable<int> CourseID { get; set; }
        public int ContentId { get; set; }
        public string ContentType { get; set; }
        public string Url { get; set; }


        public string CourseThumbnail { get; set; }
        public string ImagesUrl { get; set; }
        public Nullable<int> InstructorId { get; set; }
        public int CourseId { get; set; }
        public string CourseLevel { get; set; }
        public string Details { get; set; }
        public string Provider { get; set; }
        public string Tage { get; set; }
        public string Leanguage { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public Nullable<int> Category { get; set; }


        public long InstructorPhoneNumber { get; set; }
        public string InstructorAddress { get; set; }
        public string InstructorAbout { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> InstructorID { get; set; }
        public string Chat { get; set; }
        public int sno { get; set; }

      
        public int PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }
    }
}