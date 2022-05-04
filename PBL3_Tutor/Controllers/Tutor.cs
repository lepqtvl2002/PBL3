using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3_Tutor.Controllers
{
    public class Tutor : People
    {
        public string Experience { get; set; }
        public string Subject { get; set; }
        public string Class { get; set; }
        //public long Wage { get; set; }

    }
}