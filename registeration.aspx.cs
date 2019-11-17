using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace TestForm
{
    public partial class registeration : System.Web.UI.Page
    {
        //sql connection need to hide the data source later on for a security purposes 
        SqlConnection con = new SqlConnection(@"Data Source=parsley.arvixe.com;Initial Catalog=computerscienceprojectportal;Persist Security Info=True;User ID=computerscienceprojectportal;Password=team4CS673");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            dis_data();

        }
        //Function onclick on enter on register form
        protected void RegisterEventMethod(object sender, EventArgs e)
        {

            RegisterUserWithSlowHash();
        }

        private void RegisterUserWithSlowHash()
        {
            bool methodStatus = true;

            if (InputValidation.validateName(usernameTextBox.Text) == false)
            {
                methodStatus = false;
            }

            if (InputValidation.ValidationPassword(passwordTextBox.Text, confirmPasswordTextBox.Text) == false)
            {
                methodStatus = false;
            }

            if (methodStatus == true)
            {
                //connected to the database
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                //link a database table from user info from the input
                cmd.CommandText = "insert into USERTABLE (Fname, Lname,School,email,Password,RoleType)" +
                    "values(@Fname,@Lname,@School,@email,@Password,@RoleType)";

                //add value to each column 
                cmd.Parameters.AddWithValue("@Fname", firstnameTextBox.Text);
                cmd.Parameters.AddWithValue("@Lname", lastNameTextBox.Text);
                cmd.Parameters.AddWithValue("@School", schoolTextBox.Text);
                cmd.Parameters.AddWithValue("@email", usernameTextBox.Text);

                if(DropDownList1.SelectedValue == "Student")
                {
                    cmd.Parameters.AddWithValue("@RoleType", DropDownList1.SelectedValue);
                }
                else if (DropDownList1.SelectedValue == "Faculty")
                {
                    cmd.Parameters.AddWithValue("RoleType", DropDownList1.SelectedValue);
                }
                else
                {
                    lblErrorMessage.Text = "Please select occupation";
                }
                //process to hash password to store in sql
                String saltHashReturned = PasswordHash.CreateHash(passwordTextBox.Text);
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
                cmd.Parameters.AddWithValue("@Password", saltHashReturned);


                //sql execute
                cmd.ExecuteNonQuery();


                if (DropDownList1.SelectedIndex == 1)
                {

                    int studentID;

                    SqlCommand std = con.CreateCommand();
                    std.CommandType = CommandType.Text;
                    SqlDataReader reader;
                    std.CommandText = "SELECT U_ID FROM USERTABLE WHERE email='" + usernameTextBox.Text + "'";
                    reader = std.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        studentID = int.Parse(reader[0].ToString());
                        reader.Close();

                        std.CommandText = "insert into STUDENT (U_ID) values(@U_ID)";
                        std.Parameters.AddWithValue("@U_ID", studentID);
                        std.ExecuteNonQuery();
                    }

                }
                else if (DropDownList1.SelectedIndex == 2)
                {
                    int facultyID;

                    SqlCommand std = con.CreateCommand();
                    std.CommandType = CommandType.Text;
                    SqlDataReader reader;
                    std.CommandText = "SELECT U_ID FROM USERTABLE WHERE email='" + usernameTextBox.Text + "'";
                    reader = std.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        facultyID = int.Parse(reader[0].ToString());
                        reader.Close();

                        std.CommandText = "insert into FACULTY (U_ID) values(@U_ID)";
                        std.Parameters.AddWithValue("@U_ID", facultyID);
                        std.ExecuteNonQuery();
                    }

                }

                // Display data
                firstnameTextBox.Text = "";
                lastNameTextBox.Text = "";
                schoolTextBox.Text = "";
                usernameTextBox.Text = "";

                dis_data();
            }

            else
            {
                DisplayError();
            }
        }



        private void DisplayError()
        {

            if (usernameTextBox.Text == "" || passwordTextBox.Text == "")
            {
                //validate requirement input from the user
                lblErrorMessage.Text = "Please fill Mandatory Fields";

            }

            else if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                //validate if both password are matching
                lblErrorMessage.Text = "Password do not match";
            }

            else
            {
                //check a requirement password format
                Regex RX = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{4,8}$");

                if (!RX.IsMatch(passwordTextBox.Text))
                {
                    lblErrorMessage.Text = "At least one upper case English letter." + "<br />" +
                                           "At least one lower case English letter," + "<br />" +
                                           "At least one digit." + "<br />" +
                                           "At least one special character." + "<br />" +
                                           "Minimum 4 and maximum 8 in length . ";
                }


            }

        }

        //Function to display user table will be delete after all testing is completed 
        public void dis_data()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from USERTABLE";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}

