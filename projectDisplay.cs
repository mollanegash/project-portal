using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestForm.ProjectsCS
{
    public class projectDisplay
    {
        public int UserID { get; set; }
        public int P_ID { get; set; }
        public String uploadDate { get; set; }
        public String Link { get; set; }
        public String Tag { get; set; }
        public String P_Name { get; set; }
        public String Desprip { get; set; }

        public List<projectDisplay> userinfo { get; set; }
    }
}