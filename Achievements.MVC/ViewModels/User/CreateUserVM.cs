using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Achievements.MVC.ViewModels.User
{
    public class CreateUserVM
    {
        [Required]
        [MaxLength(50)]
        public string Login { set; get; }

        [Required]
        public string Password { set; get; }
    }
}