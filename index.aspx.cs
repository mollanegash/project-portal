using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TestForm
{

    public partial class index : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=parsley.arvixe.com;Initial Catalog=computerscienceprojectportal;Persist Security Info=True;User ID=computerscienceprojectportal;Password=team4CS673");
        String queryStr;
        SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void SubmitEventMethod(object sender, EventArgs e)
        {
            LoginWithPasswordHashFunction();
        }

        private void LoginWithPasswordHashFunction()
        {
            List<string> saltHashList = null;
            List<string> nameList = null;
            List<string> userRoleList = null;
            List<int> userId = null;

            try
            {

                //connected to the database
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                con.Open();

                queryStr = "SELECT U_ID, Fname, Lname, password, email, RoleType FROM USERTABLE WHERE email = @email";
                cmd = new SqlCommand(queryStr, con);
                cmd.Parameters.AddWithValue("@email", usernameTextBox.Text);

                reader = cmd.ExecuteReader();

                while (reader.HasRows && reader.Read())
                {
                    if (saltHashList == null)
                    {
                        saltHashList = new List<String>();
                        nameList = new List<String>();
                        userRoleList = new List<String>();
                        userId = new List<int>();
                    }
                    String saltHashes = reader.GetString(reader.GetOrdinal("Password"));
                    saltHashList.Add(saltHashes);

                    String fullName = reader.GetString(reader.GetOrdinal("Fname")) + " " +
                                    reader.GetString(reader.GetOrdinal("Lname"));
                    nameList.Add(fullName);

                    String roleType = reader.GetString(reader.GetOrdinal("RoleType"));
                    userRoleList.Add(roleType);

                    int U_ID = reader.GetInt32(reader.GetOrdinal("U_ID"));
                    userId.Add(U_ID);

                    reader.Close();

                    if (saltHashList != null)
                    {
                        for (int i = 0; i < saltHashList.Count; i++)
                        {
                            queryStr = "";
                            bool validUser = PasswordHash.VerifyPassword(passwordTextBos.Text, saltHashList[i]);
                            if (validUser == true)
                            {
                                if (userRoleList[i] == "Student")
                                {
                                    Session["Fname"] = nameList[i];
                                    Session["U_ID"] = userId[i];
                                    Session["RoleType"] = "Student";
                                    Response.BufferOutput = true;
                                    Response.Redirect("studentLogged.aspx", false);
                                }
                                else if (userRoleList[i] == "Faculty")
                                {
                                    Session["Fname"] = nameList[i];
                                    Session["U_ID"] = userId[i];
                                    Session["RoleType"] = "Faculty";
                                    Response.BufferOutput = true;
                                    Response.Redirect("FacultyLogged.aspx", false);
                                }

                            }
                            else
                            {
                                errorLogin.Text = "Incorrect Username or Password";
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}