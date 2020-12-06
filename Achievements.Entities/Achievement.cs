using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Achievement
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public Achievement() { }

        public Achievement(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public Achievement(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public Achievement(string name)
        {
            this.name = name;
        }
    }
}
