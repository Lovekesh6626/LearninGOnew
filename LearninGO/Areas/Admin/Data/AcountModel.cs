using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LearninGO.Areas.Admin.Data
{
    public class AcountModel
    {
        
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public int Type { get; set; }

        public Nullable<int> InstructorId { get; set; }

        public string InstructorFullName { get; set; }
        public long InstructorPhoneNumber { get; set; }
        public string InstructorAddress { get; set; }
        public string InstructorAbout { get; set; }
        public string InstructorImage { get; set; }
        public Nullable<System.DateTime> Time { get; set; }

        public Nullable<int> StudentId { get; set; }
        public string StudentFullName { get; set; }
        public string StudentAddress { get; set; }
        public long PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Linkdin { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }
}