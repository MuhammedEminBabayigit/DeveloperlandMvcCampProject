using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Developerland.UI.Models
{
    public class Calendar
    {
        public String title { get; set; }

        public DateTime start { get; set; }

        public DateTime end { get; set; }

        public bool allDay { get; set; }
    }
}