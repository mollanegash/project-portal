using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace TestForm.ProjectsCS
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(@"Data Source=parsley.arvixe.com;Initial Catalog=computerscienceprojectportal;Persist Security Info=True;User ID=computerscienceprojectportal;Password=team4CS673");
        String query;
        SqlDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlCommand std = con.CreateCommand();
            std.CommandType = CommandType.Text;
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

                con.Open();
                query = "Select email, Fname FROM USERTABLE WHERE email = @email AND Fname = @Fname";
                std = new SqlCommand(query, con);
                std.Parameters.AddWithValue("@email", TextBox1.Text);
                std.Parameters.AddWithValue("@Fname", TextBox5.Text);

                reader = std.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    //close reader command 
                    con.Close();
                    //open again to update pasword
                    con.Open();

                    std.CommandText = "UPDATE USERTABLE Set Password = @Password";
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
                    std.Parameters.AddWithValue("@Password", saltHashReturned);


                    //sql execute
                    std.ExecuteNonQuery();
                    Response.Redirect("index.aspx");
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



