using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;

namespace TestForm
{
    public class InputValidation
    {
        public static bool ValidationPassword(string p1, string p2)
        {
            bool pass = true;
            if (p1.Equals(p2) == false)
            {
                pass = false;

            }
            return pass;
        }

        public static bool validateName(string input)
        {
            bool pass = true;
            var positiveIntRegex = new System.Text.RegularExpressions.Regex(@"[a-zA-Z]*$");

            if(positiveIntRegex.IsMatch(input) == false)
            {
                pass = false;
            }

            if (input.Trim().Length < 1)
            {
                pass = false;
            }

            return pass;
        }
    }
}