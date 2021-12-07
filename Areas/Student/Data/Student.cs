using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearninGO.Areas.Student.Data
{
    public class Student: LearninGO.Models.User
    {
      
        public int PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }
       
      
    }
}