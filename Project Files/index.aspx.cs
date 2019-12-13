using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TestForm.App_Code;

namespace TestForm
{

    public partial class index : System.Web.UI.Page
    {
        DBConnection DBm = new DBConnection();
        private String queryStr;
        private SqlDataReader reader;

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
                DBm.ConnectDB();

                queryStr = "SELECT U_ID, Fname, Lname, password, email, RoleType FROM USERTABLE WHERE email = @email";
                DBm.GetCommend(queryStr);
                DBm.AddVal("@email", usernameTextBox.Text);

                reader = DBm.ExeReader();

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

        protected void ForgetPwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgetPassword.aspx");
        }
    }
}