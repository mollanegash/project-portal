using System;
using System.Data;
using System.Data.SqlClient;

namespace TestForm.ProjectsCS
{
    public partial class ProjectList : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(@"Data Source=parsley.arvixe.com;Initial Catalog=computerscienceprojectportal;Persist Security Info=True;User ID=computerscienceprojectportal;Password=team4CS673");
        protected void Page_Load(object sender, EventArgs e)
        {
            Dis_data();
        }
        public void Dis_data()
        {
            
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.CommandText = "select * from Project2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();


            /*String temp = null;
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    var details = new projectDisplay();
                    details.UserID = Int32.Parse(reader["UserID"].ToString());
                    temp += details.UserID.ToString();
                    details.P_Name = reader["P_Name"].ToString();
                    temp += details.P_Name;
                    details.Link = reader["Link"].ToString();
                    temp += details.Link;
                    details.Tag = reader["Tag"].ToString();
                    temp += details.Tag;
                    details.Desprip = reader["Descrip"].ToString();
                    temp += details.Desprip;
                    details.uploadDate = reader["UploadDate"].ToString();
                    temp += details.uploadDate;
                    temp += "</br>";
                    P_UserInfo.Text = temp;
                
                }
                con.Close();

            }*/

        }
    }
}