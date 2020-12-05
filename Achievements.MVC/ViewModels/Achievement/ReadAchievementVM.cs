using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Achievements.MVC.ViewModels.Achievement
{
    public class ReadAchievementVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}