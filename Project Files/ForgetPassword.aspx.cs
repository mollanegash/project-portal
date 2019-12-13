using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using TestForm.App_Code;

namespace TestForm.ProjectsCS
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        
        private String query;
        DBConnection Dbm = new DBConnection();
 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {         
            bool methodCheck = true;
            //check a requirement password format
            Regex RK = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{4,12}$");

            if (InputValidation.ValidationPassword(TextBox6.Text, TextBox7.Text) == false)
            {
                methodCheck = false;
            }

            if (!RK.IsMatch(TextBox6.Text))
            {
                methodCheck = false;
            }

            if (methodCheck == true)
            {
                Dbm.ConnectDB();
                query = "Select email, Fname FROM USERTABLE WHERE email = @email AND Fname = @Fname";
                Dbm.GetCommend(query);

                Dbm.AddVal("@email", TextBox1.Text);
                Dbm.AddVal("@Fname", TextBox5.Text);

                SqlDataReader reader = Dbm.ExeReader();

                if (reader.HasRows && reader.Read())
                {
                    Dbm.CloseDB();
                    DBConnection Db2 = new DBConnection();
                    Db2.ConnectDB();

                    query = "UPDATE USERTABLE Set Password = @Password";
                    Db2.GetCommend(query);

                    //process to hash password to store in sql
                    String saltHashReturned = PasswordHash.CreateHash(TextBox6.Text);
                    int commaIndex = saltHashReturned.IndexOf(":");
                    String extractedString = saltHashReturned.Substring(0, commaIndex);
                    commaIndex = saltHashReturned.IndexOf(":");
                    extractedString = saltHashReturned.Substring(commaIndex + 1);
                    commaIndex = extractedString.IndexOf(":");
                    String salt = extractedString.Substring(0, commaIndex);

                    commaIndex = extractedString.IndexOf(":");
                    extractedString = extractedString.Substring(commaIndex + 1);
                    String hash = extractedString;

                    //from the first : to the second is a salt
                    //from the second " to the end is a hash
                    Db2.AddVal("@Password", saltHashReturned);


                    //sql execute
                    Db2.ExeQuery();
                    Response.Redirect("index.aspx");
                    Db2.CloseDB();
                }

                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Username and Name is not matching";

                }

            }

            if (methodCheck == false)
            {
                Label1.Visible = true;
                Label1.Text = "At least one upper case English letter." + " <br /> " +
                                      "At least one lower case English letter," + "<br />" +
                                      "At least one digit." + "<br />" +
                                      "At least one special character." + "<br />" +
                                      "Minimum 4 and maximum 12 in length . ";
            }

        }


    }
}



