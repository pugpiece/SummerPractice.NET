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
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}