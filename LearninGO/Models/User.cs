using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearninGO.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<int> Type { get; set; }

        public string SocialMediaType { get; set; }
        public string socialmediaurl { get; set; }
    }
}