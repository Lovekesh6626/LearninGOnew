using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearninGO.Areas.Instructor.Data
{
    public class Instructor : Areas.Student.Data.Student
    {
       
        public Nullable<int> InstructorId { get; set; }
        public long InstructorPhoneNumber { get; set; }
        public string InstructorAddress { get; set; }
        public string InstructorAbout { get; set; }
        public string CategoryName { get; set; }
        public string IconUrl { get; set; }
        public int ContentId { get; set; }
        public string ContentType { get; set; }
        public string Url { get; set; }
        public string CourseThumbnail { get; set; }
        public string ImagesUrl { get; set; }
        public int CourseId { get; set; }
        public string CourseLevel { get; set; }
        public string Details { get; set; }
        public string Provider { get; set; }
        public string Tage { get; set; }
        public string Leanguage { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string CourseTitle { get; set; }

        public string CourseImageUrl { get; set; }
    }
}