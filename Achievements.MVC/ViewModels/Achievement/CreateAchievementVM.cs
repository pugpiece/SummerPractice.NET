using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Achievements.MVC.ViewModels.Achievement
{
    public class CreateAchievementVM
    {
        [Required]
        [MaxLength(100)]
        public string Name { set; get; }

        [MaxLength(200)]
        public string Description { set; get; }


    }
}