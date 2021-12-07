using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearninGO.Areas.Admin.Data
{
    public class AdminModel: AcountModel
    {
        public Nullable<int> InstructorId { get; set; }
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
        public virtual Account Account { get; set; }
        public virtual Category Category1 { get; set; }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string IconUrl { get; set; }

    }
}