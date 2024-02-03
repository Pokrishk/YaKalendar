using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaKalendar
{
    internal class Zametk
    {
        public string name { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public Zametk(string name, string description, DateTime date) 
        {
            this.name= name;
            this.description = description;
            this.date = date;
        }
    }
}
