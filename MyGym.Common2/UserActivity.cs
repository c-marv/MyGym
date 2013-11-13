using MyGym.Common2.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Common2
{
    public class UserActivity
    {
        public int ActivityID { get; set; }
        public string NameActivity { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Dia Day { get; set; }
    }
}
