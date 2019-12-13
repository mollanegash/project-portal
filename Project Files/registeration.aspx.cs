using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using TestForm.App_Code;

namespace TestForm
{
   
    public partial class registeration : System.Web.UI.Page
    {
        DBConnection DBm = new DBConnection();
        private String Text;
        private SqlDataReader reader;
        private int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            

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
                //link a database table from user info from the input
                Text = "insert into USERTABLE (Fname, Lname,School,email,Password,RoleType)" +
                    "values(@Fname,@Lname,@School,@email,@Password,@RoleType)";

                //connected to the database
                DBm.ConnectDB();
                DBm.GetCommend(Text);

                //add value to each column 
                DBm.AddVal("@Fname", firstnameTextBox.Text);
                DBm.AddVal("@Lname", lastNameTextBox.Text);
                DBm.AddVal("@School", schoolTextBox.Text);
                DBm.AddVal("@email", usernameTextBox.Text);

                if(DropDownList1.SelectedValue == "Student")
                {
                    DBm.AddVal("@RoleType", DropDownList1.SelectedValue);
                }
                else if (DropDownList1.SelectedValue == "Faculty")
                {
                    DBm.AddVal("RoleType", DropDownList1.SelectedValue);
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
                DBm.AddVal("@Password", saltHashReturned);


                //sql execute
                DBm.ExeQuery();


                if (DropDownList1.SelectedIndex == 1)
                {
                    DBm.ConnectDB();
                    Text = "SELECT U_ID FROM USERTABLE WHERE email='" + usernameTextBox.Text + "'";
                    DBm.GetCommend(Text);
                    reader = DBm.ExeReader();

                    if (reader.HasRows && reader.Read())
                    {
                        userID = int.Parse(reader[0].ToString());
                        reader.Close();

                        Text = "insert into STUDENT (U_ID) values(@U_ID)";
                        DBm.AddInt("@U_ID", userID);
                        DBm.ExeQuery();
                    }
                    DBm.CloseDB();

                }
                else if (DropDownList1.SelectedIndex == 2)
                {
                    DBm.ConnectDB();
                    Text = "SELECT U_ID FROM USERTABLE WHERE email='" + usernameTextBox.Text + "'";
                    DBm.GetCommend(Text);
                    reader = DBm.ExeReader();

                    if (reader.HasRows && reader.Read())
                    {
                        userID = int.Parse(reader[0].ToString());
                        reader.Close();

                        Text = "insert into FACULTY (U_ID) values(@U_ID)";
                        DBm.AddInt("@U_ID", userID);
                        DBm.ExeQuery();
                    }
                    DBm.CloseDB();
                }

                // Display data
                firstnameTextBox.Text = "";
                lastNameTextBox.Text = "";
                schoolTextBox.Text = "";
                usernameTextBox.Text = "";

               
            }

            else
            {
                DisplayError();
            }
        }



        public void DisplayError()
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

        
        
    }
}

