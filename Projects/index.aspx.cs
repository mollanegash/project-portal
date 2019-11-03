using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace TestForm
{
  
    public partial class index : System.Web.UI.Page
    {      
        SqlConnection con = new SqlConnection(@"Data Source=parsley.arvixe.com;Initial Catalog=computerscienceprojectportal;Persist Security Info=True;User ID=computerscienceprojectportal;Password=team4CS673");
        String queryStr;
        String name;
        SqlDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void SubmitEventMethod(object sender, EventArgs e)
        {
            LoginWithPasswordHashFunction();

           /* String connString = System.Configuration.ConfigurationManager.ConnectionStrings["computerscienceprojectportal"].ToString();
            conn = new System.Data.SqlClient.SqlConnection(connString);
            queryStr = "";

            queryStr = "SELECT * FROM USERTABLE WHERE email='" + usernameTextBox.Text + "'AND password= '" + passwordTextBos.Text;
            cmd = new System.Data.SqlClient.SqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            name = "";
            while (reader.HasRows && reader.Read())
            {
                name = reader.GetString(reader.GetOrdinal("Fname")) + " " +
                reader.GetString(reader.GetOrdinal("Lname")) + " " +
                reader.GetString(reader.GetOrdinal("School"));

            }

            if (reader.HasRows)
            {
                Session["Fname"] = name;
                Response.BufferOutput = true;
                Response.Redirect("LoggedIn.aspx", false);
            }
            else
            {
                passwordTextBos.Text = "invalid user";
            }

            reader.Close();
            conn.Close();*/
        }


        private void LoginWithPasswordHashFunction()
        {
            List<string> saltHashList = null;
            List<string> nameList = null;

            try
            {
                
                //connected to the database
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                con.Open();
                
                queryStr = "SELECT Fname, Lname, password, email FROM USERTABLE WHERE email = @email";
                cmd = new SqlCommand(queryStr, con);
                cmd.Parameters.AddWithValue("@email", usernameTextBox.Text);

                reader = cmd.ExecuteReader();

                while (reader.HasRows && reader.Read())
                {
                    if (saltHashList == null)
                    {
                        saltHashList = new List<String>();
                        nameList = new List<String>();

                    }
                    String saltHashes = reader.GetString(reader.GetOrdinal("Password"));
                    saltHashList.Add(saltHashes);

                    String fullName = reader.GetString(reader.GetOrdinal("Fname")) + " " +
                                    reader.GetString(reader.GetOrdinal("Lname"));
                    nameList.Add(fullName);
                }

                reader.Close();

                if (saltHashList != null)
                {
                    for(int i = 0; i <saltHashList.Count; i++)
                    {
                        queryStr = "";
                        bool validUser = PasswordHash.VerifyPassword(passwordTextBos.Text, saltHashList[i]);
                        if (validUser == true)
                        {
                            Session["Fname"] = nameList[i];
                            Response.BufferOutput = true;
                            Response.Redirect("LoggedIn.aspx", false);

                        }
                        else
                        {
                            passwordTextBos.Text = "User not authentcate";
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