using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Timetable
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public string Subject { get; set; }
        public string Time { get; set; }
        public string Teacher { get; set; }
    }
}