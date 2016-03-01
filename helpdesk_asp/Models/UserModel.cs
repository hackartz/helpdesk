using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace helpdesk_asp.Models
{
    public class UserModel
    {
        public string userid { get; set; }        
        public string username { get; set; }
        public string roleid { get; set; }
        public string department { get; set; }
        public string RoleName { get; set; }        
        public byte[] password { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Please input Username")]
        [Display(Name = "UserName")]
        public string username { get; set; }
        [Required(ErrorMessage = "Please input Password")]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}